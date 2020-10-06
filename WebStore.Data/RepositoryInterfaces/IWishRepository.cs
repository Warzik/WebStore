using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Data.DataInterfaces;

namespace WebStore.Data.RepositoryInterfaces
{
    public interface IWishRepository : IRepository<IWishDAL>
    {
		void DeleteByProductAndCustomerIDs(int productID, string customerID);
		IEnumerable<IWishDAL> GetAllByCustomerID(string customerID);
		IEnumerable<IWishDAL> GetAllWithProductsByCustomerID(string customerID);
		IEnumerable<IWishDAL> GetAllWithProductsAndReviewsByCustomerID(string customerID);
		IWishDAL GetByProductAndCustomerID(int productID, string customerID);
	}
}
