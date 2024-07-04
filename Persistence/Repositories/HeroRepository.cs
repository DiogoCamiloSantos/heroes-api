using HeroesApi.Domain.Models;
using HeroesApi.Persistance.Context;
using HeroesApi.Persistance.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesApi.Persistance.Repositories
{
    public class HeroRepository : IHeroRepository
    {
        private readonly AppDbContext context;

        public HeroRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Hero>> GetAllAsync()
        {
            return await context.Heroes.ToListAsync();
        }

        public async Task<Hero> GetByIdAsync(int id)
        {
            return await context.Heroes.FindAsync(id);
        }

        public async Task AddAsync(Hero heroInput)
        {
            var hero = new Hero
            {
                Name = heroInput.Name,
                HeroName = heroInput.HeroName,
                BirthDate = heroInput.BirthDate,
                Height = heroInput.Height,
                Weight = heroInput.Weight
            };

            foreach (var powerId in heroInput.HeroPowers)
            {
                var existingPower = await context.Powers.FindAsync(powerId);
                if (existingPower == null)
                {
                    var newPower = new Power { Id = IdGenerator.GenerateId(), Description = "New Power" }; // Ajuste conforme necessário
                    context.Powers.Add(newPower);
                }
            }

            hero.HeroPowers = heroInput.HeroPowers.Select(power => new HeroPower { PowerId = power.PowerId }).ToList();

            context.Heroes.Add(hero);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Hero hero)
        {
            context.Entry(hero).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Hero hero)
        {
            context.Heroes.Remove(hero);
            await context.SaveChangesAsync();
        }

        public async Task AddHeroPowerAsync(int heroId, int powerId)
        {
            var heroPower = new HeroPower { HeroId = heroId, PowerId = powerId };
            await context.HeroPowers.AddAsync(heroPower);
            await context.SaveChangesAsync();
        }

        public async Task UpdateHeroPowersAsync(int heroId, List<int> powerIds)
        {
            var existingPowers = await context.HeroPowers.Where(hp => hp.HeroId == heroId).ToListAsync();
            context.HeroPowers.RemoveRange(existingPowers);

            foreach (var powerId in powerIds)
            {
                var heroPower = new HeroPower { HeroId = heroId, PowerId = powerId };
                await context.HeroPowers.AddAsync(heroPower);
            }

            await context.SaveChangesAsync();
        }
    }
}
