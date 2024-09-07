namespace BlinkApp.Models
{
    public class Pricing: BaseEntity
    {
        public string Type { get; set; }
        public string Text { get; set; }
        public int Price { get; set; }
        public string ButtonLink { get; set; }
        public string Description { get; set; }
    }
}
