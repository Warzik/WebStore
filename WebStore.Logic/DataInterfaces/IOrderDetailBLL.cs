using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Logic.Models;

namespace WebStore.Logic.DataInterfaces
{
	public interface IOrderDetailBLL
	{
		public int OrderDetailID { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
		public float Discount { get; set; }
		//Price * Quantity * Discount
		public decimal Total { get; set; }


		//Entity Relation
		public int? ProductDetailID { get; set; }
		public ProductDetailBLL ProductDetail { get; set; }
		public int? ProductID { get; set; }
		public ProductBLL Product { get; set; }
		public int OrderID { get; set; }
		public OrderBLL Order { get; set; }
	}
}
