using MyStore.Application.Dtos;
using MyStore.Domain.Entities;
using MyStore.Domain.Interfaces;
using AutoMapper;

namespace MyStore.Application.Products
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork uow, IRepository<Product> repository, IMapper mapper)
        {
            _uow = uow;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateProductDto product)
        {
            var entity = _mapper.Map<Product>(product);

            await _repository.AddAsync(entity);

            var success = await _uow.SaveChangesAsync();

            if (!success)
                throw new Exception("Creating product error");
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {            
            var products = await _repository.GetAllAsync();

            var dtos = _mapper.Map<IEnumerable<ProductDto>>(products);

            return dtos;
        }

    }
}
