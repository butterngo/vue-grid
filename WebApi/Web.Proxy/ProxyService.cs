namespace Web.Proxy.NetCore
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class ProxyService : BaseProxy, IPoxyService
    {
        private string Bearer { get; set; }

        public ProxyService(string url) : base(url)
        {
        }

        public override Task<IDictionary<string, string>> EnsureApiTokenAsync(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public override Task<IDictionary<string, string>> RefreshApiTokenAsync(string refreshId)
        {
            throw new NotImplementedException();
        }

        protected override HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = ServiceUri;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Bearer);
            return client;
        }

        public void Dispose()
        {
            //TO DO
        }
    }
}
