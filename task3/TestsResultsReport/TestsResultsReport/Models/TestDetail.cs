using Newtonsoft.Json;
using System.Collections.Generic;

namespace TestsResultsReport.Models
{
	public class TestDetail
	{
		public int id { get; set; }
		public string title { get; set; }
		public string value { get; set; }

		[JsonProperty("values")]
		public List<TestDetail> insidesData { get; set; } = new List<TestDetail>();
	}
}
