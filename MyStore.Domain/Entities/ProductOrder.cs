using MyStore.Domain.Dtos;

namespace MyStore.Domain.Entities
{
    public class ProductOrder
    {
        public Guid ProductId { get; private set; }
        public Product Product { get; private set; } = null!;

        public Guid OrderId { get; private set; }
        public Order Order { get; private set; } = null!;

    }
}
