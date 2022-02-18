using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SF.VA.BLL.Interface
{
    public interface IHttpClientHelper
    {
        public Task<string> GetAsync(string requestUri);

        public Task<string> PutAsync<T>(string requestUri, T request) where T : class;

        public Task<string> PostAsync<T>(string requestUri, T request) where T : class;

        public Task<string> DeleteAsync(string requestUri);
    }
}
