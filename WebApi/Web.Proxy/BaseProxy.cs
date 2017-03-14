namespace Web.Proxy.NetCore
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public abstract class BaseProxy: IBaseProxy
    {
        protected Uri ServiceUri { get; set; }

        public BaseProxy(string url)
        {
            ServiceUri = new Uri(url);
        }

        public abstract Task<IDictionary<string, string>> EnsureApiTokenAsync(string userName, string password);

        public abstract Task<IDictionary<string, string>> RefreshApiTokenAsync(string refreshId);

        public virtual async Task<HttpResponseMessage> GetAsync(string endpoint)
        {
            using (var client = GetHttpClient())
            {
                return await client.GetAsync(endpoint);
            }
        }

        public virtual async Task<HttpResponseMessage> PostJsonAsync(string endpoint, object data)
        {
            using (var client = GetHttpClient())
            {
                return await client.PostAsync(endpoint, ObjectToHttpContent(data));
            }
        }

        public virtual async Task<HttpResponseMessage> PostAsync(string endpoint, HttpContent data)
        {
            using (var client = GetHttpClient())
            {
                return await client.PostAsync(endpoint, data);
            }
        }

        public virtual async Task<HttpResponseMessage> PutJsonAsync(string endpoint, object data)
        {
            using (var client = GetHttpClient())
            {
                return await client.PutAsync(endpoint, ObjectToHttpContent(data));
            }
        }

        public virtual async Task<HttpResponseMessage> PutAsync(string endpoint, HttpContent data)
        {
            using (var client = GetHttpClient())
            {
                return await client.PutAsync(endpoint, data);
            }
        }

        public virtual async Task<HttpResponseMessage> DeleteAsync(string endpoint)
        {
            using (var client = GetHttpClient())
            {
                return await client.DeleteAsync(endpoint);
            }
        }

        protected abstract HttpClient GetHttpClient();

        private StringContent ObjectToHttpContent(object data)
        {
            var content = Newtonsoft.Json.JsonConvert.SerializeObject(data);

            return new StringContent(content, System.Text.Encoding.UTF8, "text/json");
        }
    }
}
