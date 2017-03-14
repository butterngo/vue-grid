namespace WebApi.Core.Services
{
    using Domain;
    using WebApi.Dto;

    public interface IProductsService: IServiceBase<Products, ProductsDto>
    {
    }
}
