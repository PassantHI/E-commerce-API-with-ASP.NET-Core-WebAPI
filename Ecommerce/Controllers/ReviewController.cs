using Ecommerce.DTO;
using Ecommerce.Models;
using Ecommerce.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Authorize(Roles = "Admin , User")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReviewController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }


        [HttpPost("AddReview")]
        public IActionResult AddReview(ReviewDTO reviewdto)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                    Product product = _unitOfWork.Product.GetById(reviewdto.ProductId);
                    if (product != null)
                    {
                        var review = _unitOfWork.Review.GetBy(a => a.UserId == userId && a.ProductId == reviewdto.ProductId);
                        if (review == null)
                        {
                            Review newreview = new Review();
                            newreview.UserId = userId;
                            newreview.ProductId = reviewdto.ProductId;
                            newreview.Rating = reviewdto.Rating;
                            newreview.CreatedDate = DateTime.Now;
                            newreview.Comment = reviewdto.Comment;
                            _unitOfWork.Review.Add(newreview);
                            _unitOfWork.Complete();

                            return Ok(reviewdto);
                        }

                        return Ok("Review made before");
                    }
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        [AllowAnonymous]
        [HttpGet("{productId}")]
        public IActionResult ProductReview(int productId)
        {
            Product product=_unitOfWork.Product.GetById(productId);
            if (product != null) 
            {
                var reviews= _unitOfWork.Review.GetAllBy(a => a.ProductId == productId ,"User");
                if (reviews.Any()) 
                {
                    List<GetReviewDTO> list = new List<GetReviewDTO>();
                    foreach (var review in reviews) 
                    {
                        GetReviewDTO dto = new GetReviewDTO()
                        {
                            UserName = review.User.UserName,
                            Rating = review.Rating,
                            Comment = review.Comment,
                            Date = review.CreatedDate,
                        };
                        list.Add(dto);
                    }
                    return Ok(list);                
                }
                return NoContent();        
            }
            return BadRequest();
        }

        [HttpPut("UpdateReview")]
        public IActionResult UpdateReview(ReviewDTO dto)
        {
            if (User.Identity.IsAuthenticated) 
            {
                string userId=User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
                var review=_unitOfWork.Review.GetBy(a=>a.ProductId == dto.ProductId&&a.UserId == userId);
                if (review != null) 
                {
                    review.Rating = dto.Rating;
                    review.Comment = dto.Comment;
                    review.CreatedDate=DateTime.Now;
                    _unitOfWork.Review.Update(review);
                    _unitOfWork.Complete();
                    
                    return Ok(review);
                }
                return BadRequest();
            
            }
            return BadRequest();
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteReview(int productId) 
        {
            if (User.Identity.IsAuthenticated) 
            {
                string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
                var review = _unitOfWork.Review.GetBy(a => a.ProductId==productId && a.UserId == userId);
                if (review != null) 
                {
                    _unitOfWork.Review.DeleteById(review.Id);
                    _unitOfWork.Complete();
                    return Ok("Deleted");
                }
            
            }
            return BadRequest();
        
        }
    }
}
