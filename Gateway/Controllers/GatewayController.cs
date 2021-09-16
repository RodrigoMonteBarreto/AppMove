using System.Net.Http;
using System.Threading.Tasks;
using Gateway.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GatewayController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();

        [HttpPost]
        public async Task<IActionResult> Post(Compra model)
        {
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/Compra");

            string responsybody = await response.Content.ReadAsStringAsync();

            return Ok(responsybody);

        }
    }
}
