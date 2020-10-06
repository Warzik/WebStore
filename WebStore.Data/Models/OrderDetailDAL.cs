using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Data.DataInterfaces;

namespace WebStore.Data.Models
{
	[Table("OrderDetails")]
	public class OrderDetailDAL : IOrderDetailDAL
	{
		[Key]
		public int OrderDetailID { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
        // Price * Quantity * Discount
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }



		//Entity Relation
		public int? ProductID { get; set; }
		public int OrderID { get; set; }
		public ProductDAL Product { get; set; }
		public OrderDAL Order { get; set; }
		public int? ProductDetailID { get ; set ; }
		public ProductDetailDAL ProductDetail { get ; set ; }
	}
}
