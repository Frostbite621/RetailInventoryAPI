namespace RetailInventoryAPI.DTOs
{
    public class ProductReadDto
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}