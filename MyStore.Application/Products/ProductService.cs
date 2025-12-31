using MyStore.Domain.Entities;
using MyStore.Domain.Interfaces;

namespace MyStore.Application.Products
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Product> _repository;

        public ProductService(IUnitOfWork uow, IRepository<Product> repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public async Task CreateAsync(Product product)
        {
            await _repository.AddAsync(product);

            var success = await _uow.SaveChangesAsync();

            if (!success)
                throw new Exception("Creating product error");
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

    }
}
