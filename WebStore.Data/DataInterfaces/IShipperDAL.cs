using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Data.Models;

namespace WebStore.Data.DataInterfaces
{
	public interface IShipperDAL
	{
		public int ShipperID { get; set; }
		public string CompanyName { get; set; }
		public string Phone { get; set; }


		//Entity Relation
		public ICollection<OrderDAL> Orders { get; set; }
	}
}
