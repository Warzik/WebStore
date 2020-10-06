using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Logic.DataInterfaces;

namespace WebStore.Logic.Models
{

	public class WishBLL: IWishBLL
    {
        public int WishID { get; set; }

		//Entity Relation
		public string? CustomerID { get; set; }
		public int? ProductID { get; set; }
		public CustomerBLL Customer { get; set; }
		public ProductBLL Product { get; set; }
	}
}
