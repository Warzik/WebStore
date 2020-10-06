using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Data.Models;
using WebStore.Logic.DataInterfaces;

namespace WebStore.WebApplication.Models
{

	public class Customer 
	{
		public string CustomerID { get; set; }
		[Required]
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string FirstName { get; set; }
		[Required]
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string LastName { get; set; }
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string Room { get; set; }
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string Building { get; set; }
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string Address_1 { get; set; }
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string Address_2 { get; set; }
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string City { get; set; }
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string PostalCode { get; set; }
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string Country { get; set; }
		[Phone]
		public string Phone { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string CreditCard { get; set; }
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string CreditCardTypeID { get; set; }
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string CardExpMo { get; set; }
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string CardExpYr { get; set; }
		public DateTime DateEntered { get; set; }
		public string Password { get; set; }

		//Entity Relation
		public virtual ICollection<Order> Orders { get; set; }
		public virtual ICollection<Wish> Wishes { get; set; }
		public  ApplicationUser ApplicationUser { get; set; }
	}
}
