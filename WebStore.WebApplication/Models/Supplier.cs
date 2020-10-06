using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Data.Models;
using WebStore.Logic.DataInterfaces;

namespace WebStore.WebApplication.Models
{
	public class Supplier 
	{
		public string SupplierID { get; set; }
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		[Required]
		public string CompanyName { get; set; }
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string ContactFName { get; set; }
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string ContactLName { get; set; }
		[StringLength(1000, ErrorMessage = "Identifier too long (1000 character limit).")]
		public string ContactTitle { get; set; }
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string Address_1 { get; set; }
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string Address_2 { get; set; }
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string City { get; set; }
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string State { get; set; }
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string PostalCode { get; set; }
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string Country { get; set; }
		[Phone]
		public string Phone { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Url]
		public string URL { get; set; }
       
		[StringLength(5000, ErrorMessage = "Identifier too long (5000 character limit).")]
		// 	Notes on the Supplier
		public string Notes { get; set; }
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string Color { get; set; }

		public int? PaymentID { get; set; }

		public string Password { get; set; }
		// byte suppliers image
		public byte[] Logo { get; set; }


		//Entity Relation

		public Payment Payment { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
		public virtual ICollection<Product> Products { get; set; }
	}
}
