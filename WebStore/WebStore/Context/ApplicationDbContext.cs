using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebStore.Entity;


namespace WebStore.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; } // Ánh xạ tới bảng Users
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
