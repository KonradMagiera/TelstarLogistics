using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Drawing.Printing;
using System.Net;
using System.Net.Mime;
using TelstarLogistics.Models;
using TelstarLogistics.Models.ApiModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TelstarLogistics.Controllers.Integration
{
    [Route("api")]
    [ApiController]
    public class GetRouteController : ControllerBase
    {
        [HttpPost]
        [Route("GetRoute")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> GetRoute([FromHeader] string correlationID, [FromHeader] string collaborationID,
            [FromBody] GetRouteIntegrationRequest request)
        {
            if (collaborationID != "todo-env")
            {
                return Unauthorized();
            }
            var correlationIDHeader = correlationID;

            if (request.Weight == 0 || (request.Weight != null && request.Weight > 40))
            {
                return BadRequest("Weight cannot be null, 0 or over 40 kg");
            }
     

            // fetch database info based on parameters
            // process based on algo
            // map into IntegrationResponse

            // calculateAndFetchRoutes(recommended = true)
            // for each route calculate price and time it takes

            return Ok(new IntegrationResponse(0.00, 01, correlationID));
        }
    }
}
