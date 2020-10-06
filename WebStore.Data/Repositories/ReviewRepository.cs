using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using FastMember;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Common;
using WebStore.Data.DataInterfaces;
using WebStore.Data.Models;
using WebStore.Data.RepositoryInterfaces;
namespace WebStore.Data.Repositories
{
	public class ReviewRepository : IReviewRepository
	{
		private readonly WebStoreDataContext _context;

		public ReviewRepository(WebStoreDataContext context)
		{
			_context = context;
		}

		public int Add(IReviewDAL item)
		{
			var data = _context.Add(item);
			_context.SaveChanges();
			_context.Entry(item).State = EntityState.Detached;
			return data.Entity.ReviewID;
		}

		public void AddMany(IEnumerable<IReviewDAL> items)
		{

			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			_context.AddRange(items);
			_context.SaveChanges();
		}

		public async Task Delete(int id)
		{
			var item = await _context.Reviews.FirstOrDefaultAsync(p => p.ReviewID == id);
			_context.Remove(item);
			_context.SaveChanges();
		}

		public IReviewDAL Get(int id)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Reviews.FirstOrDefault(p => p.ReviewID == id);
		}

		public IEnumerable<IReviewDAL> GetAllByProductID(int id)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Reviews.Where(p => p.ProductID == id).ToList();
		}
		public IEnumerable<IReviewDAL> GetAll()
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Reviews.ToList();
		}

		public void Update(IReviewDAL item)
		{
			_context.Update(item);
			_context.SaveChanges();
			_context.Entry(item).State = EntityState.Detached;
		}
	}
}
