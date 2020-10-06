using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Data.Models;

namespace WebStore.Data.DataInterfaces
{
	public interface IProductDAL
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
		public CategoryDAL Category { get; set; }
		public SupplierDAL Supplier { get; set; }
		public ICollection<OrderDetailDAL> OrderDetails { get; set; }
		public ICollection<ReviewDAL> Reviews { get; set; }
		public ICollection<ProductDetailDAL> ProductDetails { get; set; }
		public ICollection<WishDAL> Wishes { get; set; }
	}
}
