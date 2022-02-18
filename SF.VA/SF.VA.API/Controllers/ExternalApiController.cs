using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SF.VA.API.Models;
using SF.VA.BLL.Interface;
using SF.VA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SF.VA.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class ExternalApiController : Controller
    {
        private readonly ExternalApiOptions _options;

        private readonly IHttpClientHelper _httpClientHelper;


        public ExternalApiController(IOptions<ExternalApiOptions> options, IHttpClientHelper httpClientHelper)
        {
            _options = options.Value;
            _httpClientHelper = httpClientHelper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _httpClientHelper.GetAsync(_options.requestUri);

            UriResponseModel [] result = JsonConvert.DeserializeObject<UriResponseModel[]>(response);

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var endPoint = _options.requestUri + "/" + id;
            var response = await _httpClientHelper.GetAsync(endPoint);

            return Ok(JsonConvert.DeserializeObject<UriResponseModel>(response));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, int UserId = 0, string Title = null, string Body = null)
        {
            var endpoint = _options.requestUri + "/" + id;
            var response = await _httpClientHelper.GetAsync(endpoint);
            var toUpdateObj = JsonConvert.DeserializeObject<UriResponseModel>(response);

            if(UserId != 0)
            {
                toUpdateObj.UserId = UserId;
            }

            if (Title != null)
            {
                toUpdateObj.Title = Title;
            }

            if (Body != null)
            {
                toUpdateObj.Body = Body;
            }

            

            var toUpdateResponse = await _httpClientHelper.PutAsync<UriResponseModel>(endpoint, toUpdateObj);

            return Ok(JsonConvert.DeserializeObject<UriResponseModel>(toUpdateResponse));
        }

        [HttpPost]

        public async Task<IActionResult> Post(UriResponseModel toPostObj)
        {
            //var toPostObj = new UriResponseModel()
            //{
            //    UserId = InputUserId,
            //    Title = InputTitle,
            //    Body = InputBody
            //};
            

            var response = await _httpClientHelper.PostAsync<UriResponseModel>(_options.requestUri, toPostObj);

            return Ok(JsonConvert.DeserializeObject<UriResponseModel>(response));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var endpoint = _options.requestUri + "/" + id;
            var response = await _httpClientHelper.DeleteAsync(endpoint);

            return Ok(JsonConvert.DeserializeObject<UriResponseModel>(response));
        }


    }
}
