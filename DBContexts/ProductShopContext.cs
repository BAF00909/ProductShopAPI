using Microsoft.EntityFrameworkCore;
using ProductShop.Entities;
namespace ProductShop.DBContexts
{
    public class ProductShopContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<OverdueProduct> OverdueProducts { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ReasonReturn> ReasonsReturn { get; set; }
        public DbSet<ReturnedProduct> ReturnedProducts { get; set; }
        public DbSet<SoltProduct> SoltProducts { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public ProductShopContext(DbContextOptions<ProductShopContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
