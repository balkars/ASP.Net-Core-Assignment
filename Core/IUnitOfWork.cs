namespace CarSales.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
