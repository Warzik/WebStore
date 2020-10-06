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
	public class SupplierService : ISupplierService
	{
		private readonly ISupplierRepository _supplierRepository;
		private readonly IMapper _mapper;
		public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
		{
			_supplierRepository = supplierRepository;
			_mapper = mapper;
		}
		public string Add(ISupplierBLL item)
		{
			return _supplierRepository.Add(_mapper.Map<SupplierDAL>(item));
		}

		public void AddMany(List<ISupplierBLL> items)
		{
			List<SupplierDAL> suppliers = new List<SupplierDAL>();
			foreach (var item in items)
			{
				suppliers.Add(_mapper.Map<SupplierDAL>(item));
			}
			_supplierRepository.AddMany(suppliers);
		}

		public async Task Delete(string id)
		{
			await _supplierRepository.Delete(id);
		}

		public ISupplierBLL Get(string id)
		{
			var dalSupplier = _supplierRepository.Get(id);
			return _mapper.Map<SupplierBLL>(dalSupplier);
		}

		public List<ISupplierBLL> GetAll()
		{
			var dalSuppliers = _supplierRepository.GetAll();
			var result = new List<ISupplierBLL>();
			foreach (var el in dalSuppliers)
			{
				result.Add(_mapper.Map<SupplierBLL>(el));
			}
			return result;
		}

		public Task<List<ISupplierBLL>> GetAllAsync()
		{
			var task = Task.Factory.StartNew(GetAll);
			return task;
		}
		public void Update(ISupplierBLL item)
		{
			_supplierRepository.Update(_mapper.Map<SupplierDAL>(item));
		}
	}
}
