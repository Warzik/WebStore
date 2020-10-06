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
	public class ReviewService : IReviewService
	{
		private readonly IReviewRepository _reviewRepository;
		private readonly IMapper _mapper;
		public ReviewService(IReviewRepository reviewRepository, IMapper mapper)
		{
			_reviewRepository = reviewRepository;
			_mapper = mapper;
		}
		public int Add(IReviewBLL item)
		{
			return _reviewRepository.Add(_mapper.Map<ReviewDAL>(item));
		}
		public void AddMany(List<IReviewBLL> items)
		{
			List<ReviewDAL> reviews = new List<ReviewDAL>();
			foreach (var item in items)
			{
				reviews.Add(_mapper.Map<ReviewDAL>(item));
			}
			_reviewRepository.AddMany(reviews);
		}

		public async Task Delete(int id)
		{
			await _reviewRepository.Delete(id);
		}

		public IReviewBLL Get(int id)
		{
			var dalReview = _reviewRepository.Get(id);
			return _mapper.Map<ReviewBLL>(dalReview);
		}

		public List<IReviewBLL> GetAll()
		{
			var dalReviews = _reviewRepository.GetAll();
			var result = new List<IReviewBLL>();
			foreach (var el in dalReviews)
			{
				result.Add(_mapper.Map<ReviewBLL>(el));
			}
			return result;
		}

		public List<IReviewBLL> GetReviewsByProductID(int id)
		{
			var dalReviews = _reviewRepository.GetAllByProductID(id);
			var result = new List<IReviewBLL>();
			foreach (var el in dalReviews)
			{
				result.Add(_mapper.Map<ReviewBLL>(el));
			}
			return result;
		}

		public Task<List<IReviewBLL>> GetReviewsByProductIDAsync(int id)
		{
			return Task.Run(() => GetReviewsByProductID(id));
		}

		public void Update(IReviewBLL item)
		{
			_reviewRepository.Update(_mapper.Map<ReviewDAL>(item));
		}
	}
}
