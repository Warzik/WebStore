using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Data.DataInterfaces;

namespace WebStore.Data.RepositoryInterfaces
{
	public interface IProductRepository: IRepository<IProductDAL>
	{
		IEnumerable<IProductDAL> GetAllWithDetailsAndReviews();
		IEnumerable<IProductDAL> GetAllBySupplierID(string id);
		IEnumerable<IProductDAL> GetAllWithReviews();

		IEnumerable<IProductDAL> GetTopSalesWithReviews();
		IEnumerable<IProductDAL> GetTopCommentsWithReviews();

		IEnumerable<IProductDAL> GetByProductFirm(string productFirm);


		IProductDAL GetWithProductDetailsAndReviewsByProductID(int id);
	}
}
