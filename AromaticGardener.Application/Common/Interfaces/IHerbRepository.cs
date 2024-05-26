using AromaticGardener.Domain.Entities;

namespace AromaticGardener.Application.Common.Interfaces
{
    public interface IHerbRepository : IRepository<Herb>
    {
        void Update(Herb entity);
    }
}