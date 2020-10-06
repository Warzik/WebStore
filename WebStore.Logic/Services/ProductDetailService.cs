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
	public class ProductDetailService : IProductDetailService
	{
		private readonly IProductDetailRepository _productDetailRepository;
		private readonly IMapper _mapper;
		public ProductDetailService(IProductDetailRepository productDetailRepository, IMapper mapper)
		{
			_productDetailRepository = productDetailRepository;
			_mapper = mapper;
		}
		public int Add(IProductDetailBLL item)
		{
			return _productDetailRepository.Add(_mapper.Map<ProductDetailDAL>(item));
		}
		public void AddMany(List<IProductDetailBLL> items)
		{
			List<ProductDetailDAL> productDetails = new List<ProductDetailDAL>();
			foreach (var item in items)
			{
				productDetails.Add(_mapper.Map<ProductDetailDAL>(item));
			}
			_productDetailRepository.AddMany(productDetails);
		}

		public async Task Delete(int id)
		{
			await _productDetailRepository.Delete(id);
		}

		public IProductDetailBLL Get(int id)
		{
			var dalProductDetail = _productDetailRepository.Get(id);
			return _mapper.Map<ProductDetailBLL>(dalProductDetail);
		}

		public List<IProductDetailBLL> GetAll()
		{
			var dalProductDetails = _productDetailRepository.GetAll();
			var result = new List<IProductDetailBLL>();
			foreach (var el in dalProductDetails)
			{
				result.Add(_mapper.Map<ProductDetailBLL>(el));
			}
			return result;
		}

		public List<IProductDetailBLL> GetProductDetailsByProductID(int id)
		{
			var dalProductDetails = _productDetailRepository.GetAllByProductID(id);
			var result = new List<IProductDetailBLL>();
			foreach (var el in dalProductDetails)
			{
				result.Add(_mapper.Map<ProductDetailBLL>(el));
			}
			return result;
		}

		public Task<List<IProductDetailBLL>> GetProductDetailsByProductIDAsync(int id)
		{
			return Task.Run(()=> GetProductDetailsByProductID(id));
		}

		public void Update(IProductDetailBLL item)
		{
			_productDetailRepository.Update(_mapper.Map<ProductDetailDAL>(item));
		}
	}
}
