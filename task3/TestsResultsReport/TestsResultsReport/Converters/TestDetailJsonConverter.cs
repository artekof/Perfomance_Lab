using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsResultsReport.Converters
{
	public class TestDetailJsonConverter //: JsonConverter<TestDetail>
	{
		//private const string id_prop = nameof(TestDetail.id);
		//private const string title_prop = nameof(TestDetail.title);
		//private const string value_prop = nameof(TestDetail.value);
		//private const string values_prop = nameof(TestDetail.values);


		// here is all links on the objects from an output object
		//public TestDetail[] MonoTestDetailArray { get; private set; } = new TestDetail[0];

		//public override TestDetail ReadJson(JsonReader reader, Type objectType, TestDetail existingValue, bool hasExistingValue, JsonSerializer serializer)
		//{
		//	var rootItem = new TestDetail();
		//	var deepIndex = 0;
		//	TestDetail current = rootItem;

		//	while (reader.Read())
		//	{
				//Console.ReadKey();

				//Console.WriteLine("value     : " + reader.Value);
				//Console.WriteLine("value type: " + reader.ValueType);
				//Console.WriteLine("token type: " + reader.TokenType);
				//Console.WriteLine("-----");

				//if (reader.TokenType == JsonToken.PropertyName && (reader.Value != null && reader.Value.ToString() == id_prop))
				//{
				//	if (reader.Value == null)
				//	{
				//		continue;
				//	}
				//}

				//if (reader.TokenType == JsonToken.PropertyName && (reader.Value != null && reader.Value.ToString() == title_prop))
				//{
				//	reader.Read();
				//	var tokenValue = reader.Value.ToString();

				//	current.title = tokenValue;
				//}

				//if (reader.TokenType == JsonToken.PropertyName && (reader.Value != null && reader.Value.ToString() == value_prop))
				//{
				//	reader.Read();
				//	var tokenValue = reader.Value.ToString();

				//	current.value = tokenValue;
				//}






			//	if (reader.TokenType == JsonToken.PropertyName)
			//	{
			//		var currentFieldName = reader.Value;

			//		if(currentFieldName == null)
			//		{
			//			continue;
			//		}

			//		reader.Read();

			//		var currentFieldValue = reader.Value;

			//		if(currentFieldValue == null)
			//		{
			//			continue;
			//		}

			//		switch (currentFieldName)
			//		{
			//			case id_prop: 
			//				if(reader.TokenType == JsonToken.Integer)
			//				{
			//					current.id = int.Parse(currentFieldValue.ToString());
			//				}
			//				else
			//				{
			//					throw new ArgumentException("test id must be integer only");
			//				}
			//				break;
			//			case value_prop: current.value = currentFieldValue.ToString();
			//				break;
			//			case title_prop: current.title = currentFieldValue.ToString();
			//				break;
			//			default: break;
			//		}
			//	}

			//	if (reader.TokenType == JsonToken.StartArray)
			//	{
			//		current.values = new List<TestDetail>();
			//	}

			//	if (reader.TokenType == JsonToken.StartObject)
			//	{
			//		current = new TestDetail();
			//		//deepIndex = deepIndex + 1;

			//		InserIntoMonoArray(current);
			//	}

			//	if (reader.TokenType == JsonToken.EndObject)
			//	{
			//		MonoTestDetailArray[deepIndex - 1].values.Add(current);
			//		//current.values.Add(current);
			//	}

			//	if (reader.TokenType == JsonToken.EndArray)
			//	{
			//		var possibleIndexValue = deepIndex - current.values.Count();

			//		deepIndex = possibleIndexValue < 0 ? 0 : possibleIndexValue;
			//	}
			//}

			//return rootItem;
		}

		//public override void WriteJson(JsonWriter writer, TestDetail value, JsonSerializer serializer)
		//{
		//	throw new NotImplementedException();
		//}

		//private void InserIntoMonoArray (TestDetail value)
		//{
		//	var currentArrayLength = MonoTestDetailArray.Length;
		//	var array = new TestDetail[currentArrayLength + 1];

		//	for(int i = 0; i < currentArrayLength; i++)
		//	{
		//		array[i] = MonoTestDetailArray[i];
		//	}

		//	array[currentArrayLength] = value;
		//	MonoTestDetailArray = array;
		//}
	//}
}
