namespace Web.MVC6.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Web.MVC6.ViewModels;
    using Web.Proxy.NetCore;
    using WebApi.Dto;

    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(IPoxyService proxyService) : base(proxyService)
        {
        }

        public async Task<CategoryViewModel> CreateAsync(CategoryViewModel model)
        {
            var dto = VMToDto<CategoryViewModel, CategoriesDto>(model);

            var response = await _proxyService.PostJsonAsync("api/categories", dto);

            return DtoToVM<CategoriesDto, CategoryViewModel>(response);
        }

        public async Task<CategoryViewModel> UpdateAsync(CategoryViewModel model)
        {
            var dto = VMToDto<CategoryViewModel, CategoriesDto>(model);

            var response = await _proxyService.PutJsonAsync("api/categories", dto);

            return model;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllAsync()
        {
            var response = await _proxyService.GetAsync("api/categories");

            return DtoToVM<IEnumerable<CategoriesDto>, IEnumerable<CategoryViewModel>>(response);
        }

        public async Task<CategoryViewModel> GetByIdAsync(int id)
        {
            var response = await _proxyService.GetAsync("api/categories/" + id);

            return DtoToVM<CategoriesDto, CategoryViewModel>(response);
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _proxyService.DeleteAsync("api/categories/" + id);

            if (response.StatusCode != System.Net.HttpStatusCode.OK) throw new Exception(await response.Content.ReadAsStringAsync());
        }
    }
}
