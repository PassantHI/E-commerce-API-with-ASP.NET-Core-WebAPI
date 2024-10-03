using Ecommerce.DTO;
using Ecommerce.Models;
using Ecommerce.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()  
        {
            var orders = _unitOfWork.Order.GetAll();
            if (orders.Any()) 
            {
                List<OrderDTO> list = new List<OrderDTO>();
                foreach (var order in orders)
                {
                    OrderDTO orderdto = new OrderDTO()
                    {
                        OrderId = order.OrderId,
                        UserId = order.UserId,
                        OrderDate = order.OrderDate,
                        TotalPrice = order.TotalPrice,
                        OrderStatus = order.OrderStatus,
                        PaymentStatus = order.PaymentStatus,
                        ShippingAddress = order.ShippingAddress,
                    };
                    list.Add(orderdto);
                }
                return Ok(list);

            }
            return NoContent();
        }


        [Authorize(Roles = "Admin , User" )]
        [HttpGet("GetUserOrders")]
        public IActionResult GetUserOrders() 
        {
            if (User.Identity.IsAuthenticated) 
            {
                string userId= User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                var orders = _unitOfWork.Order.GetAllBy(a => a.UserId == userId, "User");
                if (orders.Any()) 
                {
                    List<OrderDTO> list = new List<OrderDTO>();
                    foreach (var order in orders) 
                    {
                        OrderDTO orderdto = new OrderDTO()
                        {
                            OrderId = order.OrderId,
                            UserId = order.UserId,
                            OrderDate = order.OrderDate,
                            TotalPrice = order.TotalPrice,
                            OrderStatus = order.OrderStatus,
                            PaymentStatus = order.PaymentStatus,
                            ShippingAddress = order.ShippingAddress,
                        };
                        list.Add(orderdto);
                    
                    }

                    return Ok(list);
                }
                return NoContent();
            }
            return Unauthorized();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var order= _unitOfWork.Order.GetById(id);
            if (order != null) 
            {
                _unitOfWork.Order.DeleteById(id);
                _unitOfWork.Complete();
                return Ok("Deleated");

            }
            else
                return NotFound();
        }
    }
}
