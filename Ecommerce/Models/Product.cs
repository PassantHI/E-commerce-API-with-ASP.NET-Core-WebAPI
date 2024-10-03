using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }

        public string? ProductDescription { get; set; }
        [Required]
        public decimal Price { get; set; }


        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public string? ImagePath {  get; set; }
        public int? StockQuantity { get; set; }

        public bool Active {  get; set; }
        public Category Category { get; set; }

        public ICollection<OrderItems>OrderItems { get; set; }=new List<OrderItems>();
        public ICollection<CartItems> CartItems { get; set; } =new List<CartItems>();
        public ICollection<Review> Reviews { get; set; }=new List<Review>();
        public ICollection<WishListItem> WishListItems { get; set;} =new List<WishListItem>();





    }
}
