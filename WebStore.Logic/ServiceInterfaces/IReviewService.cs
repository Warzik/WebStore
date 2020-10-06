using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebStore.Logic.DataInterfaces;


namespace WebStore.Logic.ServiceInterfaces
{
	public interface IReviewService : IService<IReviewBLL>
	{
		List<IReviewBLL> GetReviewsByProductID(int id);
		Task<List<IReviewBLL>> GetReviewsByProductIDAsync(int id);
	}
}
