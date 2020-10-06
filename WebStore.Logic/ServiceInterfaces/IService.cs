using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Logic.ServiceInterfaces
{
	public interface IService<T> where T : class
	{
		int Add(T item);
		Task Delete(int id);
		void Update(T item);
		T Get(int id);
		List<T> GetAll();
		void AddMany(List<T> items);
	}
}
