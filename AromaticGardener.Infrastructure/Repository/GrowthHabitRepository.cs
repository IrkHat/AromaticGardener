using AromaticGardener.Application.Common.Interfaces;
using AromaticGardener.Domain.Entities;
using AromaticGardener.Infrastructure.Data;

namespace AromaticGardener.Infrastructure.Repositories
{
    public class GrowthHabitRepository : Repository<GrowthHabit>, IGrowthHabitRepository
    {
        private readonly ApplicationDbContext _context;

        public GrowthHabitRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(GrowthHabit entity)
        {
            _context.GrowthHabits.Update(entity);
        }
    }
}
