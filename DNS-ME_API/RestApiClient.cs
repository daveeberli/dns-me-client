using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DnsMeApi
{
    /// <summary>
    /// Base client for the dns-me rest api
    /// </summary>
    public class RestApiClient : IDisposable
    {
        private const string BaseAddress = "http://api.dns-me.com";
        private HttpClient client;

        /// <summary>
        /// Smart-me API Call without Authentication
        /// </summary>
        public RestApiClient()
        {
            this.CreateClient();
        }

        private void CreateClient()
        {
            this.client = new HttpClient();
            this.client.BaseAddress = new Uri(BaseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Gets the http client
        /// </summary>
        public HttpClient Client
        {
            get { return this.client; }
        }

        public void Dispose()
        {
            this.client.Dispose();
        }
    }
}
