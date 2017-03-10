namespace WebApi.Core.Services
{
    using Domain;
    using WebApi.Core.Dto;

    public interface IProductsService: IServiceBase<Products, ProductsDto>
    {
    }
}
