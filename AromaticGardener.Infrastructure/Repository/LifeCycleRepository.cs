using AromaticGardener.Application.Common.Interfaces;
using AromaticGardener.Domain.Entities;
using AromaticGardener.Infrastructure.Data;

namespace AromaticGardener.Infrastructure.Repositories
{
    public class LifeCycleRepository : Repository<LifeCycle>, ILifeCycleRepository
    {
        private readonly ApplicationDbContext _context;

        public LifeCycleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(LifeCycle entity)
        {
            _context.LifeCycles.Update(entity);
        }
    }

}
