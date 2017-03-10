namespace WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebApi.Core.Dto;
    using Domain;
    using WebApi.Core.Services;

    [Route("api/[controller]")]
    public class OrderDetailController : BaseController<OrderDetails, OrderDetailsDto, IOrderDetailsService>
    {
        public OrderDetailController(IOrderDetailsService service) : base(service)
        {
        }

    }
}