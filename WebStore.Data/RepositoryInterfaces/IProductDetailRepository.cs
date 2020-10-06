using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Data.DataInterfaces;
using WebStore.Data.Models;

namespace WebStore.Data.RepositoryInterfaces
{
    public interface IProductDetailRepository: IRepository<IProductDetailDAL>
    {
		IEnumerable<IProductDetailDAL> GetAllByProductID(int id);
	}
}
