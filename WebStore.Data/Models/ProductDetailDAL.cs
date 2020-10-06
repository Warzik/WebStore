using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Data.DataInterfaces;

namespace WebStore.Data.Models
{
    [Table("ProductDetails")]
    public class ProductDetailDAL : IProductDetailDAL
    {
        [Key]
        public int ProductDetailID { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
		public string Material { get; set; }
		public byte[] Picture { get; set; }

		//Entity Relation
		public int ProductID { get; set; }
		public ProductDAL Product { get; set; }
		public ICollection<OrderDetailDAL> OrderDetails { get; set; }
	}
}
