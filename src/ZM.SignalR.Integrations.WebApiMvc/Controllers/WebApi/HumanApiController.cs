using System;
using System.Threading.Tasks;
using System.Web.Http;
using ZM.SignalR.Integrations.WebApiMvc.Infrastructure.Communication.Hubs;
using ZM.SignalR.Integrations.WebApiMvc.Infrastructure.WebApi;
using ZM.SignalR.Integrations.WebApiMvc.Models;

namespace ZM.SignalR.Integrations.WebApiMvc.Controllers.WebApi
{
    [RoutePrefix("api/humans")]
    public class HumanApiController : BaseWebApiHubController<ConnectionBroadcaster>
    {
        /// <summary>
        /// Retrieves a Human by unique identifier.
        /// </summary>
        /// <param name="humanId">The unique identifier of a Human to retrieve.</param>
        /// <returns>
        /// If found, returns a successful response to a consumer which includes a materialized
        /// Human, otherwise returns an unsucessful response to a consumer with a message.
        /// </returns>
        /// <example>GET api/humans/get-human/5?guessednumber=25</example>
        [HttpGet]
        [Route("get-human/{humanId}/{guessedNumber}")]
        public IHttpActionResult HumanSearch(HumanRequest humanRequest)
        {
            if (humanRequest == null || humanRequest.Id < 1 || humanRequest.Id > 10)
            {
                return BadRequest();
            }

            if (humanRequest.Id != 1)
            {
                return NotFound();
            }

            var gender = humanRequest.Gender;
            var humanId = humanRequest.Id;
            var guessedNumber = humanRequest.GuessedNumber;
            var human = new Human() { Id = humanId, Gender = gender };

            if (guessedNumber == 69)
            {
                human.NoteToSelf = "You most likely have a dirty mind.";
            }
            else
            {
                human.NoteToSelf = "You are pretty.";
            }

            var humanResponse = new HumanResponse() { Human = human };

            return Ok<HumanResponse>(humanResponse);
        }

        /// <summary>
        /// Sends a posted message from one connected Human to all the other connected Humans, if any.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("send-message")]
        public async Task<string> SendMessageToHumans()
        {
            const string responseMessageFormatString = "[{0}]:> {1}";

            await this.Clients.All.Message("Web API action was invoked! Whoa dude!");

            return string.Format(responseMessageFormatString, DateTime.Now.ToString("hh:mm:ss"), "Hola from the server.");
        }
    }
}