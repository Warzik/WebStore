using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using WebStore.Logic.DataInterfaces;


namespace WebStore.Logic.ServiceInterfaces
{
	public interface ICustomerService
	{
		string Add(ICustomerBLL item);
		Task Delete(string id);
		void Update(ICustomerBLL item);
		ICustomerBLL Get(string id);
		List<ICustomerBLL> GetAll();
		Task<List<ICustomerBLL>> GetAllAsync();
		void AddMany(List<ICustomerBLL> items);

	}
}
