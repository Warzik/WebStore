using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebStore.Logic.DataInterfaces;


namespace WebStore.Logic.ServiceInterfaces
{
	public interface IPaymentService : IService<IPaymentBLL>
	{
		Task<List<IPaymentBLL>> GetAllAsync();
	}
}
