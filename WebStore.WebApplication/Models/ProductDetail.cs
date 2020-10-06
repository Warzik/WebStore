using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Logic.DataInterfaces;

namespace WebStore.WebApplication.Models
{

    public class ProductDetail 
    {

        public int ProductDetailID { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
		public string Material { get; set; }
		public byte[] Picture { get; set; }

		//Entity Relation
		public int ProductID { get; set; }
		public Product Product { get; set; }

		public ICollection<OrderDetail> OrderDetails { get; set; }
	}
}
