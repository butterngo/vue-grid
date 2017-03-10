namespace WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebApi.Core.Dto;
    using Domain;
    using WebApi.Core.Services;

    [Route("api/[controller]")]
    public class RegionController : BaseController<Region, RegionDto, IRegionService>
    {
        public RegionController(IRegionService service) : base(service)
        {
        }

    }
}