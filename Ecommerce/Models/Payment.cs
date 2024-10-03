using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [ForeignKey("Order")]
        public int OrderId {  get; set; }
        [Required]
        public string PaymentMethod {  get; set; }
        [Required]
        public string PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }

        public string TransactionId {  get; set; }

        public Order Order { get; set; }

    }
}
