using System.Globalization;
using System.Linq;
using System.Web.Http.ValueProviders;
using ZM.SignalR.Integrations.WebApiMvc.Models.Maps;

namespace ZM.SignalR.Integrations.WebApiMvc.Models.ValueProviders
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
            string value = key != null && headers.ContainsHeader(key)
                ? headers[key]
                : null;

            return value != null
                ? new ValueProviderResult(value, value, CultureInfo.InvariantCulture)
                : null;
        }

        public bool ContainsPrefix(string prefix)
        {
            return false;
        }
    }
}