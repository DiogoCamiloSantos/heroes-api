using HeroesApi.Domain.Models;
using HeroesApi.Persistance.Context;
using HeroesApi.Persistance.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HeroesApi.Persistance.Repositories
{
    public class PowerRepository : IPowerRepository
    {
        private readonly AppDbContext context;

        public PowerRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Power>> GetAllPowersAsync()
        {
            return await context.Powers.ToListAsync();
        }

        public async Task<Power> GetPowerByIdAsync(int id)
        {
            return await context.Powers.FindAsync(id);
        }

        public async Task<Power> AddPowerAsync(Power power)
        {
            context.Powers.Add(power);
            await context.SaveChangesAsync();
            return power;
        }

        public async Task<Power> UpdatePowerAsync(Power power)
        {
            context.Powers.Update(power);
            await context.SaveChangesAsync();
            return power;
        }

        public async Task<bool> DeletePowerAsync(int id)
        {
            var power = await context.Powers.FindAsync(id);
            if (power == null)
            {
                return false;
            }

            context.Powers.Remove(power);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
