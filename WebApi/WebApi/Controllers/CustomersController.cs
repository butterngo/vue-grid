namespace WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebApi.Dto;
    using Domain;
    using WebApi.Core.Services;

    [Route("api/[controller]")]
    public class CustomersController : BaseController<Customers, CustomersDto, ICustomersService>
    {
        public CustomersController(ICustomersService service) : base(service)
        {
        }

    }
}