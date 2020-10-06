using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebStore.Data.DataInterfaces;

namespace WebStore.Data.RepositoryInterfaces
{
	public interface ISupplierRepository
	{
		string Add(ISupplierDAL item);
		void AddMany(IEnumerable<ISupplierDAL> items);
		Task Delete(string id);
		ISupplierDAL Get(string id);
		IEnumerable<ISupplierDAL> GetAll();
		void Update(ISupplierDAL item);
	}
}
