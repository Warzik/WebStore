using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Logic.DataInterfaces;
namespace WebStore.Logic.Models
{

	public class ShipperBLL : IShipperBLL
	{

		public int ShipperID { get; set; }
		public string CompanyName { get; set; }
		public string Phone { get; set; }


		//Entity Relation
		public virtual ICollection<OrderBLL> Orders { get; set; }

	}
}
