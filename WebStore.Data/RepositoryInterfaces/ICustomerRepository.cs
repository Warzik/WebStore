using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebStore.Data.DataInterfaces;

namespace WebStore.Data.RepositoryInterfaces
{
	public interface ICustomerRepository 
	{
		string Add(ICustomerDAL item);
		void AddMany(IEnumerable<ICustomerDAL> items);
		Task Delete(string id);
		ICustomerDAL Get(string id);
		IEnumerable<ICustomerDAL> GetAll();
		void Update(ICustomerDAL item);

	}
}
