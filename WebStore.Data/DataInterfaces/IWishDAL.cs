using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Data.Models;

namespace WebStore.Data.DataInterfaces
{
    public interface IWishDAL
    {
		public int WishID { get; set; }



		//Entity Relation
		public string? CustomerID { get; set; }
		public int? ProductID { get; set; }
		public CustomerDAL Customer { get; set; }
	
		public ProductDAL Product { get; set; }
	}
}
