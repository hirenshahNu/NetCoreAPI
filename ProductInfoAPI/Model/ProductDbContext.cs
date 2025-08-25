using Microsoft.EntityFrameworkCore;

namespace ProductInfoAPI.Model
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        { 
            
        }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<OrderModel> Orders { get; set; }        
    }
}
