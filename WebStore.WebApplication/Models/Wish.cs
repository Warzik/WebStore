using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Logic.DataInterfaces;

namespace WebStore.WebApplication.Models
{

	public class Wish
    {
        public int WishID { get; set; }

		//Entity Relation
		public string? CustomerID { get; set; }
		public int? ProductID { get; set; }
		public Customer Customer { get; set; }
		public Product Product { get; set; }
	}
}
