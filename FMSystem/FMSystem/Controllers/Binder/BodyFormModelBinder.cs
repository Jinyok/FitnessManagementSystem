using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace FMSystem.Controllers.Binder
{
    public class BodyFormModelBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var request = bindingContext.ActionContext.HttpContext.Request;

            Type type = bindingContext.ModelType;

            if (request.HasFormContentType && request.Form.Any())
            {
                var result = Activator.CreateInstance(type);

                // set each field to the model usign reflection
                foreach (var entry in request.Form)
                {
                    // Set the value of the given property on the given instance
                    var piInstance = type.GetProperty(entry.Key);
                    // set only if property is found
                    piInstance?.SetValue(result, entry.Value.FirstOrDefault());
                }

                bindingContext.Result = ModelBindingResult.Success(result);
            }
            else
            {
                // treat as JSON
                var body = await (new StreamReader(request.Body)).ReadToEndAsync();

                //var deserialized = JsonConvert.DeserializeObject(body, type);
                var deserialized = System.Text.Json.JsonSerializer.Deserialize(body, type);

                bindingContext.Result = ModelBindingResult.Success(deserialized);
            }
        }
    }
}
