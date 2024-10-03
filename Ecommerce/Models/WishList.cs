using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class WishList
    {
        [Key]
        public int WishListId { get; set; }

        [ForeignKey("User")]
        public string UserId {  get; set; }

        public virtual ICollection<WishListItem>? WishListItems { get; set; }=new List<WishListItem>();
        public ApplicationUser User { get; set; }
    }
}
