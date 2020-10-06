using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Data.DataInterfaces;

namespace WebStore.Data.Models
{
	[Table("Shippers")]
	public class ShipperDAL : IShipperDAL
	{
		[Key]
		public int ShipperID { get; set; }
		public string CompanyName { get; set; }
		public string Phone { get; set; }


		//Entity Relation
		public virtual ICollection<OrderDAL> Orders { get; set; }

	}
}
