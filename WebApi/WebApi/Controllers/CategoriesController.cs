namespace WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebApi.Core.Dto;
    using Domain;
    using WebApi.Core.Services;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class CategoriesController : BaseController<Categories, CategoriesDto, ICategoryService>
    {
        public CategoriesController(ICategoryService service) : base(service)
        {
        }

        public override async Task<IActionResult> Get()
        {
            return Ok(await _service.FindAllExceptPrictureAsync());
        }
    }
}
