using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebStore.Data.Models;
using WebStore.Data.RepositoryInterfaces;
using WebStore.Logic.DataInterfaces;
using WebStore.Logic.Models;
using WebStore.Logic.ServiceInterfaces;

namespace WebStore.Logic.Services
{
	public class OrderDetailService : IOrderDetailService
	{
		private readonly IOrderDetailRepository _orderDetailRepository;
		private readonly IMapper _mapper;
		public OrderDetailService(IOrderDetailRepository orderDetailRepository, IMapper mapper)
		{
			_orderDetailRepository = orderDetailRepository;
			_mapper = mapper;
		}
		public int Add(IOrderDetailBLL item)
		{
			return _orderDetailRepository.Add(_mapper.Map<OrderDetailDAL>(item));
		}

		public void AddMany(List<IOrderDetailBLL> items)
		{
			List<OrderDetailDAL> orderDetails = new List<OrderDetailDAL>();
			foreach (var item in items)
			{
				orderDetails.Add(_mapper.Map<OrderDetailDAL>(item));
			}
			_orderDetailRepository.AddMany(orderDetails);
		}

		public async Task Delete(int id)
		{
			await _orderDetailRepository.Delete(id);
		}

		public IOrderDetailBLL Get(int id)
		{
			var dalOrderDetail = _orderDetailRepository.Get(id);
			return _mapper.Map<OrderDetailBLL>(dalOrderDetail);
		}

		public List<IOrderDetailBLL> GetAll()
		{
			var dalOrderDetails = _orderDetailRepository.GetAll();
			var result = new List<IOrderDetailBLL>();
			foreach (var el in dalOrderDetails)
			{
				result.Add(_mapper.Map<OrderDetailBLL>(el));
			}
			return result;
		}

		public void Update(IOrderDetailBLL item)
		{
			_orderDetailRepository.Update(_mapper.Map<OrderDetailDAL>(item));
		}
	}
}
