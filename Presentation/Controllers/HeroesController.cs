using HeroesApi.Application.Services;
using HeroesApi.Domain.Models;
using HeroesApi.Presentation.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroesApi.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeroesController : ControllerBase
    {
        private readonly HeroService _heroService;

        public HeroesController(HeroService heroService)
        {
            _heroService = heroService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHero([FromBody] HeroCreateDto heroCreateDto)
        {
            if (heroCreateDto == null)
            {
                return BadRequest("Hero data is null");
            }

            var hero = new Hero
            {
                Name = heroCreateDto.Name,
                HeroName = heroCreateDto.HeroName,
                Height = heroCreateDto.Height,
                Weight = heroCreateDto.Weight
            };

            await _heroService.CreateHeroAsync(hero, heroCreateDto.PowerIds);

            return CreatedAtAction(nameof(GetHeroById), new { id = hero.Id }, hero);
        }

        [HttpGet]
        public async Task<IActionResult> GetHeroes()
        {
            var heroes = await _heroService.GetHeroesAsync();
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHeroById(int id)
        {
            var hero = await _heroService.GetHeroByIdAsync(id);
            if (hero == null)
            {
                return NotFound();
            }
            return Ok(hero);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHero(int id, [FromBody] HeroUpdateDto heroUpdateDto)
        {
            if (heroUpdateDto == null || id != heroUpdateDto.Id)
            {
                return BadRequest("Hero data is null or ID mismatch");
            }

            var hero = new Hero
            {
                Id = heroUpdateDto.Id,
                Name = heroUpdateDto.Name,
                HeroName = heroUpdateDto.HeroName,
                BirthDate = heroUpdateDto.DateOfBirth,
                Height = heroUpdateDto.Height,
                Weight = heroUpdateDto.Weight
            };

            var result = await _heroService.UpdateHeroAsync(hero, heroUpdateDto.PowerIds);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var result = await _heroService.DeleteHeroAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
