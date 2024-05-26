namespace AromaticGardener.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IHerbRepository Herb { get; }
        IGrowthHabitRepository GrowthHabit { get; }
        ILifeCycleRepository LifeCycle { get; }   
        IHerbKitRepository HerbKit { get; }   
        void Save();
    }
}
