using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Data.Models;

namespace WebStore.Data.DataInterfaces
{
	public interface IPaymentDAL
	{
		public int PaymentID { get; set; }
		public string PaymentType { get; set; }
		public bool Allowed { get; set; }

		//Entity Relation
		public ICollection<OrderDAL> Orders { get; set; }
		public  ICollection<SupplierDAL> Suppliers { get; set; }
	}
}
