using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SimplifaiInfo3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimplifaiInfo3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PracticeController : Controller
    {
        private readonly ExternalApiOptions _externalOptions;

        public PracticeController(IOptions<ExternalApiOptions> externalOptions)
        {
            _externalOptions = externalOptions.Value;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var client = new HttpClient();
            
            //var url = $"https://jsonplaceholder.typicode.com/todos/1";
            var response = await client.GetAsync(_externalOptions.Url);

            //var head = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));

            var newResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<Practice>(await response.Content.ReadAsStringAsync());

            return Ok(newResponse);
            
        }
    }
}
