using Ecommerce.Models;

namespace Ecommerce.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        protected ApplicationDBContext _context;
        public IBaseRepository<Product> Product {  get; private set; }

        public IBaseRepository<Category> Category { get; private set; }

        public IBaseRepository<Order> Order { get; private set; }

        public IBaseRepository<OrderItems> OrderItems { get; private set; }

        public IBaseRepository<Cart> Cart { get; private set; }

        public IBaseRepository<CartItems> CartItems { get; private set; }

        public IBaseRepository<Payment> Payment { get; private set; }
        public IBaseRepository<Review> Review { get; private set; }

        public IBaseRepository<WishList> WishList {  get; private set; }
        public IBaseRepository<WishListItem> WishListItem {  get; private set; }

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;

            Product = new BaseRepository<Product> (_context);
            Category = new BaseRepository<Category> (_context);
            Order = new BaseRepository<Order> (_context);
            OrderItems= new BaseRepository<OrderItems> (_context);
            Cart = new BaseRepository<Cart> (_context);
            CartItems= new BaseRepository<CartItems> (_context);
            Payment = new BaseRepository<Payment>(_context);
            Review=new BaseRepository<Review> (_context);
            WishList=new BaseRepository<WishList> (_context);
            WishListItem=new BaseRepository<WishListItem> (_context);



        }


        public int Complete()
        {
           return   _context.SaveChanges();
        }
        public void Dispose() 
        {
            _context.Dispose();
        
        }

        
    }
}
