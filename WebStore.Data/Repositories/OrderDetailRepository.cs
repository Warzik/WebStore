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
	public class OrderDetailRepository : IOrderDetailRepository
	{
		private readonly WebStoreDataContext _context;

		public OrderDetailRepository(WebStoreDataContext context)
		{
			_context = context;
		}

		public int Add(IOrderDetailDAL item)
		{
			var data = _context.Add(item);
			_context.SaveChanges();
			_context.Entry(item).State = EntityState.Detached;
			return data.Entity.OrderDetailID;
		}

		public void AddMany(IEnumerable<IOrderDetailDAL> items)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			_context.AddRange(items);
			_context.SaveChanges();
		}

		public async Task Delete(int id)
		{
			var item =  _context.OrderDetails.FirstOrDefault(p => p.OrderDetailID == id);
			_context.Remove(item);
			_context.SaveChanges();
		}

		public IOrderDetailDAL Get(int id)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.OrderDetails.FirstOrDefault(p => p.OrderDetailID == id);
		}

		public IEnumerable<IOrderDetailDAL> GetAll()
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.OrderDetails.ToList();
		}

		public void Update(IOrderDetailDAL item)
		{
			_context.Update(item);
			_context.SaveChanges();
			_context.Entry(item).State = EntityState.Detached;
		}
	}
}
