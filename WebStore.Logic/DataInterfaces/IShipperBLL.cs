using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Logic.Models;

namespace WebStore.Logic.DataInterfaces
{
	public interface IShipperBLL
	{
		public int ShipperID { get; set; }
		public string CompanyName { get; set; }
		public string Phone { get; set; }


		//Entity Relation
		public ICollection<OrderBLL> Orders { get; set; }
	}
}
