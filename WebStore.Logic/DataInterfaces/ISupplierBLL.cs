using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Data.Models;
using WebStore.Logic.Models;
namespace WebStore.Logic.DataInterfaces
{
    public interface ISupplierBLL
	{
		public string SupplierID { get; set; }
		public string CompanyName { get; set; }
		public string ContactFName { get; set; }
		public string ContactLName { get; set; }
		public string ContactTitle { get; set; }
		public string Address_1 { get; set; }
		public string Address_2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string PostalCode { get; set; }
		public string Country { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string URL { get; set; }
		public byte[] Logo { get; set; }
		public string Notes { get; set; }
		public string Color { get; set; }


		//Entity Relation
		public int? PaymentID { get; set; }
		public ICollection<ProductBLL> Products { get; set; }
		public PaymentBLL Payment { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
	}
}
