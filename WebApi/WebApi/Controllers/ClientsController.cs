namespace WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebApi.Dto;
    using Domain;
    using WebApi.Core.Services;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class ClientsController : BaseController<Client, ClientDto, IClientService>
    {
        public ClientsController(IClientService service) : base(service)
        {
        }

        [HttpGet, Route("GenerateHeader")]
        public async Task<IActionResult> GenerateHeader()
        {
            return Ok(await _service.GenerateHeaderAsync("admin"));
        }
    }
}