namespace WebApi.Core.Services
{
    using Domain;
    using WebApi.Core.Dto;

    public class ProductsService : ServiceBase<Products, ProductsDto>, IProductsService
    {
        public ProductsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
