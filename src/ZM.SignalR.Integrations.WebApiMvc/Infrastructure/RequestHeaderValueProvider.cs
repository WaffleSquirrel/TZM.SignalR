using System.Globalization;
using System.Linq;
using System.Web.Http.ValueProviders;

namespace ZM.SignalR.Integrations.WebApiMvc.Infrastructure
{
    public class RequestHeaderValueProvider : IValueProvider
    {
        private RequestHeaderMap headers;

        public RequestHeaderValueProvider(RequestHeaderMap map)
        {
            headers = map;
        }

        public ValueProviderResult GetValue(string key)
        {
            string value = headers[key.Split('.').Last()];

            return value == null
                ? null
                : new ValueProviderResult(value, value, CultureInfo.InvariantCulture);
        }

        public bool ContainsPrefix(string prefix)
        {
            return false;
        }
    }
}