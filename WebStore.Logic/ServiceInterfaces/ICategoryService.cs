using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebStore.Logic.DataInterfaces;

namespace WebStore.Logic.ServiceInterfaces
{
	public interface ICategoryService:IService<ICategoryBLL>
	{
		Task<List<ICategoryBLL>> GetAllAsync();
		List<ICategoryBLL> GetAllWithParent();
		Task<List<ICategoryBLL>> GetAllWithParentAsync();

		List<ICategoryBLL> GetAllWithChildrenAndProductsAndReviews();
		Task<List<ICategoryBLL>> GetAllWithChildrenAndProductsAndReviewsAsync();
	}
}
