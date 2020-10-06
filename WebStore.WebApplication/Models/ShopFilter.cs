using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebStore.WebApplication.Models
{
	public class ShopFilter
	{
		[JsonPropertyName("search")]
		public string Search { get; set; }
		[JsonPropertyName("orderBy")]
		public string OrderBy { get; set; }
		[JsonPropertyName("collection")]
		public string Collection { get; set; }
		[JsonPropertyName("type")]
		public string Type { get; set; }

	}
}
