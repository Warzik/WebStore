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
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly IMapper _mapper;
		public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
		{
			_categoryRepository = categoryRepository;
			_mapper = mapper;
		}
		public int Add(ICategoryBLL item)
		{
			return _categoryRepository.Add(_mapper.Map<CategoryDAL>(item));
		}

		public void AddMany(List<ICategoryBLL> items)
		{
			List<CategoryDAL> categories = new List<CategoryDAL>();
			foreach (var item in items)
			{
				categories.Add(_mapper.Map<CategoryDAL>(item));
			}
			_categoryRepository.AddMany(categories);
		}

		public async Task Delete(int id)
		{
			await _categoryRepository.Delete(id);
		}

		public ICategoryBLL Get(int id)
		{
			var dalCategory = _categoryRepository.Get(id);
			return _mapper.Map<CategoryBLL>(dalCategory);
		}

		public List<ICategoryBLL> GetAll()
		{
			var dalCategories = _categoryRepository.GetAll();
			var result = new List<ICategoryBLL>();
			foreach (var el in dalCategories)
			{
				result.Add(_mapper.Map<CategoryBLL>(el));
			}
			return result;
		}

		public Task<List<ICategoryBLL>> GetAllAsync()
		{
			var task = Task.Factory.StartNew(GetAll);
			return task;
		}

		public List<ICategoryBLL> GetAllWithChildrenAndProductsAndReviews()
		{
			var dalCategories = _categoryRepository.GetAllWithChildrenAndProductsAndReviews();
			if (!(dalCategories is null))
			{
				var result = new List<ICategoryBLL>();
				foreach (var el in dalCategories)
				{
					result.Add(_mapper.Map<CategoryBLL>(el));
				}
				return result;
			}
			else 
			{
				return null;
			}
			
		}

		public Task<List<ICategoryBLL>> GetAllWithChildrenAndProductsAndReviewsAsync()
		{
			var task = Task.Factory.StartNew(GetAllWithChildrenAndProductsAndReviews);
			return task;
		}

		public List<ICategoryBLL> GetAllWithParent()
		{
			var dalCategories = _categoryRepository.GetAllWithParent();
			var result = new List<ICategoryBLL>();
			foreach (var el in dalCategories)
			{
				result.Add(_mapper.Map<CategoryBLL>(el));
			}
			return result;
		}

		public Task<List<ICategoryBLL>> GetAllWithParentAsync()
		{
			var task = Task.Factory.StartNew(GetAllWithParent);
			return task;
		}

		public void Update(ICategoryBLL item)
		{
			_categoryRepository.Update(_mapper.Map<CategoryDAL>(item));
		}
	}
}
