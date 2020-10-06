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
	public class OrderRepository : IOrderRepository
	{
		private readonly WebStoreDataContext _context;

		public OrderRepository(WebStoreDataContext context)
		{
			_context = context;
		}

		public int Add(IOrderDAL item)
		{
			var data = _context.Add(item);
			_context.SaveChanges();
			_context.Entry(item).State = EntityState.Detached;
			return data.Entity.OrderID;
		}

		public void AddMany(IEnumerable<IOrderDAL> items)
		{

			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			_context.AddRange(items);
			_context.SaveChanges();
		
		}

		public async Task Delete(int id)
		{
			var item = await _context.Orders.FirstOrDefaultAsync(p => p.OrderID == id);
			_context.Remove(item);
			_context.SaveChanges();
		}

		public IOrderDAL Get(int id)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Orders.FirstOrDefault(p => p.OrderID == id);
		}

		public IEnumerable<IOrderDAL> GetAll()
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Orders.ToList();
		}

		public IOrderDAL GetOrderByCustomerID(string id)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Orders.Include("OrderDetails.Product").FirstOrDefault(x=>x.CustomerID== id);
		}

		public IEnumerable<IOrderDAL> GetOrdersByDateTime(DateTime dateTime)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Orders.Where(o =>
			o.PaymentDate.Year == dateTime.Year &&
			o.PaymentDate.Month == dateTime.Month &&
			o.PaymentDate.Day == dateTime.Day).Include("OrderDetails").ToList();
		}

		public IEnumerable<IOrderDAL> GetOrdersWithDetails()
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Orders.Include("OrderDetails").ToList();
		}

		public IEnumerable<IOrderDAL> GetOrdersWithProductCategoryByDateTime(DateTime dateTime)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Orders.Where(o =>
			o.PaymentDate.Year == dateTime.Year &&
			o.PaymentDate.Month == dateTime.Month &&
			o.PaymentDate.Day == dateTime.Day).Include("OrderDetails.Product.Category").ToList();
		}

		public IEnumerable<IOrderDAL> GetOrdersWithProductSupplierByDateTime(DateTime dateTime)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Orders.Where(o =>
			o.PaymentDate.Year == dateTime.Year &&
			o.PaymentDate.Month == dateTime.Month &&
			o.PaymentDate.Day == dateTime.Day).Include("OrderDetails.Product.Supplier").ToList();
		}

		public IOrderDAL GetOrderWithDetailsProudctAndReviewsByCustomerID(string id)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Orders.Include("OrderDetails.Product.Reviews").FirstOrDefault(x => x.CustomerID == id);
		}

		public void Update(IOrderDAL item)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			_context.Update(item);
			_context.SaveChanges();
			_context.Entry(item).State = EntityState.Detached;
		}
	}
}
