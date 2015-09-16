using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;

namespace ZM.SignalR.Integrations.WebApiMvc.Models.Binders
{
    public class ApiRequestBinder : IModelBinder
    {
        private ValueProviderResult GetValue(ModelBindingContext context, params string[] names)
        {
            for (int i = 0; i < names.Length - 1; i++)
            {
                string prefix = string.Join(".", names.Skip(i).Take(names.Length - (i + 1)));

                if (prefix != string.Empty && context.ValueProvider.ContainsPrefix(prefix))
                {
                    return context.ValueProvider.GetValue(prefix + "." + names.Last());
                }
            }

            return context.ValueProvider.GetValue(names.Last());
        }

        private ApiRequest CreateInstance(Dictionary<string, ValueProviderResult> headerData, Dictionary<string, ValueProviderResult> data)
        {
            var apiRequest = new ApiRequest(Convert<int>(data["apiId"]));

            return apiRequest;
        }

        private T Convert<T>(ValueProviderResult result)
        {
            try
            {
                return (T)result.ConvertTo(typeof(T));
            }
            catch
            {
                return default(T);
            }
        }

        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            string modelName = bindingContext.ModelName;

            var headerData = new Dictionary<string, ValueProviderResult>();
            var inputData = new Dictionary<string, ValueProviderResult>();

            headerData.Add("ZM.ApiVersion", GetValue(bindingContext, "ZM.ApiVersion"));

            inputData.Add("apiId", GetValue(bindingContext, modelName, "apiId"));

            if (headerData.All(x => x.Key == "ZM.ApiVersion" && x.Value != null) && inputData.All(x => x.Key == "apiId" && x.Value != null))
            {
                bindingContext.Model = CreateInstance(headerData, inputData);

                return true;
            }

            return false;
        }
    }
}