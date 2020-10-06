using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Logic.DataInterfaces;

namespace WebStore.WebApplication.Models
{

	public class Product 
	{

        public int ProductID { get; set; }
		[Required]
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string UPC { get; set; }
		[Required]
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string ProductName { get; set; }
		[Required]
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string ProductFirm { get; set; }
		[Required]
		public float Discount { get; set; }
		[Required]
		[StringLength(1000, ErrorMessage = "Identifier too long (1000 character limit).")]
		public string ProductDescription { get; set; }
		[Required]
		public int QuantityPerUnit { get; set; }
		[Required]
		public decimal UnitPrice { get; set; }
		[Required]
		public int UnitsInStock { get; set; }
		[Required]
		public int UnitsOnOrder { get; set; }
		[Required]
		public int ReorderLevel { get; set; }
		[Required]
		public bool ProductAvailable { get; set; }
		
		[Required]
		[StringLength(1000, ErrorMessage = "Identifier too long (1000 character limit).")]
		public string Note { get; set; }
		public int? CategoryID { get; set; }
		public string? SupplierID { get; set; }
		public byte[] MainPicture { get; set; }




		public Category Category { get; set; }
		public Supplier Supplier { get; set; }
		public virtual ICollection<OrderDetail> OrderDetails { get; set; }
		public virtual ICollection<Review> Reviews { get; set; }
		public virtual ICollection<ProductDetail> ProductDetails { get; set; }
		public virtual ICollection<Wish> Wishes { get; set; }
	}
}
