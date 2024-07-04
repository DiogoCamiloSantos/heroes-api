using HeroesApi.Application.Services;
using HeroesApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PowersController : ControllerBase
    {
        private readonly PowerService powerService;

        public PowersController(PowerService powerService)
        {
            this.powerService = powerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Power>>> GetPowers()
        {
            var powers = await powerService.GetAllPowersAsync();
            return Ok(powers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Power>> GetPower(int id)
        {
            var power = await powerService.GetPowerByIdAsync(id);
            if (power == null)
            {
                return NotFound();
            }
            return Ok(power);
        }

        [HttpPost]
        public async Task<ActionResult<Power>> CreatePower(Power power)
        {
            var createdPower = await powerService.AddPowerAsync(power);
            return CreatedAtAction(nameof(GetPower), new { id = createdPower.Id }, createdPower);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Power>> UpdatePower(int id, Power power)
        {
            var updatedPower = await powerService.UpdatePowerAsync(id, power);
            if (updatedPower == null)
            {
                return NotFound();
            }
            return Ok(updatedPower);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePower(int id)
        {
            var result = await powerService.DeletePowerAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
