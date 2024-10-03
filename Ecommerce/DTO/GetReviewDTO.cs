using System.ComponentModel.DataAnnotations;

namespace Ecommerce.DTO
{
    public class GetReviewDTO
    {
        public  string UserName {  get; set; }
        [Range(1,5)]
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }

    }
}
