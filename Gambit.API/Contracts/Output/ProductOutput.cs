namespace Gambit.API.Contracts.Output
{
    public class ProductOutput
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Price { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public string? Desc { get; set; }
        public required bool IsAvailable { get; set; }
        public required int Quantity { get; set; }
    }

    public class ProductListOutput
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Price { get; set; }
        public required int Quantity { get; set; }
    }

}
