
using HeroesApi.Domain.Models;

namespace HeroesApi.Persistance.Repositories.Interfaces
{
    public interface IPowerRepository
    {
        Task<IEnumerable<Power>> GetAllPowersAsync();
        Task<Power> GetPowerByIdAsync(int id);
        Task<Power> AddPowerAsync(Power power);
        Task<Power> UpdatePowerAsync(Power power);
        Task<bool> DeletePowerAsync(int id);
    }
}
