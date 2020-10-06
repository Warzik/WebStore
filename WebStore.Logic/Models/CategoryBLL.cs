using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Logic.DataInterfaces;


namespace WebStore.Logic.Models
{
	public class CategoryBLL : ICategoryBLL
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
		public virtual ICollection<CategoryBLL> ChildrenCategories { get; set; }
		public virtual ICollection<ProductBLL> Products { get; set; }
	}
}
