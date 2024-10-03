using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class WishListItem
    {
        [Key]
        public int WishListItemId {  get; set; }
        [ForeignKey("WishList")]
        public int WishListId { get; set; }
        [ForeignKey("Product")]
        public int ProductId {  get; set; }

        public DateTime Date { get; set; }

        public Product Product { get; set; }
        public WishList WishList { get; set; }



    }
}
