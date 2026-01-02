using MyStore.Application.Dtos;
using MyStore.Domain.Entities;

namespace MyStore.Application.Products
{
    public interface IProductService
    {
       Task CreateAsync(CreateProductDto product);
       Task<IEnumerable<ProductDto>> GetAllAsync();        
    }
}