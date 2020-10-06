using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Logic.DataInterfaces;

namespace WebStore.WebApplication.Models
{

	public class Payment 
	{

		public int PaymentID { get; set; }
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string PaymentType { get; set; }

		public bool Allowed { get; set; }

		//Entity Relation
		public virtual ICollection<Order> Orders { get; set; }
		public virtual ICollection<Supplier> Suppliers { get; set; }
	}
}
