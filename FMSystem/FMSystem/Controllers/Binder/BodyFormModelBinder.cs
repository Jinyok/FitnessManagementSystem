using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

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
    //public class CustomBinderProvider : IModelBinderProvider
    //{
    //    public IModelBinder GetBinder(ModelBinderProviderContext context)
    //    {
    //        if (context == null)
    //        {
    //            throw new ArgumentNullException(nameof(context));
    //        }

    //        if (context.Metadata.IsComplexType && !context.Metadata.IsCollectionType)
    //        {
    //            var propertyBinders = new Dictionary<ModelMetadata, IModelBinder>();
    //            for (var i = 0; i < context.Metadata.Properties.Count; i++)
    //            {
    //                var property = context.Metadata.Properties[i];
    //                propertyBinders.Add(property, context.CreateBinder(property));
    //            }

    //            //var loggerFactory = context.Services.GetRequiredService<ILoggerFactory>();
    //            //return new ComplexTypeModelBinder(propertyBinders, loggerFactory);
    //            return new CustomBinder(propertyBinders);
    //        }

    //        return null;
    //    }

    //}
    //public class CustomBinder : ComplexTypeModelBinder
    //{
    //    private readonly IDictionary<ModelMetadata, IModelBinder> _propertyBinders;
    //    public CustomBinder(IDictionary<ModelMetadata, IModelBinder> propertyBinders)
    //    : base(propertyBinders,null)
    //    {
    //        _propertyBinders = propertyBinders;
    //    }
    //    protected override Task BindProperty(ModelBindingContext bindingContext)
    //    {
    //        if (bindingContext.FieldName == "BinderValue")
    //        {
    //            bindingContext.Result = ModelBindingResult.Success("BinderValueTest");
    //            return Task.CompletedTask;
    //        }
    //        else
    //        {
    //            return base.BindProperty(bindingContext);
    //        }
    //    }
    //    protected override void SetProperty(ModelBindingContext bindingContext, string modelName, ModelMetadata propertyMetadata, ModelBindingResult result)
    //    {
    //        base.SetProperty(bindingContext, modelName, propertyMetadata, result);
    //    }
    //}
}
