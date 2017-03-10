namespace WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebApi.Core.Dto;
    using Domain;
    using WebApi.Core.Services;

    [Route("api/[controller]")]
    public class EmployeesController : BaseController<Employees, EmployeesDto, IEmployeesService>
    {
        public EmployeesController(IEmployeesService service) : base(service)
        {
        }

    }
}