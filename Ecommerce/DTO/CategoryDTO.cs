using System.ComponentModel.DataAnnotations;

namespace Ecommerce.DTO
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
   
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }
    }
}
