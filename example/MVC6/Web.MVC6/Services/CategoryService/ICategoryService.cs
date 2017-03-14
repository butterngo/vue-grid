namespace Web.MVC6.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Web.MVC6.ViewModels;

    public interface ICategoryService
    {
        Task DeleteAsync(int id);

        Task<CategoryViewModel> CreateAsync(CategoryViewModel model);

        Task<CategoryViewModel> UpdateAsync(CategoryViewModel model);

        Task<IEnumerable<CategoryViewModel>> GetAllAsync();

        Task<CategoryViewModel> GetByIdAsync(int id);
    }
}
