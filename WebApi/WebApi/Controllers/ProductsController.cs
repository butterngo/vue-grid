namespace WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebApi.Core.Dto;
    using Domain;
    using WebApi.Core.Services;

    [Route("api/[controller]")]
    public class ProductsController : BaseController<Products, ProductsDto, IProductsService>
    {
        public ProductsController(IProductsService service) : base(service)
        {
        }

    }
}