﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Data.DataInterfaces;

namespace WebStore.Data.Models
{
	[Table("Customers")]
	public class CustomerDAL : ICustomerDAL
	{
		[Key]
		[ForeignKey("ApplicationUser")]
		public string CustomerID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Room { get; set; }
		public string Building { get; set; }
		public string Address_1 { get; set; }
		public string Address_2 { get; set; }
		public string City { get; set; }
		public string PostalCode { get; set; }
		public string Country { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string CreditCard { get; set; }
		public string CreditCardTypeID { get; set; }
		public string CardExpMo { get; set; }
		public string CardExpYr { get; set; }
		public DateTime DateEntered { get; set; }


		//Entity Relation
		public virtual ICollection<OrderDAL> Orders { get; set; }
		public virtual ICollection<WishDAL> Wishes { get; set; }
		public  ApplicationUser ApplicationUser { get; set; }
	}
}
