using System;
using System.Collections.Generic;
using WebStore.Logic.Models;

namespace WebStore.Logic.DataInterfaces
{
	public interface IProductBLL
	{
		public int ProductID { get; set; }
		public string UPC { get; set; }
		public string ProductName { get; set; }
		public string ProductFirm { get; set; }
		public float Discount { get; set; }
		public string ProductDescription { get; set; }
		public int QuantityPerUnit { get; set; }
		public decimal UnitPrice { get; set; }
		public int UnitsInStock { get; set; }
		public int UnitsOnOrder { get; set; }
		public int ReorderLevel { get; set; }
		public bool ProductAvailable { get; set; }
		public byte[] MainPicture { get; set; }
		public string Note { get; set; }



		//Entity Relation

		public int? CategoryID { get; set; }
		public string? SupplierID { get; set; }
		public CategoryBLL Category { get; set; }
		public SupplierBLL Supplier { get; set; }
		public ICollection<OrderDetailBLL> OrderDetails { get; set; }
		public ICollection<ReviewBLL> Reviews { get; set; }
		public ICollection<ProductDetailBLL> ProductDetails { get; set; }
		public ICollection<WishBLL> Wishes { get; set; }
	}
}
