using Xunit;
using HeroesApi.Application.Services;
using Moq;
using System.Threading.Tasks;
using HeroesApi.Persistance.Repositories.Interfaces;
using HeroesApi.Domain.Models;

namespace HeroesApi.Tests
{
    public class HeroServiceTests
    {
        [Fact]
        public async Task CreateHeroAsync_WithValidData_ReturnsTrue()
        {
            // Arrange
            var mockHeroRepository = new Mock<IHeroRepository>(); 
            var mockPowerRepository = new Mock<IPowerRepository>(); 
            var heroService = new HeroService(mockHeroRepository.Object, mockPowerRepository.Object);

            var hero = new Hero
            {
                Name = "Bruce Wayne",
                HeroName = "Batman",
                BirthDate = new DateTime(1972, 02, 19),
                Height = 185.5f,
                Weight = 95.2f
            };

            // Act
            var result = await heroService.CreateHeroAsync(hero);

            // Assert
            Assert.True(result);
        }
    }
}
