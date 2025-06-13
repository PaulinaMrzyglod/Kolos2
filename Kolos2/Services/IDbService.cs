using Kolos2.DTOs;

namespace Kolos2.Services;

public interface IDbService
{
    Task<NurseriesDTO> GetNurseriesAsync(int nurseriesId);
    Task AddTreeAsync(AddTreesDTO dto);
}