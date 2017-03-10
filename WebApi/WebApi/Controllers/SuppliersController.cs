namespace WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebApi.Core.Dto;
    using Domain;
    using WebApi.Core.Services;

    [Route("api/[controller]")]
    public class SuppliersController : BaseController<Suppliers, SuppliersDto, ISuppliersService>
    {
        public SuppliersController(ISuppliersService service) : base(service)
        {
        }

    }
}