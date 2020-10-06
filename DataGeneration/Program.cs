using Microsoft.Extensions.DependencyInjection;
using System;
using WebStore.Data.RepositoryInterfaces;
using WebStore.Data.Repositories;
using WebStore.Data;
using WebStore.Data.Models;
using Microsoft.AspNetCore.Identity;
using WebStore.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AutoMapper;

namespace DataGeneration
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var services = new ServiceCollection();

			services.AddDbContext<WebStoreDataContext>(options =>
				options.UseSqlServer(ConstVal.ConnectionStringDb));

			services.AddIdentityCore<ApplicationUser>().AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<WebStoreDataContext>();

			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


			services.Configure<IdentityOptions>(options =>
			{
				// Default Lockout settings.
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				options.Lockout.MaxFailedAccessAttempts = 5;
				options.Lockout.AllowedForNewUsers = true;

				// Default Password settings.
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequireUppercase = true;
				options.Password.RequiredLength = 6;
				options.Password.RequiredUniqueChars = 1;

				// Default SignIn settings.
				options.SignIn.RequireConfirmedAccount = true;
				options.SignIn.RequireConfirmedEmail = true;
				options.SignIn.RequireConfirmedPhoneNumber = false;

				// Default User settings.
				options.User.AllowedUserNameCharacters =
						"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
				options.User.RequireUniqueEmail = false;

			});

			services.AddTransient<ICategoryRepository, CategoryRepository>();
			services.AddTransient<ICustomerRepository, CustomerRepository>();
			services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
			services.AddTransient<IOrderRepository, OrderRepository>();
			services.AddTransient<IPaymentRepository, PaymentRepository>();
			services.AddTransient<IProductDetailRepository, ProductDetailRepository>();
			services.AddTransient<IProductRepository, ProductRepository>();
			services.AddTransient<IReviewRepository, ReviewRepository>();
			services.AddTransient<IShipperRepository, ShipperRepository>();
			services.AddTransient<ISupplierRepository, SupplierRepository>();
			services.AddTransient<IWishRepository, WishRepository>();
			services.AddTransient<IGenerator, Generator>();
			// create a service provider from the service collection
			services.AddSingleton(new DesignTimeDbContextFactory().CreateDbContext(new[] { "" }));
			var serviceProvider = services.BuildServiceProvider();


			// resolve the dependency graph
			var generatorService = serviceProvider.GetService<IGenerator>();

			await generatorService.GenerateAplicationCustomersAsync(60);
			generatorService.GeneratePayments(5);
			await generatorService.GenerateAplicationSuppliersAsync(10);
			generatorService.GenerateCategories();
			generatorService.GenerateProducts(1000);
			generatorService.GenerateProductDetails(2200);
			generatorService.GenerateWhishes(1800);
			generatorService.GenerateRewiews(2200);
			generatorService.GenerateShippers(5);
			generatorService.GenerateOrders(500);
			generatorService.GenerateOrderDetails(1600);

			Console.WriteLine("Done");
			Console.ReadKey();

		}
	}
}
