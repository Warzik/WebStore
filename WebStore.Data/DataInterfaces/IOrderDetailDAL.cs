using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Data.Models;

namespace WebStore.Data.DataInterfaces
{
	public interface IOrderDetailDAL
	{
		public int OrderDetailID { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
		public float Discount { get; set; }
		// Price * Quantity * Discount
		public decimal Total { get; set; }



		//Entity Relation
		public int? ProductID { get; set; }
		public ProductDAL Product { get; set; }
		public int? ProductDetailID { get; set; }
		public ProductDetailDAL ProductDetail { get; set; }
		public int OrderID { get; set; }
		public OrderDAL Order { get; set; }
	}
}
