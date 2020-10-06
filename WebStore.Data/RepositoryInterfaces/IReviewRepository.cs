using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Data.DataInterfaces;

namespace WebStore.Data.RepositoryInterfaces
{
	public interface IReviewRepository : IRepository<IReviewDAL>
	{
		IEnumerable<IReviewDAL> GetAllByProductID(int id);
	}
}
