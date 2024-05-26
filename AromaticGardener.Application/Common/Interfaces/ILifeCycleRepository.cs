using AromaticGardener.Domain.Entities;

namespace AromaticGardener.Application.Common.Interfaces
{
    public interface ILifeCycleRepository : IRepository<LifeCycle>
    {
        void Update(LifeCycle entity);
    }
}
