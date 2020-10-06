using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Logic.Models;
namespace WebStore.Logic.DataInterfaces
{
    public interface IOrderBLL
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
		public ICollection<OrderDetailBLL> OrderDetails { get; set; }
		public CustomerBLL Customer { get; set; }
		public ShipperBLL Shipper { get; set; }
		public PaymentBLL Payment { get; set; }
	}
}
