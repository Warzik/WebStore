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
    public class WishRepository : IWishRepository
    {
		private readonly WebStoreDataContext _context;

		public WishRepository(WebStoreDataContext context)
		{
			_context = context;
		}

		public int Add(IWishDAL item)
		{
			var data = _context.Add(item);
			_context.SaveChanges();
			_context.Entry(item).State = EntityState.Detached;
			return data.Entity.WishID;
		}

		public void AddMany(IEnumerable<IWishDAL> items)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			_context.AddRange(items);
			_context.SaveChanges();
		}

		public async Task Delete(int id)
		{
			var item = await _context.Wishes.FirstOrDefaultAsync(p => p.WishID == id);
			_context.Remove(item);
			_context.SaveChanges();
		}

		public void DeleteByProductAndCustomerIDs(int productID, string customerID)
		{
			var item = _context.Wishes.FirstOrDefault(p => p.CustomerID == customerID && p.ProductID==productID);
			if (item != null)
			{
				_context.Remove(item);
				_context.SaveChanges();
			}
		}

		public IWishDAL Get(int id)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Wishes.FirstOrDefault(p => p.WishID == id);
		}

		public IEnumerable<IWishDAL> GetAll()
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Wishes.ToList();
		}

		public IEnumerable<IWishDAL> GetAllByCustomerID(string customerID)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Wishes.Where(x=>x.CustomerID== customerID).ToList();
		}

		public IEnumerable<IWishDAL> GetAllWithProductsAndReviewsByCustomerID(string customerID)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Wishes.Where(x => x.CustomerID == customerID).Include("Product.Reviews").ToList();
		}

		public IEnumerable<IWishDAL> GetAllWithProductsByCustomerID(string customerID)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Wishes.Where(x => x.CustomerID == customerID).Include("Product").ToList();
		}

		public IWishDAL GetByProductAndCustomerID(int productID, string customerID)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Wishes.FirstOrDefault(x => x.CustomerID == customerID && x.ProductID== productID);
		}

		public void Update(IWishDAL item)
		{
			_context.Update(item);
			_context.SaveChanges();
			_context.Entry(item).State = EntityState.Detached;
		}
	}
}
