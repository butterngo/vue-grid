namespace WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebApi.Dto;
    using Domain;
    using WebApi.Core.Services;

    [Route("api/[controller]")]
    public class OrdersController : BaseController<Orders, OrdersDto, IOrdersService>
    {
        public OrdersController(IOrdersService service) : base(service)
        {
        }

    }
}