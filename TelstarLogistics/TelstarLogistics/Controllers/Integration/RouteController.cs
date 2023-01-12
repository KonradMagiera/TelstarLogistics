using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using TelstarLogistics.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TelstarLogistics.Controllers.Integration
{
    // [Route("api/[controller]")]
    [Route("api")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        // headers: correlationID, collaborationID
        // GET: api/<APIController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public IntegrationResponse Get([FromHeader] string correlationID)
        {
            var correlation = correlationID;
            Console.WriteLine(123);

            // fetch database info based on parameters
            // process based on algo
            // map into IntegrationResponse

            return new IntegrationResponse(0.00, 01, "123");
        }
        // header: correlationID, collaborationID
        // parameters: from, to, type, arrivalTime, currency, weight, height, width, depth, recommended

        // returns cost(double), duration(float), correlationID(string)

    }
}
