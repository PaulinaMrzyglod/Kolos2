using Kolos2.DTOs;
using Kolos2.Exceptions;
using Kolos2.Models;
using Kolos2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolos2.Controllers;

[ApiController]
[Route("api")]
public class NurseriesController : ControllerBase
{
    private readonly IDbService _dbService;
    
    public NurseriesController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("nurseries/{nurseryId}/batches")]
    public async Task<IActionResult> GetNurseriesBatch(int nurseryId)
    {
        try
        {
            var nursery = await _dbService.GetNurseriesAsync(nurseryId);
            return Ok(nursery);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost("batches")]
    public async Task<IActionResult> AddTree([FromBody] AddTreesDTO request)
    {
        try
        {
            await _dbService.AddTreeAsync(request);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ConflictException e)
        {
            return Conflict(e.Message);
        }
    }
}