using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.WebApplication.Services
{
	public class DataNotificationService
	{
		public event Action OnChange;
		public void NotifyDataChanged() => OnChange?.Invoke();
	}
}
