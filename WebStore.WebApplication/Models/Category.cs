using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Logic.DataInterfaces;


namespace WebStore.WebApplication.Models
{
	public class Category
	{

		public int CategoryID { get; set; }
		[Required]
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string CategoryName { get; set; }
		[Required]
		[StringLength(5000, ErrorMessage = "Identifier too long (5000 character limit).")]
		public string Description { get; set; }
		
		[Required]
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string Color { get; set; }
		public bool Active { get; set; }
		public int? ParentCategoryId { get; set; }


		//Entity Relation


		public byte[] Picture { get; set; }
		public Category ParentCategory { get; set; }
		public virtual ICollection<Category> ChildrenCategories { get; set; }
		public virtual ICollection<Product> Products { get; set; }
	}
}
