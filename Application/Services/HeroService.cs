using HeroesApi.Domain.Models;
using HeroesApi.Persistance.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroesApi.Application.Services
{
    public class HeroService
    {
        private readonly IHeroRepository _heroRepository;
        private readonly IPowerRepository _powerRepository;

        public HeroService(IHeroRepository heroRepository, IPowerRepository powerRepository)
        {
            _heroRepository = heroRepository;
            _powerRepository = powerRepository;
        }

        public async Task CreateHeroAsync(Hero hero, List<int> powerIds)
        {
            await _heroRepository.AddAsync(hero);
            foreach (var powerId in powerIds)
            {
                await _heroRepository.AddHeroPowerAsync(hero.Id, powerId);
            }
        }

        public async Task<IEnumerable<Hero>> GetHeroesAsync()
        {
            return await _heroRepository.GetAllAsync();
        }

        public async Task<Hero> GetHeroByIdAsync(int id)
        {
            return await _heroRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateHeroAsync(Hero hero, List<int> powerIds)
        {
            var existingHero = await _heroRepository.GetByIdAsync(hero.Id);
            if (existingHero == null) return false;

            existingHero.Name = hero.Name;
            existingHero.HeroName = hero.HeroName;
            existingHero.BirthDate = hero.BirthDate;
            existingHero.Height = hero.Height;
            existingHero.Weight = hero.Weight;

            await _heroRepository.UpdateAsync(existingHero);
            await _heroRepository.UpdateHeroPowersAsync(hero.Id, powerIds);

            return true;
        }

        public async Task<bool> DeleteHeroAsync(int id)
        {
            var hero = await _heroRepository.GetByIdAsync(id);
            if (hero == null) return false;

            await _heroRepository.DeleteAsync(hero);
            return true;
        }
    }
}
