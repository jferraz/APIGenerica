namespace MyStore.Domain.Entities
{
    public class Product
    {
        public int Id { get; private set; }
        public Guid SKU { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public DateTime CreateDate { get; private set; }
    }
}