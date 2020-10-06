using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Data.Models;

namespace WebStore.Data.DataInterfaces
{
	public interface ICategoryDAL
	{
		public int CategoryID { get; set; }
		public string CategoryName { get; set; }
		public string Description { get; set; }
		public byte[] Picture { get; set; }
		public string Color { get; set; }
		public bool Active { get; set; }

		//Entity Relation

		public int? ParentCategoryId { get; set; }
		public CategoryDAL ParentCategory { get; set; }
		public ICollection<CategoryDAL> ChildrenCategories { get; set; }
		public ICollection<ProductDAL> Products { get; set; }
	}
}
