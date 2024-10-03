using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Ecommerce.Models
{
    public class ApplicationDBContext:IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItems> CartItems { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<WishList> WishList { get; set; }
        public DbSet<WishListItem>WishListItems { get; set; }

        public ApplicationDBContext()
        {
            
        }
        public ApplicationDBContext(DbContextOptions options):base(options) 
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\sqlexpress;Database=APIEcommerceProject;Integrated Security=sspi;TrustServerCertificate=true;Encrypt=true;");
            base.OnConfiguring(optionsBuilder);
        }

        
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<IdentityRole>().HasData(

               new IdentityRole()
               {
                   Id = Guid.NewGuid().ToString(),
                   Name = "Admin",
                   NormalizedName = "admin",
                   ConcurrencyStamp = Guid.NewGuid().ToString()
               },
               new IdentityRole()
               {
                   Id = Guid.NewGuid().ToString(),
                   Name = "User",
                   NormalizedName = "user",
                   ConcurrencyStamp = Guid.NewGuid().ToString()
               }


            );


            base.OnModelCreating(modelbuilder);
        }
    }
}
