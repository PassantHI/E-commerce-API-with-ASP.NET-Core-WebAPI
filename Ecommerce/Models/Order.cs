using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserId {  get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }

        public string OrderStatus {  get; set; }
        [Required]
        public string PaymentStatus {  get; set; }

        [Required]
        public string ShippingAddress {  get; set; }
       
        public ApplicationUser User { get; set; }

        public ICollection <OrderItems> OrderItems { get; set; }=new List<OrderItems>();

    }
}
