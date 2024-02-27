using Application.Interfaces;
using DTOS.ArmchairsDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArmchairsController : ControllerBase
{
    private readonly IArmchairsService _armchairsService;

    public ArmchairsController(IArmchairsService armchairsService)
    {
        _armchairsService = armchairsService;
    }

    // GET: api/Armchairs
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ArmchairsDTO>>> GetArmchairs()
    {
        var armchairs = await _armchairsService.GetArmchairsAsync();
        return Ok(armchairs);
    }

    // GET: api/Armchairs/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ArmchairsDTO>> GetArmchairs(int id)
    {
        var armchairs = await _armchairsService.GetArmchairsByIdAsync(id);
        return Ok(armchairs);
    }

    // POST: api/Armchairs
    [HttpPost]
    public async Task<ActionResult<ArmchairsDTO>> PostArmchairs(AddArmchairsDTO addArmchairsDTO)
    {
        await _armchairsService.AddArmchairsAsync(addArmchairsDTO);
        return Ok(addArmchairsDTO);
    }

    // PUT: api/Armchairs/5
    [HttpPut]
    public async Task<IActionResult> PutArmchairs(UpdateArmchairsDTO updateArmchairsDTO)
    {
        await _armchairsService.UpdateArmchairsAsync(updateArmchairsDTO);
        return NoContent();
    }

    // DELETE: api/Armchairs/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArmchairs(int id)
    {
        await _armchairsService.DeleteArmchairsAsync(id);
        return NoContent();
    }
}
