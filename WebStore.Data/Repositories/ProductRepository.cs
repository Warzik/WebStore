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
	public class ProductRepository : IProductRepository
	{
		private readonly WebStoreDataContext _context;

		public ProductRepository(WebStoreDataContext context)
		{
			_context = context;
		}

		public int Add(IProductDAL item)
		{
			var data = _context.Add(item);
			_context.SaveChanges();
			_context.Entry(item).State = EntityState.Detached;
			return data.Entity.ProductID;
		}

		public void AddMany(IEnumerable<IProductDAL> items)
		{

			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			_context.AddRange(items);
			_context.SaveChanges();
		
		}

		public async Task Delete(int id)
		{
			var item = await _context.Products.FirstOrDefaultAsync(p => p.ProductID == id);
			_context.Remove(item);
			_context.SaveChanges();
		}

		public IProductDAL Get(int id)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Products.FirstOrDefault(p => p.ProductID == id);
		}

		public IEnumerable<IProductDAL> GetAll()
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Products.AsNoTracking().ToList();
		}

		public IEnumerable<IProductDAL> GetAllBySupplierID(string id)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Products.AsNoTracking().Where(x=>x.SupplierID== id).ToList();
		}

		public IEnumerable<IProductDAL> GetAllWithReviews()
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Products.Include("Reviews").ToList();
		}

		public IEnumerable<IProductDAL> GetAllWithDetailsAndReviews()
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Products.Include("ProductDetails").Include("Reviews").ToList();
		}

		public IEnumerable<IProductDAL> GetTopCommentsWithReviews()
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Products.Include("Reviews").OrderByDescending(x => x.Reviews.Count).Take(8).ToList();
		}

		public IEnumerable<IProductDAL> GetTopSalesWithReviews()
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Products.OrderByDescending(x => x.Discount).Take(8).Include("Reviews").ToList();

		}

		public void Update(IProductDAL item)
		{
			_context.Update(item);
			_context.SaveChanges();
			_context.Entry(item).State = EntityState.Detached;
		}

		public IProductDAL GetWithProductDetailsAndReviewsByProductID(int id)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Products.Include("Reviews").Include("ProductDetails").FirstOrDefault(x => x.ProductID == id);
		}

		public IEnumerable<IProductDAL> GetByProductFirm(string productFirm)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Products.Include("Reviews").Where(x=>x.ProductFirm== productFirm).Take(4).ToList();
		}
	}
}
