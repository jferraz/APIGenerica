namespace MyStore.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public required string Name { get; set; }
        public required string Email { get; set; }        
        public DateTime CreateDate { get; private set; } = DateTime.Now;
        public List<Order> Orders { get; } = new List<Order>();
       
    }
}