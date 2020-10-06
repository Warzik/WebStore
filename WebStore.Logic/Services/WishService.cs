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
	public class WishService : IWishService
	{
		private readonly IWishRepository _wishRepository;
		private readonly IMapper _mapper;
		public WishService(IWishRepository wishRepository, IMapper mapper)
		{
			_wishRepository = wishRepository;
			_mapper = mapper;
		}
		public int Add(IWishBLL item)
		{
			return _wishRepository.Add(_mapper.Map<WishDAL>(item));
		}

		public Task<int> AddAsync(IWishBLL item)
		{
			return Task.Run(()=> Add(item));
		}

		public void AddMany(List<IWishBLL> items)
		{
			List<WishDAL> wishes = new List<WishDAL>();
			foreach (var item in items)
			{
				wishes.Add(_mapper.Map<WishDAL>(item));
			}
			_wishRepository.AddMany(wishes);
		}

		public async Task Delete(int id)
		{
			await _wishRepository.Delete(id);
		}

		public void DeleteByProductAndCustomerIDs(int productID, string customerID)
		{
			_wishRepository.DeleteByProductAndCustomerIDs(productID, customerID);
		}
		public Task DeleteByProductAndCustomerIDsAsync(int productID, string customerID)
		{
			return Task.Run(() => DeleteByProductAndCustomerIDs(productID, customerID));
		}

		public IWishBLL Get(int id)
		{
			var dalWish = _wishRepository.Get(id);
			return _mapper.Map<WishBLL>(dalWish);
		}

		public List<IWishBLL> GetAll()
		{
			var dalWishes = _wishRepository.GetAll();
			var result = new List<IWishBLL>();
			foreach (var el in dalWishes)
			{
				result.Add(_mapper.Map<WishBLL>(el));
			}
			return result;
		}

		public List<IWishBLL> GetAllByCustomerID(string customerID)
		{
			var dalWishes = _wishRepository.GetAllByCustomerID(customerID);
			var result = new List<IWishBLL>();
			foreach (var el in dalWishes)
			{
				result.Add(_mapper.Map<WishBLL>(el));
			}
			return result;
		}

		public Task<List<IWishBLL>> GetAllByCustomerIDAsync(string customerID)
		{
			return Task.Run(() => GetAllByCustomerID(customerID));
		}

		public List<IWishBLL> GetAllWithProductsAndReviewsByCustomerID(string customerID)
		{
			var dalWishes = _wishRepository.GetAllWithProductsAndReviewsByCustomerID(customerID);
			var result = new List<IWishBLL>();
			foreach (var el in dalWishes)
			{
				result.Add(_mapper.Map<WishBLL>(el));
			}
			return result;
		}

		public List<IWishBLL> GetAllWithProductsByCustomerID(string customerID)
		{
			var dalWishes = _wishRepository.GetAllWithProductsByCustomerID(customerID);
			var result = new List<IWishBLL>();
			foreach (var el in dalWishes)
			{
				result.Add(_mapper.Map<WishBLL>(el));
			}
			return result;
		}

		public Task<List<IWishBLL>> GetAllWithProductsByCustomerIDAsync(string customerID)
		{
			return Task.Run(() => GetAllWithProductsByCustomerIDAsync(customerID));
		}

		public IWishBLL GetByProductAndCustomerID(int productID, string customerID)
		{
			var dalWish = _wishRepository.GetByProductAndCustomerID(productID, customerID);
			if(dalWish!=null)
				return _mapper.Map<WishBLL>(dalWish);
			else
				return null;
		}

		public void Update(IWishBLL item)
		{
			_wishRepository.Update(_mapper.Map<WishDAL>(item));
		}
	}
}
