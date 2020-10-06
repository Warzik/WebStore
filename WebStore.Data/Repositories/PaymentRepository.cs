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
	public class PaymentRepository : IPaymentRepository
	{
		private readonly WebStoreDataContext _context;

		public PaymentRepository(WebStoreDataContext context)
		{
			_context = context;
		}

		public int Add(IPaymentDAL item)
		{
			var data = _context.Add(item);
			_context.SaveChanges();
			_context.Entry(item).State = EntityState.Detached;
			return data.Entity.PaymentID;
		}

		public void AddMany(IEnumerable<IPaymentDAL> items)
		{

			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			_context.AddRange(items);
			_context.SaveChanges();

		}

		public async Task Delete(int id)
		{
			var item = await _context.Payments.FirstOrDefaultAsync(p => p.PaymentID == id);
			_context.Remove(item);
			_context.SaveChanges();
		}

		public IPaymentDAL Get(int id)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Payments.FirstOrDefault(p => p.PaymentID == id);
		}

		public IEnumerable<IPaymentDAL> GetAll()
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Payments.ToList();
		}

		public void Update(IPaymentDAL item)
		{
			_context.Update(item);
			_context.SaveChanges();
			_context.Entry(item).State = EntityState.Detached;
		}
	}
}
