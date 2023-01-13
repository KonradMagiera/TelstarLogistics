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
using TelstarLogistics.Services.RoutePlanning;

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
            if (collaborationID != "f87c9339-ff39-4225-be09-fca238a03ede")
            {
                return Unauthorized();
            }
            var correlationIDHeader = correlationID;

            if (request.Weight == 0 || (request.Weight != null && request.Weight > 40))
            {
                return BadRequest("Weight cannot be null, 0 or over 40 kg");
            }
            float priceMultiplier = 1.00f;
            if (request.Type == "liveAnimals")
            {
                priceMultiplier = 1.50f;
            }
            else if (request.Type == "cautionsParcels")
            {
                priceMultiplier = 1.75f;
            }
            else if (request.Type == "refrigertedGoods")
            {
                priceMultiplier = 1.10f;
            }

            Dijkstra dijkstra = new Dijkstra();

            var travelDistance = dijkstra.GetRoute(request.From, request.To, true, false, out var path);

            return Ok(new IntegrationResponse(travelDistance * 3, travelDistance * 4, correlationID));
        }
    }
}
