using MyStore.Domain.Entities;

namespace MyStore.Application.Products
{
    public interface IProductService
    {
       Task CreateAsync(Product product);
       Task<IEnumerable<Product>> GetAllAsync();        
    }
}