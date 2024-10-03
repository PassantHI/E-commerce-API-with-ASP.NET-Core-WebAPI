using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Status {  get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<CartItems> Items { get; set; }=new List<CartItems>();


    }
}
