namespace Ecommerce.DTO
{
    public class ProductDTO
    {
        
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public string ProductDescription { get; set; }

        public string CategoryName { get; set; }
        public string ImagePath { get; set; }

    }
}
