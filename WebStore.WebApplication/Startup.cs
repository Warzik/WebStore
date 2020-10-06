using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebStore.Common;
using WebStore.Data;
using WebStore.Data.Models;
using WebStore.Data.Repositories;
using WebStore.Data.RepositoryInterfaces;
using WebStore.Logic.Services;
using WebStore.Logic.ServiceInterfaces;
using WebStore.WebApplication.Data;
using WebStore.WebApplication.GoogleAnalytics;
using WebStore.WebApplication.Services;

namespace WebStore.WebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddDbContext<WebStoreDataContext>(options =>
				options.UseSqlServer(ConstVal.ConnectionStringDb));

			services.AddDefaultIdentity<ApplicationUser >().AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<WebStoreDataContext>();

			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			services.AddAuthentication()
				.AddGoogle(options =>
				{
					IConfigurationSection googleAuthNSection =
						Configuration.GetSection("Authentication:Google");

					options.ClientId = googleAuthNSection["ClientId"];
					options.ClientSecret = googleAuthNSection["ClientSecret"];
				})
				.AddFacebook(facebookOptions =>
				{
					facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
					facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
				});

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
				options.Password.RequiredLength = 8;
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
			services.ConfigureApplicationCookie(options =>
			{
				options.AccessDeniedPath = "/Identity/Account/AccessDenied";
				options.Cookie.Name = "YourAppCookieName";
				options.Cookie.HttpOnly = true;
				options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
				options.LoginPath = "/Identity/Account/Login";
				// ReturnUrlParameter requires 
				//using Microsoft.AspNetCore.Authentication.Cookies;
				options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
				options.SlidingExpiration = true;
			});

			services.AddRazorPages();
			//services.AddServerSideBlazor();
			services.AddServerSideBlazor().AddHubOptions(o=>o.MaximumReceiveMessageSize= 102400000)
				.AddCircuitOptions(options => { options.DetailedErrors = true; });
				
			services.Configure<GoogleAnalyticsOptions>(options => Configuration.GetSection("GoogleAnalytics").Bind(options));

			//Repositories
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

			//Services
			services.AddTransient<ICategoryService, CategoryService>();
			services.AddTransient<ICustomerService, CustomerService>();
			services.AddTransient<IOrderDetailService, OrderDetailService>();
			services.AddTransient<IOrderService, OrderService>();
			services.AddTransient<IPaymentService, PaymentService>();
			services.AddTransient<IProductDetailService, ProductDetailService>();
			services.AddTransient<IProductService, ProductService>();
			services.AddTransient<IReviewService, ReviewService>();
			services.AddTransient<IShipperService, ShipperService>();
			services.AddTransient<ISupplierService, SupplierService>();
			services.AddTransient<IWishService, WishService>();

			services.AddTransient<ITagHelperComponent, GoogleAnalyticsTagHelperComponent>();
			services.AddTransient<IEmailSender, EmailSender>();


			services.AddScoped<DataNotificationService>();
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {

			if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

			//Logger
			loggerFactory.AddFile("Logs/mylog-{Date}.txt");

			app.UseHttpsRedirection();
            app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapBlazorHub();
				endpoints.MapFallbackToPage("/_Host");
			});
		}
    }
}
