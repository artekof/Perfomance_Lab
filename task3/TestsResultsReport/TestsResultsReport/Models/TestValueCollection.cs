using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TestsResultsReport.Models
{
	public class TestValueCollection
	{
		[JsonPropertyName("values")]
		public List<TestValue> Values { get; set; }
	}
}
