namespace MyStore.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }
        public DateTime CreateDate { get; private set; } = DateTime.Now;
        public DateTime UpdateDate { get; private set;} = DateTime.Now;
        public string? Description { get; set; }
        public int CreateByUserId { get; set; }
        public required User CreateByUser { get; set; }
        public required List<Product> Products { get; set; }
    }
}
