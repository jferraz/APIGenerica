namespace MyStore.Domain.Dtos
{
    public class UserDto
    {
        public int Id { get; private set; }
        public required string Name { get; set; }
        public required string Email { get; set; }  
       
    }
}