using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataGeneration
{
	public interface IGenerator
	{
		public System.Threading.Tasks.Task GenerateAplicationCustomersAsync(int numberOfCustomers);
		public System.Threading.Tasks.Task GenerateAplicationSuppliersAsync(int numberOfSuppliers);
		public void GenerateCategories();
		public void GenerateOrderDetails(int numberOfOrderDeteils);
		public void GenerateOrders(int numberOfOrders);
		public void GeneratePayments(int numberOfPayment);
		public void GenerateProductDetails(int numberOfProductDetails);
		public void GenerateProducts(int numberOfProducts);
		public void GenerateRewiews(int numberOfReview);
		public void GenerateShippers(int numberOfShippers);
		public void GenerateWhishes(int numberOfWhishes);
	}
}
