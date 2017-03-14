namespace WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebApi.Dto;
    using Domain;
    using WebApi.Core.Services;

    [Route("api/[controller]")]
    public class TerritoriesController : BaseController<Territories, TerritoriesDto, ITerritoriesService>
    {
        public TerritoriesController(ITerritoriesService service) : base(service)
        {
        }

    }
}