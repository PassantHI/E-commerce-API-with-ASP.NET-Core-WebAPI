using Ecommerce.DTO;
using Ecommerce.Models;
using Ecommerce.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;

namespace Ecommerce.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public WishListController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }




        [HttpGet("UserWishList")]

        public IActionResult UserWishList() 
        {
            if (User.Identity.IsAuthenticated)
            {
                string userId= User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                var wishlist = _unitOfWork.WishList.GetBy(a => a.UserId == userId, new[] { "WishListItems.Product" } );
                if (wishlist != null) 
                {
                    List<WishListDTO> listDTOs = new List<WishListDTO>();
                    foreach(var item in wishlist.WishListItems)
                    {
                        WishListDTO DTOitem = new WishListDTO() 
                        {
                            WishListItemId=item.WishListItemId,
                            WishListId=item.WishListId,
                            ProductId=item.ProductId,
                            ProductName=item.Product.ProductName
                                      
                        };

                        listDTOs.Add(DTOitem);
                    }
                    return Ok (listDTOs);
                }
                return Ok("Wish list is empty");

            }
            return BadRequest();
        
        }




        [HttpPost("{ProductId}")]
        public IActionResult AddToWishList(int ProductId)
        {
            var product = _unitOfWork.Product.GetById(ProductId);
            if (product != null)
            {
                string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                var wishlist = _unitOfWork.WishList.GetBy(a => a.UserId == userId, new[] { "User" }); 

                if (wishlist != null)
                {
                    var wishlistitem=_unitOfWork.WishListItem.GetBy(a=>a.WishListId==wishlist.WishListId&& a.ProductId==product.ProductId);
                    if (wishlistitem == null) 
                    {
                        WishListItem item = new WishListItem();
                        item.ProductId = ProductId;
                        item.WishListId = wishlist.WishListId;
                        item.Date = DateTime.Now;

                        _unitOfWork.WishListItem.Add(item);
                        _unitOfWork.Complete();

                        WishListDTO dto = new WishListDTO()
                        {
                            WishListId = wishlist.WishListId,
                            WishListItemId = item.WishListItemId,
                            ProductId = item.ProductId,
                            ProductName = item.Product.ProductName,
                        };
                        return Ok(dto);
                    }

                    return Ok("product already in wishlist");
                }


                if (wishlist == null )
                {
                    WishList list = new WishList()
                    {
                        UserId = userId
                    };
                    _unitOfWork.WishList.Add(list);
                    _unitOfWork.Complete();


                    WishListItem item = new WishListItem();
                    item.ProductId = ProductId;
                    item.WishListId = list.WishListId;
                    item.Date = DateTime.Now;
                    _unitOfWork.WishListItem.Add(item);
                    _unitOfWork.Complete();
                    WishListDTO dto = new WishListDTO()
                    {
                        WishListId = wishlist.WishListId,
                        WishListItemId = item.WishListItemId,
                        ProductId = item.ProductId,
                        ProductName = item.Product.ProductName,
                    };
                    return Ok(dto);
                }

            }
            return BadRequest();
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteItem(int productId)
        {
            if (User.Identity.IsAuthenticated)
            {
                string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                var wishlist = _unitOfWork.WishList.GetBy(a => a.UserId == userId);
                if (wishlist != null)
                {
                    var wishlistitem = _unitOfWork.WishListItem.GetBy(a => a.WishListId == wishlist.WishListId && a.ProductId == productId);
                    if (wishlistitem != null)
                    {
                        _unitOfWork.WishListItem.DeleteById(wishlistitem.WishListItemId);
                        _unitOfWork.Complete();
                        return Ok("Deleted");
                    }
                    return NotFound(" product not found");
                }
                return NotFound("wishlist not found");

            }
            return BadRequest();
        }






    }

}

