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

	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;
		public ProductService(IProductRepository productRepository, IMapper mapper)
		{
			_productRepository = productRepository;
			_mapper = mapper;
		}
		public int Add(IProductBLL item)
		{
			return _productRepository.Add(_mapper.Map<ProductDAL>(item));
		}
		public void AddMany(List<IProductBLL> items)
		{
			List<ProductDAL> products = new List<ProductDAL>();
			foreach (var item in items)
			{
				products.Add(_mapper.Map<ProductDAL>(item));
			}
			_productRepository.AddMany(products);
		}

		public async Task Delete(int id)
		{
			await _productRepository.Delete(id);
		}

		public IProductBLL Get(int id)
		{
			var dalProduct = _productRepository.Get(id);
			return _mapper.Map<ProductBLL>(dalProduct);
		}

		public List<IProductBLL> GetAll()
		{
			var dalProducts = _productRepository.GetAll();
			var result = new List<IProductBLL>();
			foreach (var el in dalProducts)
			{
				result.Add(_mapper.Map<ProductBLL>(el));
			}
			return result;
		}

		public List<IProductBLL> GetByProductFirm(string productFirm)
		{
			var dalProducts = _productRepository.GetByProductFirm(productFirm);
			var result = new List<IProductBLL>();
			foreach (var el in dalProducts)
			{
				result.Add(_mapper.Map<ProductBLL>(el));
			}
			return result;
		}

		public Task<List<IProductBLL>> GetByProductFirmAsync(string productFirm)
		{
			return Task.Run(()=>  GetByProductFirm(productFirm) );
		}

		public Task<List<IProductBLL>> GetProductsAsync()
		{
			var task = Task.Factory.StartNew(GetAll);
			return task;
		}

		public List<IProductBLL> GetProductsBySupplierID(string id)
		{
			var dalProducts = _productRepository.GetAllBySupplierID(id);
			var result = new List<IProductBLL>();
			foreach (var el in dalProducts)
			{
				result.Add(_mapper.Map<ProductBLL>(el));
			}
			return result;
		}

		public Task<List<IProductBLL>> GetProductsBySupplierIDAsync(string id)
		{
			return Task.Run(() => GetProductsBySupplierID(id));
		}

		public List<IProductBLL> GetProductsWithDetailsAndReviews()
		{
			var dalProducts = _productRepository.GetAllWithDetailsAndReviews();
			var result = new List<IProductBLL>();
			foreach (var el in dalProducts)
			{
				result.Add(_mapper.Map<ProductBLL>(el));
			}
			return result;
		}

		public Task<List<IProductBLL>> GetProductsWithDetailsAndReviewsAsync()
		{
			var task = Task.Factory.StartNew(GetProductsWithDetailsAndReviews);
			return task;
		}

		public List<IProductBLL> GetProductsWithReviews()
		{
			var dalProducts = _productRepository.GetAllWithReviews();
			var result = new List<IProductBLL>();
			foreach (var el in dalProducts)
			{
				result.Add(_mapper.Map<ProductBLL>(el));
			}
			return result;
		}

		public Task<List<IProductBLL>> GetProductsWithReviewsAsync()
		{
			var task = Task.Factory.StartNew(GetProductsWithReviews);
			return task;
		}

		public List<IProductBLL> GetTopCommentsWhitReviews()
		{
			var dalProducts = _productRepository.GetTopCommentsWithReviews();
			var result = new List<IProductBLL>();
			foreach (var el in dalProducts)
			{
				result.Add(_mapper.Map<ProductBLL>(el));
			}
			return result;
		}

		public Task<List<IProductBLL>> GetTopCommentsWhitReviewsAsync()
		{
			var task = Task.Factory.StartNew(GetTopCommentsWhitReviews);
			return task;
		}

		public List<IProductBLL> GetTopSelesWithReviews()
		{
			try
			{
				var dalProducts = _productRepository.GetTopSalesWithReviews();
				var result = new List<IProductBLL>();
				foreach (var el in dalProducts)
				{
					result.Add(_mapper.Map<ProductBLL>(el));
				}
				return result;
			}
			catch 
			{
				return null;

			}
			
		}

		public Task<List<IProductBLL>> GetTopSelesWithReviewsAsync()
		{
			var task = Task.Factory.StartNew(GetTopSelesWithReviews);
			return task;
		}

		public IProductBLL GetWithProductDetailsAndReviewsByProductID(int id)
		{
			var dalProduct = _productRepository.GetWithProductDetailsAndReviewsByProductID(id);
			return _mapper.Map<ProductBLL>(dalProduct);
		}

		public void Update(IProductBLL item)
		{
			_productRepository.Update(_mapper.Map<ProductDAL>(item));
		}
	}
}
