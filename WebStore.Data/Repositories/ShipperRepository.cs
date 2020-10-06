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
	public class ShipperRepository : IShipperRepository
	{
		private readonly WebStoreDataContext _context;

		public ShipperRepository(WebStoreDataContext context)
		{
			_context = context;
		}

		public int Add(IShipperDAL item)
		{
			var data = _context.Add(item);
			_context.SaveChanges();
			_context.Entry(item).State = EntityState.Detached;
			return data.Entity.ShipperID;
		}

		public void AddMany(IEnumerable<IShipperDAL> items)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			_context.AddRange(items);
			_context.SaveChanges();
		
		}

		public async Task Delete(int id)
		{
			var item = await _context.Shippers.FirstOrDefaultAsync(p => p.ShipperID == id);
			_context.Remove(item);
			_context.SaveChanges();
		}

		public IShipperDAL Get(int id)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Shippers.FirstOrDefault(p => p.ShipperID == id);
		}

		public IEnumerable<IShipperDAL> GetAll()
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Shippers.ToList();
		}

		public void Update(IShipperDAL item)
		{
			_context.Update(item);
			_context.SaveChanges();
			_context.Entry(item).State = EntityState.Detached;
		}
	}
}
