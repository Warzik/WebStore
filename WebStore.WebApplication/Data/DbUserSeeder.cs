
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Common;
using WebStore.Data;
using WebStore.Data.Models;

namespace WebStore.WebApplication.Data
{
    public class DbUserSeeder
    {
        public static async Task Initialize(WebStoreDataContext context, UserManager<ApplicationUser> userManager,
       RoleManager<IdentityRole> roleManager, ILogger logger)
        {
            context.Database.EnsureCreated();

			if (context.Roles.FirstOrDefault(p=>p.Name== "Administrator")!=null)
            {
                return;
            }

            await CreateDefaultUserAndRoleForApplication(userManager, roleManager, logger);
        }

        private static async Task CreateDefaultUserAndRoleForApplication(UserManager<ApplicationUser> um, RoleManager<IdentityRole> rm, ILogger logger)
        {
            const string administratorRole = "Administrator";
            const string userName = ConstVal.AdminEmail;

            await CreateDefaultAdministratorRole(rm, logger, administratorRole);
            var user = await CreateDefaultUser(um, logger, userName);
            await SetPasswordForDefaultUser(um, logger, userName, user);
            await AddDefaultRoleToDefaultUser(um, logger, userName, administratorRole, user);

			string code = await um.GenerateEmailConfirmationTokenAsync(user);
			await um.ConfirmEmailAsync(user, code);



		}

			private static async Task CreateDefaultAdministratorRole(RoleManager<IdentityRole> rm, ILogger logger, string administratorRole)
        {

            var ir = await rm.CreateAsync(new IdentityRole(administratorRole));
            if (ir.Succeeded)
            {
                logger.LogInformation($"Created the role `{administratorRole}` successfully");
            }
            else
            {
                var exception = new ApplicationException($"Default role `{administratorRole}` cannot be created");
                logger.LogError(exception+"");
                throw exception;
            }
        }

        private static async Task<ApplicationUser> CreateDefaultUser(UserManager<ApplicationUser> um, ILogger logger, string userName)
        {

            var user = new ApplicationUser() { UserName = userName, Email=userName , EmailConfirmed=true};

            var ir = await um.CreateAsync(user);
            if (ir.Succeeded)
            {
                logger.LogInformation($"Created default user `{userName}` successfully");
            }
            else
            {
                var exception = new ApplicationException($"Default user `{userName}` cannot be created");
                logger.LogError(exception+"");
                throw exception;
            }

            var createdUser = await um.FindByNameAsync(userName);
            return createdUser;
        }

        private static async Task SetPasswordForDefaultUser(UserManager<ApplicationUser> um, ILogger logger, string userName, ApplicationUser user)
        {

            const string password = ConstVal.AdminPassword;
            var ir = await um.AddPasswordAsync(user, password);
            if (ir.Succeeded)
            {
                logger.LogInformation($"SPassword for default user `{userName}` successfully");
            }
            else
            {
                var exception = new ApplicationException($"Password for the user `{userName}` cannot be set");
                logger.LogError(exception+"");
                throw exception;
            }
        }

        private static async Task AddDefaultRoleToDefaultUser(UserManager<ApplicationUser> um, ILogger logger, string userName, string administratorRole, ApplicationUser user)
        {

            var ir = await um.AddToRoleAsync(user, administratorRole);
            if (ir.Succeeded)
            {
                logger.LogInformation($"Added the role '{administratorRole}' to default user `{userName}` successfully");
            }
            else
            {
                var exception = new ApplicationException($"The role `{administratorRole}` cannot be set for the user `{userName}`");
                logger.LogError(exception+"");
                throw exception;
            }
        }

        private static string GetIdentiryErrorsInCommaSeperatedList(IdentityResult ir)
        {
            string errors = null;
            foreach (var identityError in ir.Errors)
            {
                errors += identityError.Description;
                errors += ", ";
            }
            return errors;
        }
    }
}

