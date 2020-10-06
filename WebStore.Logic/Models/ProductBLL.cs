using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Logic.DataInterfaces;

namespace WebStore.Logic.Models
{

	public class ProductBLL : IProductBLL
	{

        public int ProductID { get; set; }
		public string UPC { get; set; }
        public string ProductName { get; set; }
		public string ProductFirm { get; set; }
		public float Discount { get; set; }
		public string ProductDescription { get; set; }
        public int QuantityPerUnit { get; set; }
        [Column(TypeName = "decimal(18,2)")]
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
		public virtual ICollection<OrderDetailBLL> OrderDetails { get; set; }
		public virtual ICollection<ReviewBLL> Reviews { get; set; }
		public virtual ICollection<ProductDetailBLL> ProductDetails { get; set; }
		public virtual ICollection<WishBLL> Wishes { get; set; }
	}
}
