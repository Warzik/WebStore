using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Logic.Models;

namespace WebStore.Logic.DataInterfaces
{
	public interface IReviewBLL
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
		public ProductBLL Product { get; set; }
	}
}
