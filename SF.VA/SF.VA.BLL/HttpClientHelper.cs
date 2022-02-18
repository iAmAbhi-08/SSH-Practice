using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SF.VA.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SF.VA.BLL
{
     public class HttpClientHelper : IHttpClientHelper
    {
        private ILogger<IHttpClientHelper> _logger;

        public HttpClientHelper(ILogger<IHttpClientHelper> logger)
        {
            _logger = logger;
        }
        public async Task<string> GetAsync(string requestUri)
        {
            using HttpClientHandler httpClientHandler = new HttpClientHandler();
            using HttpClient httpClient = new HttpClient(httpClientHandler);
            var result = await ProcessingHttpResponse(await httpClient.GetAsync(requestUri));
            return result;
        }

        public async Task<string> PutAsync<T>(string requestUri, T request) where T : class
        {
            using HttpClientHandler httpClientHandler = new HttpClientHandler();
            using HttpClient httpClient = new HttpClient(httpClientHandler);

            var json = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var httpResponseMessage = await httpClient.PutAsync(requestUri, httpContent);
            return await ProcessingHttpResponse(httpResponseMessage);
        }

        public async Task<string> PostAsync<T>(string requestUri, T request) where T : class
        {
            using HttpClientHandler httpClientHandler = new HttpClientHandler();
            using HttpClient httpClient = new HttpClient(httpClientHandler);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json)
            { Headers = { ContentType = new MediaTypeHeaderValue("application/json") } };

            var result = await ProcessingHttpResponse(await httpClient.PostAsync(requestUri, httpContent));
            return result;
        }

        public async Task<string> DeleteAsync(string requestUri)
        {
            using HttpClientHandler httpClientHandler = new HttpClientHandler();
            using HttpClient httpClient = new HttpClient(httpClientHandler);

            var toDelete = await httpClient.DeleteAsync(requestUri);
            return await ProcessingHttpResponse(await httpClient.DeleteAsync(requestUri));
            
        }

        private async Task<string> ProcessingHttpResponse(HttpResponseMessage httpResponseMessage)
        {
            var result = await httpResponseMessage.Content.ReadAsStringAsync();
            return result;
        }

        

    }
}
