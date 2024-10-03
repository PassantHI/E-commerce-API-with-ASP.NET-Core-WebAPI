namespace Ecommerce.DTO
{
    public class CartDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string? ProductDescription { get; set; }
        public string? ImagePath { get; set; }

    }
}
