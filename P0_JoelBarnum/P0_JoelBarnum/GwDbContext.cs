using Microsoft.EntityFrameworkCore;

namespace P0_JoelBarnum
{
    public class GwDbContext : DbContext
    {
        
        public DbSet<Customer> customers { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orderHistory { get; set; }
        public DbSet<StoreLocation> storeLocations { get; set; }
        public DbSet<Inventory> allInventory { get; set; }
        public DbSet<PurchasedProducts> purchasedProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=GwStoreDB;Trusted_Connection=True;");
            /*
            options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=YourDbName;Trusted_Connection=True;");
            */
        }
    }
}
