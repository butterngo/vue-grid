namespace WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebApi.Core.Dto;
    using Domain;
    using WebApi.Core.Services;

    [Route("api/[controller]")]
    public class CustomerDemographicsController : BaseController<CustomerDemographics, CustomerDemographicsDto, ICustomerDemographicsService>
    {
        public CustomerDemographicsController(ICustomerDemographicsService service) : base(service)
        {
        }

    }
}