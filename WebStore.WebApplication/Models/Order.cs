using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Logic.DataInterfaces;

namespace WebStore.WebApplication.Models
{


	public class Order 
	{

        public int OrderID { get; set; }
		[Required]
		public DateTime OrderDate { get; set; }
		public DateTime ShipDate { get; set; }
		public DateTime RequiredDate { get; set; }
        public bool Fulfilled { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Paid { get; set; }
		[Required]
		public DateTime PaymentDate { get; set; }


		//Entity Relation
		public string? CustomerID { get; set; }
		public int? ShipperID { get; set; }
		public int? PaymentID { get; set; }
		public  Customer Customer { get; set; }
		public Shipper Shipper { get; set; }
		public Payment Payment { get; set; }
		public virtual ICollection<OrderDetail> OrderDetails { get; set; }
	}
}
