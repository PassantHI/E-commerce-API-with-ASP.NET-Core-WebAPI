using Ecommerce.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace Ecommerce.Repository
{
    public interface IUnitOfWork:IDisposable
    {
        IBaseRepository<Product> Product {  get; }
        IBaseRepository<Category> Category { get; }
        IBaseRepository<Order> Order { get; }
        IBaseRepository<OrderItems> OrderItems { get; }
        IBaseRepository<Cart> Cart { get; }
        IBaseRepository<CartItems> CartItems { get; }
        IBaseRepository<Payment> Payment { get; }

        IBaseRepository<Review> Review { get; }

        public IBaseRepository<WishList> WishList {  get; }

        public IBaseRepository<WishListItem> WishListItem {  get; }
        int Complete();
        



    }
}
