using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace CsvWebApp.Models
{
    public class CsvReader
    {
        public List<T> ReadFile<T>(string csv)
            where T : class, new()
        {
            var result = new List<T>();

            using (FileStream fs = new FileStream(csv, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string[] headers = GetHeaderNames(sr);
                    Dictionary<string, PropertyInfo> propsDic = GetEntityPropertyDict<T>(headers);

                    while (true)
                    {
                        string line = sr.ReadLine();
                        if (line == null) break;

                        T item = GetEntity<T>(headers, propsDic, line);
                        result.Add(item);
                    }
                }
            }

            return result;
        }

        private T GetEntity<T>(string[] headers, Dictionary<string, PropertyInfo> propsDic, string line) where T : class, new()
        {
            T item = new T();
            string[] values = line.Split(',');
            for (int idx = 0; idx < headers.Length; idx++)
            {
                string header = headers[idx];
                string value = values[idx];

                if (!propsDic.ContainsKey(header)) continue;
                var prop = propsDic[header];
                object propValue = StringToPropertyValue(prop, value);
                prop.SetValue(item, propValue);
            }
            return item;
        }

        private Dictionary<string, PropertyInfo> GetEntityPropertyDict<T>(string[] headers) where T : class, new()
        {
            var propsDic = new Dictionary<string, PropertyInfo>();
            foreach (string header in headers)
            {
                PropertyInfo pi = typeof(T).GetProperty(header);
                if (pi == null) continue;
                propsDic[header] = pi;
            }
            return propsDic;
        }

        private string[] GetHeaderNames(StreamReader sr)
        {
            string headerLine = sr.ReadLine();

            string[] headers = headerLine.Split(',');
            return headers;
        }

        public object StringToPropertyValue(PropertyInfo prop, string text)
        {
            if (prop.PropertyType == typeof(DateTime))
            {
                DateTime oDateTime = DateTime.ParseExact(text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                return oDateTime;
            }

            if (prop.PropertyType == typeof(int))
            {
                return Int32.Parse(text);
            }
            return text;
        }
    }
}