using AromaticGardener.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AromaticGardener.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<GrowthHabit> GrowthHabits { get; set; }
        public DbSet<LifeCycle> LifeCycles { get; set; }
        public DbSet<Herb> Herbs { get; set; }
        public DbSet<HerbKit> HerbKits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GrowthHabit>().HasData(
                new GrowthHabit
                {
                    Id = 1,
                    Habit = "Herb",
                },
                new GrowthHabit
                {
                    Id = 2,
                    Habit = "Shrub",
                },
                new GrowthHabit
                {
                    Id = 3,
                    Habit = "Tree",
                },
                new GrowthHabit
                {
                    Id = 4,
                    Habit = "Vine",
                }
            );

            modelBuilder.Entity<LifeCycle>().HasData(
                new LifeCycle
                {
                    Id = 1,
                    Cycle = "Annual",
                },
                new LifeCycle
                {
                    Id = 2,
                    Cycle = "Biennial",
                },
                new LifeCycle
                {
                    Id = 3,
                    Cycle = "Perennial",
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
                    BestSoilType = "Well-drained soil",
                    SoilPhMin = 6.5,
                    SoilPhMax = 7,
                    Watering = "Water when topsoil is dry",
                    Insulation = "Full",
                    GrowthHabitId = 1,
                    LifeCycleId = 3,
                    ImageUrl = "",
                }
            );

            modelBuilder.Entity<HerbKit>().HasData(
                new HerbKit
                {
                    Id = 1,
                    HerbId = 1,
                    Name = "Basic Herb Kit",
                    Description = "Includes seeds for growing oregano.",
                    Price = 9.99,
                    Stock = 50
                }
            );
        }
    }
}
