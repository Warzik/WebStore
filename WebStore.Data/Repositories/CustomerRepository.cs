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
	public class CustomerRepository : ICustomerRepository
	{

		private readonly WebStoreDataContext _context;

		public CustomerRepository(WebStoreDataContext context)
		{
			_context = context;
		}

		public string Add(ICustomerDAL item)
		{
			var data = _context.Add(item);
			_context.SaveChanges();
			_context.Entry(item).State = EntityState.Detached;
			return data.Entity.CustomerID;
		}

		

		public void AddMany(IEnumerable<ICustomerDAL> items)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			_context.AddRange(items);
			_context.SaveChanges();
		}

		public async Task Delete(string id)
		{
			var item = await _context.Customers.FirstOrDefaultAsync(p => p.CustomerID == id);
			_context.Remove(item);
			_context.SaveChanges();
		}

		public ICustomerDAL Get(string id)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Customers.FirstOrDefault(p => p.CustomerID == id);
		}

		public IEnumerable<ICustomerDAL> GetAll()
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Customers.ToList();
		}

		

		public void Update(ICustomerDAL item)
		{
			_context.Update(item);
			_context.SaveChanges();
			_context.Entry(item).State = EntityState.Detached;
		}
	}
}
