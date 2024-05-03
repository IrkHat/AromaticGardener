using AromaticGardener.Domain.Entities;
using AromaticGardener.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;
namespace AromaticGardener.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Herb> Herbs {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Herb>().HasData(
                new Herb
                {
                    Id = 1,
                    CommonName = "Oregano",
                    Description = "Perennial herbaceous plant of the mint family, characterized by opposite, aromatic leaves and purple flowers.",
                    Bloom = "Summer",
                    BestSoilType = "Well-drained",
                    SoilPhMin = 6.5,
                    SoilPhMax = 7,
                    Watering = "Water when topsoil is dry",
                    Insulation = "Full",
                    GrowthHabit = "Herb",
                    LifeCycle = "Perennial",
                    ImageUrl = ""
                }

                ); ;
        }
    }
}
