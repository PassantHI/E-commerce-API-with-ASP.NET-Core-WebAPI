using Ecommerce.DTO;
using Ecommerce.Models;
using Ecommerce.Repository;
using Ecommerce.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        //creat cart when add
        public CartController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager ;
        }

        [HttpGet("GetCar")]
        public async Task <IActionResult> GetCart() 
        {
            ApplicationUser user=null;

            if (User.Identity.IsAuthenticated) 
            {
              
                user = await _userManager.GetUserAsync(User);
            }
            if (user != null)
            { 
                var cart=  _unitOfWork.Cart.GetBy(a=>a.UserId == user.Id, new[] {"CartItems","Product"});
                if (cart == null)
                {
                    return NotFound();
                }
                return Ok(cart);

            }

            var _cart = HttpContext.Session.GetObjectFromJson<List<CartItems>>("Cart");
            if (_cart == null)
            {
                _cart = new List<CartItems>();
                HttpContext.Session.SetObjectAsJson("Cart", _cart);
            }
            return Ok(_cart);

        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct(int id , int quantity)
        {
            var product=_unitOfWork.Product.GetById(id);
            if (product !=null) 
            {
                var cart = HttpContext.Session.GetObjectFromJson<List<CartItems>>("Cart");
                if (cart == null)
                {
                    cart = new List<CartItems>();
                    HttpContext.Session.SetObjectAsJson("Cart", cart);
                }

                var exist = cart.SingleOrDefault(a => a.ProductId == id);
                if (exist != null)
                {
                    exist.Quantity += quantity;
                }
                else
                {
                    cart.Add(new CartItems { ProductId = product.ProductId, UnitPrice = product.Price, Quantity = quantity });
                    List<CartDTO> list = new List<CartDTO>();
                    foreach(var item in cart)
                    {
                        CartDTO cartitem=new CartDTO();
                        {
                            cartitem.ProductId = item.ProductId;
                            cartitem.Quantity = item.Quantity;
                            cartitem.UnitPrice = item.UnitPrice;
                            cartitem.ImagePath=product.ImagePath;   
                            cartitem.ProductDescription=product.ProductDescription;
                            
                        };
                        list.Add(cartitem);
                    }
                    return Ok(list);
                }
                HttpContext.Session.SetObjectAsJson("Cart", cart);

            }
            return BadRequest();
        }


        [HttpDelete("{productId}")]
        public IActionResult DeleteFromCart(int productId) 
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItems>>("Cart");
            if(cart != null) 
            {
                var product = cart.SingleOrDefault(a => a.ProductId == productId);
                if (product != null) 
                {
                    cart.Remove(product);
                
                }

                return NotFound();

            }

            return Ok("Empty Cart");

        }

    }
}
