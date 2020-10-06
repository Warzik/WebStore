using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Data.Models;

namespace WebStore.Data.DataInterfaces
{
	public interface IReviewDAL
	{
		public int ReviewID { get; set; }
		public double Stars { get; set; }
		public string Advantages { get; set; }
		public string Disadvantages { get; set; }
		public string Comment { get; set; }
		public string Email { get; set; }
		public DateTime WritingDate { get; set; }


		//Entity Relation
		public int ProductID { get; set; }
		public ProductDAL Product { get; set; }
	}
}
