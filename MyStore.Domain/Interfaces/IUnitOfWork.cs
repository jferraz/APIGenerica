namespace MyStore.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> SaveChangesAsync();
    }
}
