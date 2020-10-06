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
	public class ShipperService : IShipperService
	{
		private readonly IShipperRepository _shipperRepository;
		private readonly IMapper _mapper;
		public ShipperService(IShipperRepository shipperRepository, IMapper mapper)
		{
			_shipperRepository = shipperRepository;
			_mapper = mapper;
		}
		public int Add(IShipperBLL item)
		{
			return _shipperRepository.Add(_mapper.Map<ShipperDAL>(item));
		}
		public void AddMany(List<IShipperBLL> items)
		{
			List<ShipperDAL> shippers = new List<ShipperDAL>();
			foreach (var item in items)
			{
				shippers.Add(_mapper.Map<ShipperDAL>(item));
			}
			_shipperRepository.AddMany(shippers);
		}

		public async Task Delete(int id)
		{
			await _shipperRepository.Delete(id);
		}

		public IShipperBLL Get(int id)
		{
			var dalShipper = _shipperRepository.Get(id);
			return _mapper.Map<ShipperBLL>(dalShipper);
		}

		public List<IShipperBLL> GetAll()
		{
			var dalShippers = _shipperRepository.GetAll();
			var result = new List<IShipperBLL>();
			foreach (var el in dalShippers)
			{
				result.Add(_mapper.Map<ShipperBLL>(el));
			}
			return result;
		}


		public Task<List<IShipperBLL>> GetAllAsync()
		{
			var task = Task.Factory.StartNew(GetAll);
			return task;
		}
		public void Update(IShipperBLL item)
		{
			_shipperRepository.Update(_mapper.Map<ShipperDAL>(item));
		}
	}
}
