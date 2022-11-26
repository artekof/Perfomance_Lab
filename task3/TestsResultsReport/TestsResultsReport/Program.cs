using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TestsResultsReport.Converters;
using TestsResultsReport.Models;

namespace TestsResultsReport
{
	internal class Program
	{
		private const string REPORT_FILE_NAME = "report.json";
		private static ICollection<TestValue> testValuesCollection { get; set; } = new List<TestValue>();
		static void Main(string[] args)
		{
			var testsDetailsFilePath = args[0];
			var testsValuesFilePath = args[1];

			var testsDetailsFileData = File.ReadAllText(testsDetailsFilePath);
			var testsValuesFileData = File.ReadAllText(testsValuesFilePath);


			var valuesData = JsonConvert.DeserializeObject<TestValueCollection>(testsValuesFileData);

			if(valuesData == null)
			{
				throw new ArgumentNullException("Json file with tests values is empty");
			}

			foreach (var value in valuesData.Values)
			{
				testValuesCollection.Add(value);
			}

			var detailData = new List<TestDetail>();

			try
			{
				var temporsry = JsonConvert.DeserializeObject<TestDetailArray>(testsDetailsFileData);

				if(temporsry.TestDetailCollection != null)
				{
					detailData.AddRange(temporsry.TestDetailCollection);
				}
				else
				{
					var singleObject = JsonConvert.DeserializeObject<TestDetail>(testsDetailsFileData);

					if(singleObject != null)
					{
						detailData.Add(singleObject);
					}
					else
					{
						throw new FormatException();
					}
				}
			}
			catch
			{
				Console.WriteLine("I haven't expected this format");
			}

			SeekElements(detailData);

			var outputJson = JsonConvert.SerializeObject(detailData);
			//Console.WriteLine(outputJson);

			var reportDirectory = Path.GetDirectoryName(testsDetailsFilePath);
			var reportFullFilePath = Path.Combine(reportDirectory, REPORT_FILE_NAME);
			
			using var reportFile = File.Create(reportFullFilePath);
			var jsonAsBytes = new UTF8Encoding(true).GetBytes(outputJson);
			reportFile.Write(jsonAsBytes, 0, jsonAsBytes.Length);
		}

		private static void SeekElements(ICollection<TestDetail> testDetailCollection)
		{
			foreach (var testDetail in testDetailCollection)
			{
				SetValue(testDetail);
			}
		}

		private static void SetValue(TestDetail testDetail)
		{
			var testValueItem = testValuesCollection.FirstOrDefault(c => c.id == testDetail.id);
			testDetail.value = testValueItem == null ? "undefined" : testValueItem.value;

			if(testValueItem != null)
			{
				testValuesCollection.Remove(testValueItem); // to make less iterations during searching
			}

			if(testDetail.insidesData == null)
			{
				return;
			}

			foreach (var subTestDetail in testDetail.insidesData)
			{
				SetValue(subTestDetail);
			}
		}
	}
}



















	//public class TestDetail
	//{
	//	public int id { get; set; }
	//	public string title { get; set; }
	//	public string value { get; set; }

	//	public List<TestDetail> values { get; set; }
	//}

	//public class TestValueArray
	//{
	//	[JsonPropertyName("values")]
	//	public List<TestValue> ValuesCollection { get; set; }
	//}

	//public class TestValue
	//{
	//	public string id { get; set; }
	//	public string value { get; set; }
	//}





//#region 'just_test' variable

//var just_test = new TestDetail();
//var det2 = new TestDetail() { id = 2 };
//var det3 = new TestDetail() { id = 3 };

//var det1 = new TestDetail() { id = 1 };
//var det11 = new TestDetail() { id = 11 };
//var det12 = new TestDetail() { id = 12 };

//var det121 = new TestDetail() { id = 121 };
//var det1211 = new TestDetail() { id = 1211 };
//var det1212 = new TestDetail() { id = 1212 };

//just_test.id = 324;
//just_test.values = new List<TestDetail>() { det1, det2, det3 };

//det1.values = new List<TestDetail>() { det11 };
//det1.values = new List<TestDetail>() { det12 };

//det12.values = new List<TestDetail>() { det121 };
//det121.values = new List<TestDetail>() { det1211, det1212 };


//#endregion



//string justData = JsonConvert.SerializeObject(just_test);

//Console.WriteLine(justData);

//var jsonObject = JObject.Parse(justData);


//var a = new TestDetailJsonConverter();

//var _test = JsonConvert.DeserializeObject(justData, typeof(TestDetail), a);

//var result = a.MonoTestDetailArray;

//for (int i = 0; i < result.Length; i++)
//{
//	Console.WriteLine($"obj {i}, id: {result[i]}");
//}
