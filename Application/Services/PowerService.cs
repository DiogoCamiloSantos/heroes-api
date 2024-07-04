
using HeroesApi.Domain.Models;
using HeroesApi.Persistance.Repositories.Interfaces;

namespace HeroesApi.Application.Services
{
    public class PowerService
    {
        private readonly IPowerRepository _powerRepository;

        public PowerService(IPowerRepository powerRepository)
        {
            _powerRepository = powerRepository;
        }

        public async Task<IEnumerable<Power>> GetAllPowersAsync()
        {
            return await _powerRepository.GetAllPowersAsync();
        }

        public async Task<Power> GetPowerByIdAsync(int id)
        {
            return await _powerRepository.GetPowerByIdAsync(id);
        }

        public async Task<Power> AddPowerAsync(Power power)
        {
            return await _powerRepository.AddPowerAsync(power);
        }

        public async Task<Power> UpdatePowerAsync(int id, Power power)
        {
            var existingPower = await _powerRepository.GetPowerByIdAsync(id);
            if (existingPower == null)
            {
                return null;
            }

            existingPower.Description = power.Description;

            return await _powerRepository.UpdatePowerAsync(existingPower);
        }

        public async Task<bool> DeletePowerAsync(int id)
        {
            return await _powerRepository.DeletePowerAsync(id);
        }
    }
}