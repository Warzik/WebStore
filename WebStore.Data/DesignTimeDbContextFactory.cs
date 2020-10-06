using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Common;

namespace WebStore.Data
{
	public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<WebStoreDataContext>
	{
		public WebStoreDataContext CreateDbContext(string[] args)
		{

			var builder = new DbContextOptionsBuilder<WebStoreDataContext>();
			var connectionString = ConstVal.ConnectionStringDb;
			builder.UseSqlServer(connectionString);
			return new WebStoreDataContext(builder.Options);
		}
	}
}
