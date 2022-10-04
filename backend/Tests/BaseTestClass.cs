using backend;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    [Collection("InMemoryDbContext")]
    public abstract class BaseTestClass
    {
        protected readonly AdaptedWebApplicationFactory<backend.Startup> _factory;
        public BaseTestClass(AdaptedWebApplicationFactory<backend.Startup> factory)
        {
            _factory = factory;
        }

        private static async Task<T> GetReturnedObject<T>(HttpResponseMessage response)
        {
            var responseString = await response.Content.ReadAsStringAsync();
            var responseDTO = JsonConvert.DeserializeObject<T>(responseString);
            Assert.NotNull(responseDTO);
            return responseDTO;
        }

        protected HttpClient CreateClient()
        {
            var client = _factory.CreateClient();
            return client;
        }

        private static void TestResponse(HttpResponseMessage response)
        {
            var responseString = response.Content.ReadAsStringAsync().Result; //Used for debugging to see error message from service
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                throw new NotFoundException("", Guid.Empty);
            else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                throw new DuplicateException("");
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                throw new InvalidOperationException("");
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new UnauthorizedAccessException("");
            else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                throw new UnauthorizedAccessException("");

            Assert.True(response.IsSuccessStatusCode);
        }

        protected static async Task<HttpResponseMessage> Post(HttpClient client, string url, object o)
        {
            string json = JsonConvert.SerializeObject(o);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);
            TestResponse(response);

            return response;
        }

        protected static async Task<T> Post<T>(HttpClient client, string url, object o)
        {
            return await GetReturnedObject<T>(await Post(client, url, o));
        }

        protected static async Task<HttpResponseMessage> Put(HttpClient client, string url, object o)
        {
            StringContent content;
            if (o != null)
            {
                string json = JsonConvert.SerializeObject(o);
                content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            else
            {
                content = new StringContent("", Encoding.UTF8, "application/json");
            }

            var response = await client.PutAsync(url, content);
            TestResponse(response);

            return response;
        }

        protected static async Task<T> Put<T>(HttpClient client, string url, object o = null)
        {
            return await GetReturnedObject<T>(await Put(client, url, o));
        }

        protected static async Task<HttpResponseMessage> Delete(HttpClient client, string url)
        {
            var response = await client.DeleteAsync(url);
            TestResponse(response);

            return response;
        }

        protected static async Task<T> Delete<T>(HttpClient client, string url)
        {
            return await GetReturnedObject<T>(await Delete(client, url));
        }

        protected static async Task<T> Get<T>(HttpClient client, string url)
        {
            var response = await client.GetAsync(url);
            TestResponse(response);

            return await GetReturnedObject<T>(response);
        }

        protected static async Task<Stream> GetStream(HttpClient client, string url)
        {
            var response = await client.GetAsync(url);
            TestResponse(response);
            return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        }
    }
}
