using System.Runtime.Serialization;
using System.Web.Http.ModelBinding;
using ZM.SignalR.WebApi.Models.Binders;

namespace ZM.SignalR.WebApi.Models
{
    [DataContract(Namespace = "")]
    [ModelBinder(BinderType = typeof(HumanRequestBinder))]
    public class HumanRequest
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public int GuessedNumber { get; set; }

        public string Accept { get; set; }

        public HumanRequest(int humanId, string gender = null)
        {
            this.Id = humanId;
            this.Gender = gender;
        }
    }
}