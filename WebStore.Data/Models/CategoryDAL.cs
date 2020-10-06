using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Data.DataInterfaces;

namespace WebStore.Data.Models
{
	[Table("Categories")]
	public class CategoryDAL : ICategoryDAL
	{
		[Key]
		public int CategoryID { get; set; }
		public string CategoryName { get; set; }
		public string Description { get; set; }
		public byte[] Picture { get; set; }
		public string Color { get; set; }
		public bool Active { get; set; }

		//Entity Relation
		public int? ParentCategoryId { get; set; }

		[ForeignKey("ParentCategoryId")]
		public CategoryDAL ParentCategory { get; set; }
		public virtual ICollection<CategoryDAL> ChildrenCategories { get; set; }
		public virtual ICollection<ProductDAL> Products { get; set; }
	}
}
