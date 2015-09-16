using System.Runtime.Serialization;
using System.Web.Http.ModelBinding;
using ZM.SignalR.Integrations.WebApiMvc.Models.Binders;

namespace ZM.SignalR.Integrations.WebApiMvc.Models
{
    [DataContract(Namespace = "")]
    [ModelBinder(BinderType = typeof(ApiRequestBinder))]
    public class ApiRequest
    {
        [DataMember]
        public int ApiId { get; set; }

        public ApiRequest(int apiId)
        {
            this.ApiId = apiId;
        }
    }
}