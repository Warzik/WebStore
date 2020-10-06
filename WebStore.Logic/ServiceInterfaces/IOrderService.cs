using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebStore.Logic.DataInterfaces;
using WebStore.Logic.Models;

namespace WebStore.Logic.ServiceInterfaces
{
	public interface IOrderService : IService<IOrderBLL>
	{
		Tuple<string[], string[]> DataForSoldPoductsChart(int days);
		Tuple<string[], string[], string[]> DataForSoldPoductsByCtegoriesChart(int days);
		Tuple<string[], string[], string[]> DataForSoldPoductsBySuppliersChart(int days);

		List<IOrderBLL> GetOrdersWithDetails();
		Task<List<IOrderBLL>> GetOrdersWithDetailsAsync();

		IOrderBLL GetOrderByCustomerID(string id);

		IOrderBLL GetOrderWithDetailsProudctAndReviewsByCustomerID(string id);
		Task<IOrderBLL> GetOrderByCustomerIDAsync(string id);

	}
}
