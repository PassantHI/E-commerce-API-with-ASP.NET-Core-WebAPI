using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class CartItems
    {
        [Key]
        public int CartItemID { get; set; }
        [ForeignKey("Product")]
        public int ProductId {  get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        [ForeignKey("Cart")]
        public int CartID { get; set; }



        public Cart Cart { get; set; }
        public Product Product { get; set; }




    }
}
