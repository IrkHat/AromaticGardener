using AromaticGardener.Application.Common.Interfaces;
using AromaticGardener.Domain.Entities;
using AromaticGardener.Infrastructure.Repositories;

namespace AromaticGardener.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IHerbRepository Herb { get; private set; }
        public IGrowthHabitRepository GrowthHabit { get; private set; }
        public ILifeCycleRepository LifeCycle { get; private set; }
        public IHerbKitRepository HerbKit { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Herb = new HerbRepository(_db);
            GrowthHabit = new GrowthHabitRepository(_db);
            LifeCycle = new LifeCycleRepository(_db);
            HerbKit = new HerbKitRepository(_db);
        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
