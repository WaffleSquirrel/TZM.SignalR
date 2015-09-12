using System.ComponentModel;

namespace ZM.SignalR.Integrations.WebApiMvc.Models
{
    public class Human
    {
        public int Id { get; set; }

        public string Gender { get; set; }

        public string NoteToSelf { get; set; }
    }
}