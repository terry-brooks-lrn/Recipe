
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using Newtonsoft.Json;

namespace LearnosityCookbookRecipe
{
	public class Serializer
	{
        public static string SerializeCsvToJson(string csvFilePath)
        {
            // Read CSV file
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                // Deserialize CSV to a list of dictionaries
                IEnumerable<Dictionary<string, string>> records = csv.GetRecords<Dictionary<string, string>>();

                // Serialize the list of dictionaries to JSON
                string json = JsonConvert.SerializeObject(records, Formatting.Indented);

                return json;
            }
        }

        public static void DeserializeJsonToCsv(string json, string csvFilePath)
        {
            // Deserialize JSON to a list of dictionaries
            IEnumerable<Dictionary<string, string>> records = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);

            // Write the dictionaries to CSV
            using (var writer = new StreamWriter(csvFilePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }
        }
        public static string SerializeToJson(object obj)
        {
            // Serialize object to JSON
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            return json;
        }

        public static T DeserializeJson<T>(string json)
        {
            // Deserialize JSON to specified type
            T result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }
    }
}

