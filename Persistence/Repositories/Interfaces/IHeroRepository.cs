using HeroesApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroesApi.Persistance.Repositories.Interfaces
{
    public interface IHeroRepository
    {
        Task<IEnumerable<Hero>> GetAllAsync();
        Task<Hero> GetByIdAsync(int id);
        Task AddAsync(Hero hero);
        Task UpdateAsync(Hero hero);
        Task DeleteAsync(Hero hero);
        Task AddHeroPowerAsync(int heroId, int powerId);
        Task UpdateHeroPowersAsync(int heroId, List<int> powerIds);
    }
}
