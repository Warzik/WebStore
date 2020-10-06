using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data.Models;
using WebStore.Data.RepositoryInterfaces;
using WebStore.Logic.DataInterfaces;
using WebStore.Logic.Models;
using WebStore.Logic.ServiceInterfaces;

namespace WebStore.Logic.Services
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepository;
		private readonly ICategoryRepository _categoryRepository;
		private readonly ISupplierRepository _supplierRepository;
		private readonly IMapper _mapper;
		public OrderService(IOrderRepository orderRepository, ICategoryRepository categoryRepository,
			ISupplierRepository supplierRepository, IMapper mapper)
		{
			_orderRepository = orderRepository;
			_categoryRepository = categoryRepository;
			_supplierRepository = supplierRepository;
			_mapper = mapper;
		}
		public int Add(IOrderBLL item)
		{
			return _orderRepository.Add(_mapper.Map<OrderDAL>(item));
		}

		public void AddMany(List<IOrderBLL> items)
		{
			List<OrderDAL> orders = new List<OrderDAL>();
			foreach (var item in items)
			{
				orders.Add(_mapper.Map<OrderDAL>(item));
			}
			_orderRepository.AddMany(orders);
		}

		public async Task Delete(int id)
		{
			await _orderRepository.Delete(id);
		}

		public IOrderBLL Get(int id)
		{
			var dalOrder = _orderRepository.Get(id);
			return _mapper.Map<OrderBLL>(dalOrder);
		}

		public List<IOrderBLL> GetAll()
		{
			var dalOrders = _orderRepository.GetAll();
			var result = new List<IOrderBLL>();
			foreach (var el in dalOrders)
			{
				result.Add(_mapper.Map<OrderBLL>(el));
			}
			return result;
		}

		public void Update(IOrderBLL item)
		{
			_orderRepository.Update(_mapper.Map<OrderDAL>(item));
		}


		public Tuple<string[], string[]> DataForSoldPoductsChart(int days)
		{
			string[] dates = new string[days];
			string[] solds = new string[days];

			for (int i = 0; i < days; i++)
			{
				int sold = 0;
				var date = DateTime.UtcNow.AddDays(-(i + 1));
				var orders = _orderRepository.GetOrdersByDateTime(date);
				foreach (var order in orders)
				{
					foreach (var orderDetail in order.OrderDetails)
					{
						sold += orderDetail.Quantity;
					}
				}
				dates[days - (i + 1)] = date.ToString("dd-MM-yyyy");
				solds[days - (i + 1)] = sold.ToString();
			}
			return new Tuple<string[], string[]>(dates, solds);
		}

		public Tuple<string[], string[], string[]> DataForSoldPoductsByCtegoriesChart(int days)
		{
			Dictionary<string, int> valuePairs = new Dictionary<string, int>();
			var dalCategories = _categoryRepository.GetParentCategories().ToList();

			string[] categories = new string[dalCategories.Count];
			string[] solds = new string[dalCategories.Count];
			string[] colors = new string[dalCategories.Count];

			try
			{

				int k = 0;
				foreach (var dalCategory in dalCategories)
				{
					colors[k] = dalCategory.Color;
					valuePairs.Add(dalCategory.CategoryName, 0);
					k++;
				}

				for (int i = 0; i < days; i++)
				{
					var date = DateTime.UtcNow.AddDays(-(i + 1));
					var orders = _orderRepository.GetOrdersWithProductCategoryByDateTime(date);
					foreach (var order in orders)
					{
						if (order.OrderDetails != null)
							foreach (var orderDetail in order.OrderDetails)
						{
								if (orderDetail != null && orderDetail.Product != null &&
									orderDetail.Product.Category != null &&
									orderDetail.Product.Category.CategoryName != null) 
								{

									valuePairs[dalCategories.FirstOrDefault( x=>x.CategoryID==orderDetail.Product.Category.ParentCategoryId).CategoryName] += orderDetail.Quantity;
								}
							
						}
					}
				}

				int j = 0;
				foreach (var keyValuePair in valuePairs)
				{
					categories[j] = keyValuePair.Key;
					solds[j] = keyValuePair.Value.ToString();
					j++;
				}
			}
			catch (Exception e)
			{
			}

			return new Tuple<string[], string[], string[]>(categories, solds, colors);
		}

		public Tuple<string[], string[], string[]> DataForSoldPoductsBySuppliersChart(int days)
		{
			Dictionary<string, int> valuePairs = new Dictionary<string, int>();
			var dalSuppliers = _supplierRepository.GetAll().ToList();

			string[] suppliers = new string[dalSuppliers.Count];
			string[] solds = new string[dalSuppliers.Count];
			string[] colors = new string[dalSuppliers.Count];
			try
			{
				
				int k = 0;
				foreach (var dalSupplier in dalSuppliers)
				{
					colors[k] = dalSupplier.Color == null ? "#563d7c" : dalSupplier.Color;
					valuePairs.Add(dalSupplier.CompanyName, 0);
					k++;
				}

				for (int i = 0; i < days; i++)
				{
					var date = DateTime.UtcNow.AddDays(-(i + 1));
					var orders = _orderRepository.GetOrdersWithProductSupplierByDateTime(date);
					foreach (var order in orders)
					{	
						if(order.OrderDetails != null)
						foreach (var orderDetail in order.OrderDetails)
						{
							if(orderDetail!=null && orderDetail.Product!=null && 
								orderDetail.Product.Supplier!=null && orderDetail.Product.Supplier.CompanyName!=null)
							valuePairs[orderDetail.Product.Supplier.CompanyName] += orderDetail.Quantity;
						}
					}
				}

				int j = 0;
				foreach (var keyValuePair in valuePairs)
				{
					suppliers[j] = keyValuePair.Key;
					solds[j] = keyValuePair.Value.ToString();
					j++;
				}
			}
			catch (Exception e)
			{

			}
			
			return new Tuple<string[], string[], string[]>(suppliers, solds, colors);
		}

		public List<IOrderBLL> GetOrdersWithDetails()
		{
			var dalOrders = _orderRepository.GetOrdersWithDetails();
			var result = new List<IOrderBLL>();
			foreach (var el in dalOrders)
			{
				result.Add(_mapper.Map<OrderBLL>(el));
			}
			return result;
		}

		public Task<List<IOrderBLL>> GetOrdersWithDetailsAsync()
		{
			var task = Task.Factory.StartNew(GetOrdersWithDetails);
			return task;
		}

		public IOrderBLL GetOrderByCustomerID(string id)
		{
			var dalOrder = _orderRepository.GetOrderByCustomerID(id);
			return _mapper.Map<OrderBLL>(dalOrder);
		}

		public Task<IOrderBLL> GetOrderByCustomerIDAsync(string id)
		{
			return Task.Run(() => GetOrderByCustomerID(id));
		}

		public IOrderBLL GetOrderWithDetailsProudctAndReviewsByCustomerID(string id)
		{
			var dalOrder = _orderRepository.GetOrderWithDetailsProudctAndReviewsByCustomerID(id);
			return _mapper.Map<OrderBLL>(dalOrder);
		}
	}
}
