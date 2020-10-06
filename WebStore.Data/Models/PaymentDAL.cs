using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Data.DataInterfaces;

namespace WebStore.Data.Models
{
	[Table("Payments")]
	public class PaymentDAL : IPaymentDAL
	{
		[Key]
		public int PaymentID { get; set; }
		public string PaymentType { get; set; }
		public bool Allowed { get; set; }

		//Entity Relation
		public virtual ICollection<OrderDAL> Orders { get; set; }
		public virtual ICollection<SupplierDAL> Suppliers { get; set; }
	}
}
