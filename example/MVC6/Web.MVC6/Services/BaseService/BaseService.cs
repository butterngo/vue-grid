namespace Web.MVC6.Services
{
    using WebApi.Common.Helpers;
    using System.Net.Http;
    using Proxy.NetCore;
    using System.Linq;
    using AutoMapper;

    public class BaseService
    {
        protected readonly IPoxyService _proxyService;

        public BaseService(IPoxyService proxyService)
        {
            _proxyService = proxyService;
        }

        protected TResult GetResult<TResult>(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();

            string json = AsyncHelper.RunSync(() => response.Content.ReadAsStringAsync());

            return json.JsonToDto<TResult>();
        }

        protected TViewModel DtoToVM<TDto, TViewModel>(HttpResponseMessage response)
            where TViewModel : class
            where TDto : class
        {
            return DtoToVM<TDto, TViewModel>(GetResult<TDto>(response));
        }

        protected TViewModel DtoToVM<TDto, TViewModel>(TDto dto)
            where TViewModel : class
            where TDto : class
        {
            return Mapper.Map<TViewModel>(dto);
        }

        protected TDto VMToDto<TViewModel, TDto>(TViewModel model)
            where TViewModel : class
            where TDto : class
        {
            return Mapper.Map<TDto>(model);
        }
    }
}
