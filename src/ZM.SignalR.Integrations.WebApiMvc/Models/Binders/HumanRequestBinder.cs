using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;

namespace ZM.SignalR.Integrations.WebApiMvc.Models.Binders
{
    public class HumanRequestBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            string modelName = bindingContext.ModelName;

            var headerData = new Dictionary<string, ValueProviderResult>();
            var inputData = new Dictionary<string, ValueProviderResult>();

            headerData.Add("gender", GetValue(bindingContext, "gender"));

            inputData.Add("humanId", GetValue(bindingContext, modelName, "humanId"));
            inputData.Add("guessedNumber", GetValue(bindingContext, modelName, "guessedNumber"));
            inputData.Add("accept", GetValue(bindingContext, modelName, "accept"));

            if (inputData.All(x => x.Key == "accept" || x.Value != null))
            {
                bindingContext.Model = CreateInstance(headerData, inputData);

                return true;
            }

            return false;
        }

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

        private HumanRequest CreateInstance(Dictionary<string, ValueProviderResult> headerData, Dictionary<string, ValueProviderResult> data)
        {
            var humanRequest = new HumanRequest(Convert<int>(data["humanId"]));

            humanRequest.Gender = Convert<string>(headerData["gender"]);
            humanRequest.GuessedNumber = Convert<int>(data["guessedNumber"]);
            humanRequest.Accept = Convert<string>(data["accept"]);

            return humanRequest;
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
    }
}