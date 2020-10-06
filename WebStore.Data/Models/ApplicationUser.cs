
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Data.Models { 
	// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
    {
		public CustomerDAL  Customer { get; set; }
		public SupplierDAL Supplier { get; set; }
	}
}

