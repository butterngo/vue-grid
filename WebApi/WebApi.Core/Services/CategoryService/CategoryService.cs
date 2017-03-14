namespace WebApi.Core.Services
{
    using WebApi.Domain;
    using WebApi.Dto;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CategoryService : ServiceBase<Categories, CategoriesDto>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IEnumerable<CategoriesDto>> FindAllExceptPrictureAsync()
        {
            var result = await _unitOfWork.CategoriesRepository.FindAllExceptPrictureAsync();

            return EntityToDto(result);
        }
    }
}
