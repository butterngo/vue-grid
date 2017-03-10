namespace WebApi.Core.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebApi.Core.Dto;
    using WebApi.Domain;

    public interface ICategoryService: IServiceBase<Categories, CategoriesDto>
    {
        Task<IEnumerable<CategoriesDto>> FindAllExceptPrictureAsync();
    }
}
