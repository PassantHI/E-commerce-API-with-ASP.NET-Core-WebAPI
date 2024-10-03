namespace Ecommerce.DTO
{
    public class ProductPostDTO
    {
        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public string ProductDescription { get; set; }

        public int ProductCategoryId { get; set; }
        public int? StockQuantity { get; set; }

        public string? ImagePath { get; set; }
    }
}
