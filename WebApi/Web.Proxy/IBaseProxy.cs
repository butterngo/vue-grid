namespace Web.Proxy.NetCore
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface IBaseProxy
    {
        Task<IDictionary<string, string>> EnsureApiTokenAsync(string userName, string password);

        Task<IDictionary<string, string>> RefreshApiTokenAsync(string refreshId);

        Task<HttpResponseMessage> GetAsync(string endpoint);

        Task<HttpResponseMessage> PostJsonAsync(string endpoint, object data);

        Task<HttpResponseMessage> PostAsync(string endpoint, HttpContent data);

        Task<HttpResponseMessage> PutJsonAsync(string endpoint, object data);

        Task<HttpResponseMessage> PutAsync(string endpoint, HttpContent data);

        Task<HttpResponseMessage> DeleteAsync(string endpoint);
    }
}
