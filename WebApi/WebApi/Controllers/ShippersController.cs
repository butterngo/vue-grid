namespace WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebApi.Core.Dto;
    using Domain;
    using WebApi.Core.Services;

    [Route("api/[controller]")]
    public class ShippersController : BaseController<Shippers, ShippersDto, IShippersService>
    {
        public ShippersController(IShippersService service) : base(service)
        {
        }

    }
}