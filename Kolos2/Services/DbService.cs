using Kolos2.Data;
using Kolos2.DTOs;
using Kolos2.Exceptions;
using Kolos2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolos2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<NurseriesDTO> GetNurseriesAsync(int nurseriesId)
    {
        var nurseries = await _context.Nurseries
            .Where(e => e.NurseryID == nurseriesId)
            .Select(e => new NurseriesDTO
            {
                nurseryId = e.NurseryID,
                name = e.Name,
                establishedDate = e.EstablishedDate,
                batches = e.SeedllingBatches.Select(sb => new BatchDTO
                {
                    batchId = sb.BatchId,
                    quantity = sb.Quantity,
                    sownDate = sb.SownDate,
                    readyDate = sb.ReadyDate,
                    species = new SpeciesDTO
                    {
                        latinName = sb.Species.LatinName,
                        growthTimeInYears = sb.Species.GrowthTimeInYears
                    },
                    responsibles = sb.Responsibles.Select(r => new ResponsibleDTO
                    {
                        firstName = r.Employee.FirstName,
                        lastName = r.Employee.LastName,
                        role = r.Role
                    }).ToList()
                }).ToList()


            }).FirstOrDefaultAsync();
        
        if(nurseries is null)
            throw new NotFoundException("Nie ma takiego indeksu");
        
        return nurseries;
    }

    public async Task AddTreeAsync(AddTreesDTO dto)
    {
        if(dto.quantity <= 0)
            throw new ArgumentOutOfRangeException("quantity musi byc wieksze niz 0");

        if (string.IsNullOrWhiteSpace(dto.species))
            throw new ArgumentException("Species is required.");

        if (string.IsNullOrWhiteSpace(dto.nursery))
            throw new ArgumentException("Nursery is required.");
        
        if (dto.responsible == null || !dto.responsible.Any())
        throw new ArgumentException("Musi byc dodana osoba chociaz jedna.");
        
        //szkolka check
        var nursery = await _context.Nurseries
            .FirstOrDefaultAsync(n => n.Name == dto.nursery);

        if (nursery == null)
            throw new KeyNotFoundException($"Nursery '{dto.nursery}' not found.");
        
        //gatunek check
        var species = await _context.Trees
            .FirstOrDefaultAsync(s => s.LatinName == dto.species);

        if (species == null)
            throw new KeyNotFoundException($"Tree species '{dto.species}' not found.");
        
        //pracownik check
        var employeeIds = dto.responsible.Select(r => r.employeeId).Distinct().ToList();
        var existingEmployeeIds = await _context.Employees
            .Where(e => employeeIds.Contains(e.EmployeeId))
            .Select(e => e.EmployeeId)
            .ToListAsync();

        var missingEmployees = employeeIds.Except(existingEmployeeIds).ToList();
        if (missingEmployees.Any())
            throw new KeyNotFoundException($"Employees not found: {string.Join(", ", missingEmployees)}");
        
        var batch = new SeedllingBatch
        {
            NurseryId = nursery.NurseryID,
            SpeciesId = species.SpeciesId,
            Quantity = dto.quantity,
            SownDate = DateTime.UtcNow
        };

        await _context.SeedllingBatches.AddAsync(batch);
        await _context.SaveChangesAsync();
        
        var responsibles = dto.responsible.Select(r => new Responsible
        {
            BatchId = batch.BatchId,
            EmployeeId = r.employeeId,
            Role = r.role
        }).ToList();

        await _context.Responsibles.AddRangeAsync(responsibles);
        await _context.SaveChangesAsync();
    }
}