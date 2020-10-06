using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Data.Models;

namespace WebStore.Data.DataInterfaces
{
    public interface IOrderDAL
	{
		public int OrderID { get; set; }
		public DateTime OrderDate { get; set; }
		public DateTime ShipDate { get; set; }
		public DateTime RequiredDate { get; set; }
		public bool Fulfilled { get; set; }
		public decimal Paid { get; set; }
		public DateTime PaymentDate { get; set; }


		//Entity Relation

		public string? CustomerID { get; set; }
		public int? ShipperID { get; set; }
		public int? PaymentID { get; set; }
		public ICollection<OrderDetailDAL> OrderDetails { get; set; }
		public CustomerDAL Customer { get; set; }
		public ShipperDAL Shipper { get; set; }
		public PaymentDAL Payment { get; set; }
	}
}
