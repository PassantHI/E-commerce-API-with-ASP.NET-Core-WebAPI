using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public bool Active { get; set; }


        public virtual ICollection<Product> Products {  get; set; }=new List<Product>();



    }
}
