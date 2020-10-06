using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebStore.Logic.DataInterfaces;


namespace WebStore.Logic.ServiceInterfaces
{
	public interface IWishService : IService<IWishBLL>
	{
		Task<int> AddAsync(IWishBLL item);
		void DeleteByProductAndCustomerIDs(int productID, string customerID);
		Task DeleteByProductAndCustomerIDsAsync(int productID, string customerID);

		List<IWishBLL> GetAllByCustomerID(string customerID);
		Task<List<IWishBLL>> GetAllByCustomerIDAsync(string customerID);

		List<IWishBLL> GetAllWithProductsByCustomerID(string customerID);

		List<IWishBLL>  GetAllWithProductsAndReviewsByCustomerID(string customerID);
		Task<List<IWishBLL>> GetAllWithProductsByCustomerIDAsync(string customerID);

		IWishBLL GetByProductAndCustomerID(int productID, string customerID);
	}
}
