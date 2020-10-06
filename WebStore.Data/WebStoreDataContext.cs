using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebStore.Data.Models;

namespace WebStore.Data
{
	public class WebStoreDataContext : IdentityDbContext<ApplicationUser>
	{
		public WebStoreDataContext(DbContextOptions<WebStoreDataContext> conn) : base(conn)
		{

		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{

			optionsBuilder.EnableSensitiveDataLogging();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CustomerDAL>()
				.HasOne(x => x.ApplicationUser)
				.WithOne(x => x.Customer);

			modelBuilder.Entity<SupplierDAL>()
				.HasOne(x => x.ApplicationUser)
				.WithOne(x => x.Supplier);

			modelBuilder.Entity<CategoryDAL>()
				.HasOne(c => c.ParentCategory)
				.WithMany(c => c.ChildrenCategories)
				.HasForeignKey(c => c.ParentCategoryId);

			modelBuilder.Entity<CustomerDAL>()
				.HasMany(c => c.Wishes)
				.WithOne(o => o.Customer)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<OrderDAL>()
				.HasOne(c => c.Customer)
				.WithMany(o => o.Orders)
				.OnDelete(DeleteBehavior.SetNull);
			modelBuilder.Entity<OrderDAL>()
				.HasOne(c => c.Payment)
				.WithMany(o => o.Orders)
				.OnDelete(DeleteBehavior.SetNull);
			modelBuilder.Entity<OrderDAL>()
				.HasOne(c => c.Shipper)
				.WithMany(o => o.Orders)
				.OnDelete(DeleteBehavior.SetNull);
			modelBuilder.Entity<OrderDAL>()
				.HasMany(c => c.OrderDetails)
				.WithOne(o => o.Order)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<ProductDetailDAL>()
				.HasMany(c => c.OrderDetails)
				.WithOne(o => o.ProductDetail)
				.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<ProductDAL>()
				.HasMany(c => c.OrderDetails)
				.WithOne(o => o.Product)
				.OnDelete(DeleteBehavior.SetNull);
			modelBuilder.Entity<ProductDAL>()
				.HasMany(c => c.Reviews)
				.WithOne(o => o.Product)
				.OnDelete(DeleteBehavior.Cascade);
			modelBuilder.Entity<ProductDAL>()
				.HasMany(c => c.ProductDetails)
				.WithOne(o => o.Product)
				.OnDelete(DeleteBehavior.Cascade);
			modelBuilder.Entity<ProductDAL>()
				.HasMany(c => c.Wishes)
				.WithOne(o => o.Product)
				.OnDelete(DeleteBehavior.SetNull);
			modelBuilder.Entity<ProductDAL>()
				.HasOne(c => c.Category)
				.WithMany(o => o.Products)
				.OnDelete(DeleteBehavior.SetNull);
			modelBuilder.Entity<ProductDAL>()
				.HasOne(c => c.Supplier)
				.WithMany(o => o.Products)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<PaymentDAL>()
				.HasMany(c => c.Suppliers)
				.WithOne(o => o.Payment)
				.OnDelete(DeleteBehavior.SetNull);

			base.OnModelCreating(modelBuilder);
		}

		//entities
		public DbSet<CategoryDAL> Categories { get; set; }
		public DbSet<CustomerDAL> Customers { get; set; }
		public DbSet<OrderDAL> Orders { get; set; }
		public DbSet<OrderDetailDAL> OrderDetails { get; set; }
		public DbSet<PaymentDAL> Payments { get; set; }
		public DbSet<ProductDAL> Products { get; set; }
		public DbSet<ReviewDAL> Reviews { get; set; }
		public DbSet<ShipperDAL> Shippers { get; set; }
		public DbSet<SupplierDAL> Suppliers { get; set; }
		public DbSet<ProductDetailDAL> ProductDetails { get; set; }
		public DbSet<WishDAL> Wishes { get; set; }
	}
}
