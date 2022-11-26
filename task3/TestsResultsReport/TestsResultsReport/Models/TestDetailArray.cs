using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TestsResultsReport.Models
{
	public class TestDetailArray
	{
		[JsonPropertyName("values")]
		public List<TestDetail> TestDetailCollection { get; set; }
	}
}
