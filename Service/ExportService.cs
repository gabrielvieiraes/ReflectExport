using System.Collections;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReflectExport.Attributes;

namespace ReflectExport.Service
{
    public class ExportService : IExportService
    {
        public string ExportCSV<T>(T values)
        {
            var output = new StringBuilder();

            var type = typeof(T);

            if (typeof(IEnumerable).IsAssignableFrom(type) && type.IsGenericType)
            {
                type = type.GetGenericArguments()[0];
            }

            var properties = type.GetProperties()
                .Where(p => Attribute.IsDefined(p, typeof(ExportColumnAttribute)))
                .Select(p => new
                {
                    Property = p,
                    ColumnName = (p.GetCustomAttribute(typeof(ExportColumnNameAttribute)) as ExportColumnNameAttribute)?.Name ?? p.Name
                })
                .ToList();

            output.AppendLine(string.Join(",", properties.Select(p => p.ColumnName)));

            if (values is IEnumerable enumerable)
            {
                foreach (var item in enumerable)
                {
                    var row = properties.Select(p =>
                    {
                        var value = p.Property.GetValue(item);

                        return value?.ToString() ?? string.Empty;
                    });

                    output.AppendLine(string.Join(",", row));
                }
            }

            return output.ToString();
        }

        public string ExportJson<T>(T values)
        {
            var type = typeof(T);

            if (typeof(IEnumerable).IsAssignableFrom(type) && type.IsGenericType)
            {
                type = type.GetGenericArguments()[0];
            }

            var properties = type.GetProperties()
                .Where(p => Attribute.IsDefined(p, typeof(ExportColumnAttribute)))
                .Select(p => new
                {
                    Property = p,
                    ColumnName = (p.GetCustomAttribute(typeof(ExportColumnNameAttribute)) as ExportColumnNameAttribute)?.Name ?? p.Name
                })
                .ToList();

            JArray jsonArray = new JArray();

            if (values is IEnumerable enumerable)
            {
                foreach (var item in enumerable)
                {
                    JObject jsonObject = new JObject();

                    foreach (var property in properties)
                    {
                        var value = property.Property.GetValue(item);
                        jsonObject[property.ColumnName] = value != null ? JToken.FromObject(value) : JValue.CreateNull();
                    }

                    jsonArray.Add(jsonObject);
                }
            }

            return jsonArray.ToString(Formatting.Indented);
        }
    }
}
