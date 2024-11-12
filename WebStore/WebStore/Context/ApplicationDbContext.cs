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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Material)         // Một Product có một Material
                .WithMany(m => m.Products)       // Một Material có nhiều Product
                .HasForeignKey(p => p.Material_Id); // Khóa ngoại là MaterialId trong Product

            // Quan hệ 1:n giữa Gender và Product
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Gender)           // Một Product có một Gender
                .WithMany(g => g.Products)       // Một Gender có nhiều Product
                .HasForeignKey(p => p.Gender_Id)  // Khóa ngoại là GenderId trong Product
                .OnDelete(DeleteBehavior.Restrict); // Tránh xóa lẫn nhau khi xóa một thực thể

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Variants)       // Một Product có nhiều Variant
                .WithOne(v => v.Product)         // Một Variant chỉ thuộc về một Product
                .HasForeignKey(v => v.ProductId); // Khóa ngoại ở bảng Variant trỏ tới Product
            modelBuilder.Entity<Address>()
                .HasOne(a => a.User)
                .WithMany(a => a.Addresses)
                .HasForeignKey(a => a.UserId)
                 .OnDelete(DeleteBehavior.Restrict);


        }


    }
}
