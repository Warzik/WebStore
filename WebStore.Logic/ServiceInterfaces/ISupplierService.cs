using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebStore.Logic.DataInterfaces;


namespace WebStore.Logic.ServiceInterfaces
{
	public interface ISupplierService
	{
		string Add(ISupplierBLL item);
		Task Delete(string id);
		void Update(ISupplierBLL item);
		ISupplierBLL Get(string id);
		List<ISupplierBLL> GetAll();
		void AddMany(List<ISupplierBLL> items);

		Task<List<ISupplierBLL>> GetAllAsync();
	}
}
