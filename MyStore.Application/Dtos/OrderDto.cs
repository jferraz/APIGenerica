using System.ComponentModel;

namespace MyStore.Application.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; private set; }        
        public string? Description { get; set; }
        public int CreateByUserId { get; set; }        
    }
}
