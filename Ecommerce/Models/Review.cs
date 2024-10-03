using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Product")]
        public int ProductId {  get; set; }

        [Range(1,5)]
        public int Rating {  get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }

        public Product Product { get; set; }
        public ApplicationUser User { get; set; }
    }
}
