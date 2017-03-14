namespace WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebApi.Dto;
    using Domain;
    using WebApi.Core.Services;

    [Route("api/CustomerDemo")]
    public class CustomerCustomerDemoController : BaseController<CustomerCustomerDemo, CustomerCustomerDemoDto, ICustomerCustomerDemoService>
    {
        public CustomerCustomerDemoController(ICustomerCustomerDemoService service) : base(service)
        {
        }
    }
}