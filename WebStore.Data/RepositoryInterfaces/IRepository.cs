using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Data.RepositoryInterfaces
{
	public interface IRepository<T> where T : class
	{
		int Add(T item);
		Task Delete(int id);
		void Update(T item);
		T Get(int id);
		IEnumerable<T> GetAll();
		void AddMany(IEnumerable<T> items);
	}
}
