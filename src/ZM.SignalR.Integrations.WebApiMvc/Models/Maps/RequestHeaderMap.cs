using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace ZM.SignalR.Integrations.WebApiMvc.Models.Maps
{
    public class RequestHeaderMap
    {
        private Dictionary<string, string> headersCollection;

        public RequestHeaderMap(HttpHeaders headers)
        {
            this.headersCollection = headers.ToDictionary(
                  x => x.Key.ToLower().Replace("-", string.Empty),
                  x => string.Join(",", x.Value)
            );
        }

        public string this[string header]
        {
            get
            {
                string key = header.ToLower();

                return headersCollection.ContainsKey(key) ? headersCollection[key] : null;
            }
        }

        public bool ContainsHeader(string header)
        {
            return this[header] != null;
        }
    }
}