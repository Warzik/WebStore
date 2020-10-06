using System;
using System.Collections.Generic;
using System.Text;

using WebStore.Logic.Models;

namespace WebStore.Logic.DataInterfaces
{
	public interface ICategoryBLL
	{
		public int CategoryID { get; set; }
		public string CategoryName { get; set; }
		public string Description { get; set; }
		public byte[] Picture { get; set; }
		public string Color { get; set; }
		public bool Active { get; set; }

		//Entity Relation

		public int? ParentCategoryId { get; set; }
		public CategoryBLL ParentCategory { get; set; }
		public  ICollection<CategoryBLL> ChildrenCategories { get; set; }
		public ICollection<ProductBLL> Products { get; set; }
	}
}
