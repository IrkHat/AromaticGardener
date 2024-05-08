using AromaticGardener.Domain.Entities;
using AromaticGardener.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;
namespace AromaticGardener.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<GrowthHabit> GrowthHabits { get; set; }
        public DbSet<LifeCycle> LifeCycles { get; set; }
        public DbSet<Herb> Herbs { get; set; }
        //public DbSet<HerbSeedKit> HerbSeedKits { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HerbSeedKit>().HasData(
                new HerbSeedKit
                {
                    Id = 1,
                    HerbId = 1,
                    Name = "Name",
                    Description = "Description",
                    Price = 15.99,
                    Stock = 200

                }
            );
            modelBuilder.Entity<Herb>().HasData(
                new Herb
                {
                    Id = 1,
                    CommonName = "Oregano",
                    ScientificName = "Origanum Vulgare",
                    Description = "Perennial herbaceous plant of the mint family, characterized by opposite, aromatic leaves and purple flowers.",
                    Bloom = "Summer",
                    BestSoilType = "Well-drained",
                    SoilPhMin = 6.5,
                    SoilPhMax = 7,
                    Watering = "Water when topsoil is dry",
                    Insulation = "Full",
                    GrowthHabitId = 1,
                    LifeCycleId = 1,
                    ImageUrl = ""
                }
            );
            
        }
    }
}
