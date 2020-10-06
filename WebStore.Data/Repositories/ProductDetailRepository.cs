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
    public class ProductDetailRepository : IProductDetailRepository
    {
		private readonly WebStoreDataContext _context;

		public ProductDetailRepository(WebStoreDataContext context)
		{
			_context = context;
		}

		public int Add(IProductDetailDAL item)
		{
			var data = _context.Add(item);
			_context.SaveChanges();
			_context.Entry(item).State = EntityState.Detached;
			return data.Entity.ProductDetailID;
		}

		public void AddMany(IEnumerable<IProductDetailDAL> items)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			_context.AddRange(items);
			_context.SaveChanges();
			foreach (var itemm in items)
			{
				_context.Entry(itemm).State = EntityState.Detached;
			}
		}

		public async Task Delete(int id)
		{
			var item = await _context.ProductDetails.FirstOrDefaultAsync(p => p.ProductDetailID == id);
			_context.Remove(item);
			_context.SaveChanges();
		}

		public IProductDetailDAL Get(int id)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.ProductDetails.FirstOrDefault(p => p.ProductDetailID == id);
		}

		public IEnumerable<IProductDetailDAL> GetAll()
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.ProductDetails.ToList();
		}

		public IEnumerable<IProductDetailDAL> GetAllByProductID(int id)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.ProductDetails.AsNoTracking().Where(p => p.ProductID == id).ToList();
		}

		public void Update(IProductDetailDAL item)
		{
			_context.Update(item);
			_context.SaveChanges();
			_context.Entry(item).State = EntityState.Detached;
		}


	}
}
