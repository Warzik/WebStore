using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Data.DataInterfaces;

namespace WebStore.Data.RepositoryInterfaces
{
	public interface IOrderRepository : IRepository<IOrderDAL>
	{
		IEnumerable<IOrderDAL> GetOrdersByDateTime(DateTime dateTime);
		IEnumerable<IOrderDAL> GetOrdersWithProductCategoryByDateTime(DateTime dateTime);
		IEnumerable<IOrderDAL> GetOrdersWithProductSupplierByDateTime(DateTime dateTime);
		IEnumerable<IOrderDAL> GetOrdersWithDetails();
		IOrderDAL GetOrderByCustomerID(string id);
		IOrderDAL GetOrderWithDetailsProudctAndReviewsByCustomerID(string id);
	}
}
