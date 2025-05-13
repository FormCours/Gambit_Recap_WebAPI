namespace Gambit.Domain.Models
{
    public class Product
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Price { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public string? Desc { get; set; }
        public required bool IsAvailable { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public required int Quantity { get; set; }
    }
}
