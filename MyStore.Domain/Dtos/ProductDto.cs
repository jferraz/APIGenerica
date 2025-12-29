namespace MyStore.Domain.Dtos
{
    public class ProductDto
    {
        public int Id { get; private set; }
        public Guid SKU { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }        
    }
}