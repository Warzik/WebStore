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
	public class SupplierRepository : ISupplierRepository
	{
		private readonly WebStoreDataContext _context;

		public SupplierRepository(WebStoreDataContext context)
		{
			_context = context;
		}

		public string Add(ISupplierDAL item)
		{
			var data = _context.Add(item);
			_context.SaveChanges();
			_context.Entry(item).State = EntityState.Detached;
			return data.Entity.SupplierID;
		}

		public void AddMany(IEnumerable<ISupplierDAL> items)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			_context.AddRange(items);
			_context.SaveChanges();

		}

		public async Task Delete(string id)
		{
			var item = await _context.Suppliers.FirstOrDefaultAsync(p => p.SupplierID == id);
			_context.Remove(item);
			_context.SaveChanges();
		}

		public ISupplierDAL Get(string id)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Suppliers.FirstOrDefault(p => p.SupplierID == id);
		}

		public IEnumerable<ISupplierDAL> GetAll()
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Suppliers.ToList();
		}

		public void Update(ISupplierDAL item)
		{
			_context.Update(item);
			_context.SaveChanges();
			_context.Entry(item).State = EntityState.Detached;
		}
	}
}
