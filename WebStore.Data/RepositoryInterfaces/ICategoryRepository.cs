using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Data.DataInterfaces;

namespace WebStore.Data.RepositoryInterfaces
{
	public interface ICategoryRepository:IRepository<ICategoryDAL>
	{
		IEnumerable<ICategoryDAL> GetAllWithParent();

		IEnumerable<ICategoryDAL> GetAllWithChildrenAndProductsAndReviews();

		IEnumerable<ICategoryDAL> GetParentCategories();
	}
}
