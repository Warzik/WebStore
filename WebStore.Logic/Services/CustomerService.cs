using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebStore.Data.Models;
using WebStore.Data.RepositoryInterfaces;
using WebStore.Logic.DataInterfaces;
using WebStore.Logic.Models;
using WebStore.Logic.ServiceInterfaces;

namespace WebStore.Logic.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly ICustomerRepository _customerRepository;
		private readonly IMapper _mapper;
		public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
		{
			_customerRepository = customerRepository;
			_mapper = mapper;
		}
		public string Add(ICustomerBLL item)
		{
			return _customerRepository.Add(_mapper.Map<CustomerDAL>(item));
		}

		public void AddMany(List<ICustomerBLL> items)
		{
			List<CustomerDAL> customers = new List<CustomerDAL>();
			foreach (var item in items)
			{
				customers.Add(_mapper.Map<CustomerDAL>(item));
			}
			_customerRepository.AddMany(customers);
		}

		public async Task Delete(string id)
		{
			await _customerRepository.Delete(id);
		}

		public ICustomerBLL Get(string id)
		{
			var dalCustomer = _customerRepository.Get(id);
			return _mapper.Map<CustomerBLL>(dalCustomer);
		}

		public List<ICustomerBLL> GetAll()
		{
			var dalCustomers = _customerRepository.GetAll();
			var result = new List<ICustomerBLL>();
			foreach (var el in dalCustomers)
			{
				result.Add(_mapper.Map<CustomerBLL>(el));
			}
			return result;
		}

		public void Update(ICustomerBLL item)
		{
			_customerRepository.Update(_mapper.Map<CustomerDAL>(item));
		}

		public Task<List<ICustomerBLL>> GetAllAsync()
		{
			var task = Task.Factory.StartNew(GetAll);
			return task;
		}
	}
}
