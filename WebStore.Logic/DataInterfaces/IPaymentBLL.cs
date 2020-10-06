using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Logic.Models;
namespace WebStore.Logic.DataInterfaces
{
	public interface IPaymentBLL
	{
		public int PaymentID { get; set; }
		public string PaymentType { get; set; }
		public bool Allowed { get; set; }

		//Entity Relation
		public ICollection<OrderBLL> Orders { get; set; }
		public  ICollection<SupplierBLL> Suppliers { get; set; }
	}
}
