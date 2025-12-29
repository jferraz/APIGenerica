namespace MyStore.Domain.Dtos
{
    public class ProductOrderDto
    {
        public Guid ProductId { get; private set; } 
        public Guid OrderId { get; private set; }       

    }
}
