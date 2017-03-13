namespace WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebApi.Core.Dto;
    using Domain;
    using WebApi.Core.Services;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using WebApi.Common.Factories;
    using WebApi.Core.Identity;
    using WebApi.Core;

    [Route("api/[controller]")]
    [Authorize]
    public class CategoriesController : BaseController<Categories, CategoriesDto, ICategoryService>
    {
        public CategoriesController(ICategoryService service) : base(service)
        {
            //FakeData.FakeIdentity fake = new FakeData.FakeIdentity(ResolverFactory.GetService<WebApiUserManager>(), ResolverFactory.GetService<IUnitOfWork>());
            //fake.CreateUserAsync();
        }

        public override async Task<IActionResult> Get()
        {
            return Ok(await _service.FindAllExceptPrictureAsync());
        }
    }
}
