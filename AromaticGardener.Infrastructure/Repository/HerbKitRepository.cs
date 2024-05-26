using AromaticGardener.Application.Common.Interfaces;
using AromaticGardener.Domain.Entities;
using AromaticGardener.Infrastructure.Data;

namespace AromaticGardener.Infrastructure.Repositories
{

    public class HerbKitRepository : Repository<HerbKit>, IHerbKitRepository
    {
        private readonly ApplicationDbContext _context;

        public HerbKitRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(HerbKit entity)
        {
            _context.HerbKits.Update(entity);
        }
    }

}
