using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Logic.DataInterfaces;

namespace WebStore.Logic.Models
{

	public class OrderDetailBLL : IOrderDetailBLL
	{

		public int OrderDetailID { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }


		//Entity Relation
		public int? ProductID { get; set; }
		public int OrderID { get; set; }
		public ProductBLL Product { get; set; }
		public OrderBLL Order { get; set; }
		public int? ProductDetailID { get; set; }
		public ProductDetailBLL ProductDetail { get ; set; }
	}
}
