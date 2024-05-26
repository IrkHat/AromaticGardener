using AromaticGardener.Domain.Entities;

namespace AromaticGardener.Application.Common.Interfaces
{
    public interface IHerbKitRepository : IRepository<HerbKit>
    {
        void Update(HerbKit entity);
    }
}
