namespace Web.MVC6
{
    using AutoMapper;
    using WebApi.Dto;
    using Web.MVC6.ViewModels;

    public class CommonMapper: Profile
    {
        public CommonMapper()
        {
            #region Dto To ViewModel

            CreateMap<CategoriesDto, CategoryViewModel>();

            #endregion

            #region ViewModel To Dto

            CreateMap<CategoryViewModel, CategoriesDto>();

            #endregion
        }
    }
}
