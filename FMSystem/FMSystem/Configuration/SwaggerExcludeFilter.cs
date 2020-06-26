using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using FMSystem.ViewModels;

namespace FMSystem.Configuration
{
    public class SwaggerExcludeFilter : ISchemaFilter
    {
        internal static string ToCamelCase(string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return char.ToLowerInvariant(value[0]) + value.Substring(1);
        }
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema.Properties.Count == 0)
                return;

            var excludeProperties = context.Type?.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(BindNeverAttribute)));
            if (excludeProperties != null)
            {
                foreach (var property in excludeProperties)
                {
                    // Because swagger uses camel casing
                    var propertyName = $"{char.ToLowerInvariant(property.Name[0])}{property.Name.Substring(1)}";
                    if (schema.Properties.ContainsKey(propertyName))
                    {
                        schema.Properties.Remove(propertyName);
                    }
                }
            }
        }

    }
}
