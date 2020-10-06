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
	public class PaymentService : IPaymentService
	{
		private readonly IPaymentRepository _paymentRepository;
		private readonly IMapper _mapper;
		public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
		{
			_paymentRepository = paymentRepository;
			_mapper = mapper;
		}
		public int Add(IPaymentBLL item)
		{
			return _paymentRepository.Add(_mapper.Map<PaymentDAL>(item));
		}
		public void AddMany(List<IPaymentBLL> items)
		{
			List<PaymentDAL> payments = new List<PaymentDAL>();
			foreach (var item in items)
			{
				payments.Add(_mapper.Map<PaymentDAL>(item));
			}
			_paymentRepository.AddMany(payments);
		}

		public async Task Delete(int id)
		{
			await _paymentRepository.Delete(id);
		}

		public IPaymentBLL Get(int id)
		{
			var dalPayment = _paymentRepository.Get(id);
			return _mapper.Map<PaymentBLL>(dalPayment);
		}

		public List<IPaymentBLL> GetAll()
		{
			var dalPayments = _paymentRepository.GetAll();
			var result = new List<IPaymentBLL>();
			foreach (var el in dalPayments)
			{
				result.Add(_mapper.Map<PaymentBLL>(el));
			}
			return result;
		}

		public Task<List<IPaymentBLL>> GetAllAsync()
		{
			var task = Task.Factory.StartNew(GetAll);
			return task;
		}

		public void Update(IPaymentBLL item)
		{
			_paymentRepository.Update(_mapper.Map<PaymentDAL>(item));
		}
	}
}
