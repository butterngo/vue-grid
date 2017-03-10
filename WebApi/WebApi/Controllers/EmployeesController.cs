namespace WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebApi.Core.Dto;
    using Domain;
    using WebApi.Core.Services;

    [Route("api/[controller]")]
    public class EmployeeTerritoriesController : BaseController<EmployeeTerritories, EmployeeTerritoriesDto, IEmployeeTerritoriesService>
    {
        public EmployeeTerritoriesController(IEmployeeTerritoriesService service) : base(service)
        {
        }

    }
}