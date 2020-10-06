using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebStore.Data;
using WebStore.Data.Models;
using WebStore.WebApplication.Data;

namespace WebStore.WebApplication
{
    public class Program
    {

		public static void Main(string[] args)
		{
			var host = BuildWebHost(args);
			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				try
				{
					var context = services.GetRequiredService<WebStoreDataContext>();
					var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
					var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

					var dbInitializerLogger = services.GetRequiredService<ILogger<Program>>();
					DbUserSeeder.Initialize(context, userManager, roleManager, dbInitializerLogger).Wait();
				}
				catch (Exception ex)
				{
					var logger = services.GetRequiredService<ILogger<Program>>();
					logger.LogError(ex, "An error occurred while seeding the database.");
				}
			}
			host.Run();

		}

		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
			.UseEnvironment(Environments.Development)//Development
			.UseSetting(WebHostDefaults.DetailedErrorsKey, "true")//Development
			.ConfigureLogging(logging =>
			{
				logging.ClearProviders();
				logging.AddConsole();
				logging.AddDebug();
				logging.AddEventLog();
				logging.AddEventSourceLogger();

			})
				.UseStartup<Startup>()
				.Build();
	}
}
