using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Logic.DataInterfaces;

namespace WebStore.WebApplication.Models
{

	public class OrderDetail 
	{

		public int OrderDetailID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
        public decimal Total { get; set; }


		//Entity Relation
		public int? ProductID { get; set; }
		public int OrderID { get; set; }
		public int? ProductDetailID { get; set; }
		public ProductDetail ProductDetail { get; set; }
		public Product Product { get; set; }
		public Order Order { get; set; }
	}
}
