using System.Web.Http;
using ZM.SignalR.WebApi.Models;

namespace ZM.SignalR.WebApi.Controllers
{
    [RoutePrefix("api/humans")]
    public class HumanController : ApiController
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
        public IHttpActionResult GetHuman(HumanRequest humanRequest)
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
                human.NoteToSelf = "You may not have a dirty mind.";
            }

            var humanResponse = new HumanResponse() { Human = human };

            return Ok<HumanResponse>(humanResponse);
        }
    }
}