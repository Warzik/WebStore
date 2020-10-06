using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebStore.Logic.DataInterfaces;


namespace WebStore.Logic.ServiceInterfaces
{
	public interface IProductDetailService : IService<IProductDetailBLL>
	{
		List<IProductDetailBLL> GetProductDetailsByProductID(int id);
		Task<List<IProductDetailBLL>> GetProductDetailsByProductIDAsync(int id);
	}
}
