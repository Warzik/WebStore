using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Logic.DataInterfaces;

namespace WebStore.Logic.Models
{

	public class PaymentBLL : IPaymentBLL
	{

		public int PaymentID { get; set; }
		public string PaymentType { get; set; }
		public bool Allowed { get; set; }

		//Entity Relation
		public virtual ICollection<OrderBLL> Orders { get; set; }
		public virtual ICollection<SupplierBLL> Suppliers { get; set; }
	}
}
