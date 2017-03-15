namespace Web.MVC6.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Web.MVC6.ViewModels;

    public interface IProductsService
    {
        Task<IEnumerable<ProductViewModel>> GetAllAsync();

        Task<ProductViewModel> GetByIdAsync(int id);

        Task<ProductViewModel> CreateAsync(ProductViewModel model);

        Task<ProductViewModel> UpdateAsync(ProductViewModel model);

        Task DeleteAsync(int id);
    }
}
