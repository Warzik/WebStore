using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebStore.Logic.DataInterfaces;


namespace WebStore.Logic.ServiceInterfaces
{
	public interface IProductService : IService<IProductBLL>
	{
		List<IProductBLL> GetProductsWithDetailsAndReviews();
		Task<List<IProductBLL>> GetProductsWithDetailsAndReviewsAsync();
		Task<List<IProductBLL>> GetProductsAsync();
		List<IProductBLL> GetProductsBySupplierID(string id);
		Task<List<IProductBLL>> GetProductsBySupplierIDAsync(string id);
		List<IProductBLL> GetProductsWithReviews();
		Task<List<IProductBLL>> GetProductsWithReviewsAsync();

		List<IProductBLL> GetTopSelesWithReviews();
		Task<List<IProductBLL>> GetTopSelesWithReviewsAsync();

		List<IProductBLL> GetTopCommentsWhitReviews();
		Task<List<IProductBLL>> GetTopCommentsWhitReviewsAsync();

		List<IProductBLL> GetByProductFirm(string productFirm);
		Task<List<IProductBLL>> GetByProductFirmAsync(string productFirm);
		

		IProductBLL GetWithProductDetailsAndReviewsByProductID(int id);
	}
}
