namespace WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using WebApi.Core.Services;
    using System.Threading.Tasks;
    using System;

    //[Authorize]
    public abstract class BaseController<TEntity, TDto, TService> : Controller
          where TDto : class
          where TEntity : class
          where TService : IServiceBase<TEntity, TDto>
    {

        protected readonly TService _service;

        public BaseController(TService service)
        {
            _service = service;
        }

       
        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            return Ok(await _service.FindAllAsync());
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.FindByIdAsync(id));
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody]TDto dto)
        {
            return Ok(await _service.CreateAsync(dto));
        }

        public virtual async Task<IActionResult> Put([FromBody]TDto dto)
        {
            return Ok(await _service.UpdateAsync(dto));
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }

    }
   
}