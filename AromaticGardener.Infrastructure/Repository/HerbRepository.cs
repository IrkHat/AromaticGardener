using AromaticGardener.Application.Common.Interfaces;
using AromaticGardener.Domain.Entities;
using AromaticGardener.Infrastructure.Data;

namespace AromaticGardener.Infrastructure.Repositories
{


    public class HerbRepository : Repository<Herb>, IHerbRepository
    {
        private readonly ApplicationDbContext _context;

        public HerbRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Herb entity)
        {
            _context.Herbs.Update(entity);
        }
    }

}
