using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Logic.Models;

namespace WebStore.Logic.DataInterfaces
{
    public interface IWishBLL
    {
		public int WishID { get; set; }



		//Entity Relation
		public string? CustomerID { get; set; }
		public CustomerBLL Customer { get; set; }
		public int? ProductID { get; set; }
		public ProductBLL Product { get; set; }
	}
}
