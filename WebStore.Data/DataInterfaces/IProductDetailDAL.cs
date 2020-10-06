using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Data.Models;

namespace WebStore.Data.DataInterfaces
{
    public interface IProductDetailDAL
    {
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
