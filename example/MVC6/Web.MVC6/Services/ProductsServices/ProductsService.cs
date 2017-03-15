namespace Web.MVC6.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Web.MVC6.ViewModels;
    using Web.Proxy.NetCore;
    using WebApi.Dto;

    public class ProductsService : BaseService, IProductsService
    {
        public ProductsService(IPoxyService proxyService) : base(proxyService)
        {
        }

        public async Task<ProductViewModel> CreateAsync(ProductViewModel model)
        {
            var dto = VMToDto<ProductViewModel, ProductsDto>(model);

            var response = await _proxyService.PostJsonAsync("api/products", dto);

            return DtoToVM<ProductsDto, ProductViewModel>(response);
        }

        public async Task<ProductViewModel> UpdateAsync(ProductViewModel model)
        {
            var dto = VMToDto<ProductViewModel, ProductsDto>(model);

            var response = await _proxyService.PutJsonAsync("api/products", dto);

            return model;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
        {
            var response = await _proxyService.GetAsync("api/products");

            return DtoToVM<IEnumerable<ProductsDto>, IEnumerable<ProductViewModel>>(response);
        }

        public async Task<ProductViewModel> GetByIdAsync(int id)
        {
            var response = await _proxyService.GetAsync("api/products/" + id);

            return DtoToVM<ProductsDto, ProductViewModel>(response);
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _proxyService.DeleteAsync("api/products/" + id);

            if (response.StatusCode != System.Net.HttpStatusCode.OK) throw new Exception(await response.Content.ReadAsStringAsync());
        }
    }
}
