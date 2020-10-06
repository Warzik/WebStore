using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Data.DataInterfaces;

namespace WebStore.Data.Models
{
    [Table("Orders")]
	public class OrderDAL : IOrderDAL
	{
		[Key]
        public int OrderID { get; set; }
		public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public bool Fulfilled { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Paid { get; set; }
		public DateTime PaymentDate { get; set; }


		//Entity Relation
		public string? CustomerID { get; set; }
		public int? ShipperID { get; set; }
		public int? PaymentID { get; set; }
		public  CustomerDAL Customer { get; set; }
		public ShipperDAL Shipper { get; set; }
		public PaymentDAL Payment { get; set; }
		public virtual ICollection<OrderDetailDAL> OrderDetails { get; set; }
	}
}
