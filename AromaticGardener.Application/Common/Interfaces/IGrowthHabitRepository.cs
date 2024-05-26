using AromaticGardener.Domain.Entities;

namespace AromaticGardener.Application.Common.Interfaces
{
    public interface IGrowthHabitRepository : IRepository<GrowthHabit>
    {
        void Update(GrowthHabit entity);
    }
}
