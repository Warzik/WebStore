using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Data.Models;
using WebStore.Logic.Models;

namespace WebStore.Logic.DataInterfaces
{
    public interface IProductDetailBLL
    {
		public int ProductDetailID { get; set; }
		public string Color { get; set; }
		public string Size { get; set; }
		public string Material { get; set; }
		public byte[] Picture { get; set; }

		//Entity Relation
		public int ProductID { get; set; }
		public ProductBLL Product { get; set; }
		public ICollection<OrderDetailBLL> OrderDetails { get; set; }
	}
}
