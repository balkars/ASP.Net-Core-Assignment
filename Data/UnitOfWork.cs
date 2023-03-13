using CarSales.Core;

namespace CarSales.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(CarsDbContext context) {
            Context = context;
        }

        public CarsDbContext Context { get; }

        public async Task CompleteAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
