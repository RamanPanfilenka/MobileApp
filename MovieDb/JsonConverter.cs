using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDb
{
    public class JsonConverter
    {
        public static IEnumerable<T> DeserializeList<T>(string json) {
            var jsonResponse = JObject.Parse(json);
            var objectsJson = (JArray)jsonResponse["results"];
            var objects = objectsJson.ToObject<IEnumerable<T>>();

            return objects;
        }
    }
}
