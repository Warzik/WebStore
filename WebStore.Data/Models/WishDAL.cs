using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Data.DataInterfaces;

namespace WebStore.Data.Models
{
	[Table("Wishes")]
	public class WishDAL: IWishDAL
    {
		[Key]
        public int WishID { get; set; }

		//Entity Relation
		public string? CustomerID { get; set; }
		public int? ProductID { get; set; }
		public CustomerDAL Customer { get; set; }
		public ProductDAL Product { get; set; }
	}
}
