using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Data.Models;

namespace WebStore.Data.DataInterfaces
{
	public interface ICustomerDAL
	{
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
		public ICollection<OrderDAL> Orders { get; set; }
		public ICollection<WishDAL> Wishes { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
	}
}
