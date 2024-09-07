namespace BlinkApp.Models
{
    public class Message : BaseEntity
    {
        public string Comment { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
