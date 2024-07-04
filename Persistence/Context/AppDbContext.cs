using HeroesApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HeroesApi.Persistance.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Power> Powers { get; set; }
        public DbSet<HeroPower> HeroPowers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("HeroDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
              modelBuilder.Entity<HeroPower>()
            .HasKey(hp => new { hp.HeroId, hp.PowerId });

        modelBuilder.Entity<HeroPower>()
            .HasOne(hp => hp.Hero)
            .WithMany(h => h.HeroPowers)
            .HasForeignKey(hp => hp.HeroId);


    base.OnModelCreating(modelBuilder);
        }
    }
}
