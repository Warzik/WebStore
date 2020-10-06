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
	public class CategoryRepository : ICategoryRepository
	{
		private readonly WebStoreDataContext _context;

		public CategoryRepository(WebStoreDataContext context)
		{
			_context = context;
		}

		public int Add(ICategoryDAL item)
		{
			var data = _context.Add(item);
			_context.SaveChanges();
			_context.Entry(item).State = EntityState.Detached;
			return data.Entity.CategoryID;
		}

		public void AddMany(IEnumerable<ICategoryDAL> items)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			_context.AddRange(items);
			_context.SaveChanges();
		}

		public async Task Delete(int id)
		{
			var item = await _context.Categories.Include("ChildrenCategories").FirstOrDefaultAsync(p => p.CategoryID == id);
			if (item.ChildrenCategories != null)
			{
				foreach (var childCategory in item.ChildrenCategories)
				{
					childCategory.ParentCategoryId = null;
				}
			}
			_context.Remove(item);
			_context.SaveChanges();
		}

		public ICategoryDAL Get(int id)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Categories.FirstOrDefault(p => p.CategoryID== id);
		}

		public IEnumerable<ICategoryDAL> GetAll()
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Categories.ToList();
		}

		public IEnumerable<ICategoryDAL> GetAllWithChildrenAndProductsAndReviews()
		{
			try
			{
				_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
				return _context.Categories.Include("ChildrenCategories").Include("Products.Reviews").ToList();
			}
			catch (Exception)
			{
				return null;

			}
			
		}

		public IEnumerable<ICategoryDAL> GetAllWithParent()
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Categories.Include("ParentCategory").ToList();
		}

		public IEnumerable<ICategoryDAL> GetParentCategories()
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Categories.Where(x=>x.ParentCategoryId==null).ToList();
		}

		public void Update(ICategoryDAL item)
		{

			_context.Entry(item).State = EntityState.Modified;
			_context.SaveChanges();
			_context.Entry(item).State = EntityState.Detached;
		}

	
	}
}
