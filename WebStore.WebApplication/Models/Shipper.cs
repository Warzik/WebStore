using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Logic.DataInterfaces;

namespace WebStore.WebApplication.Models
{

	public class Shipper
	{

		public int ShipperID { get; set; }
		[StringLength(200, ErrorMessage = "Identifier too long (200 character limit).")]
		public string CompanyName { get; set; }
		[Phone]
		public string Phone { get; set; }


		//Entity Relation
		public virtual ICollection<Order> Orders { get; set; }

	}
}
