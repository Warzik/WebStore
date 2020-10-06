using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Logic.DataInterfaces;

namespace WebStore.WebApplication.Models
{

	public class Review 
	{

		public int ReviewID { get; set ; }
		[Required]
		[Range(1, 5, ErrorMessage = "Please rate the product.")]
		public double Stars { get; set; }
		[Required]
		[StringLength(500, ErrorMessage = "Identifier too long (500 character limit).")]
		public string Advantages { get; set; }
		[Required]
		[StringLength(500, ErrorMessage = "Identifier too long (500 character limit).")]
		public string Disadvantages { get; set; }
		[Required]
		[StringLength(2000, ErrorMessage = "Identifier too long (2000 character limit).")]
		public string Comment { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		public DateTime WritingDate { get; set; }

		//Entity Relation
		public int ProductID { get; set; }
		public Product Product { get; set; }
	}
}
