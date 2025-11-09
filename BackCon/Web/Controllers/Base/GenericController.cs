using Microsoft.AspNetCore.Mvc;
using Business.Interfaces.Base;
using Entitys.Models.Base;

namespace Web.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public abstract class GenericController<TEntity, TDtoRequest, TDtoResponse> : ControllerBase
        where TEntity : BaseModel
    {
        protected readonly IBaseBusiness<TEntity, TDtoRequest, TDtoResponse> _service;

        protected GenericController(IBaseBusiness<TEntity, TDtoRequest, TDtoResponse> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TDtoResponse>>> Get()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public virtual async Task<ActionResult<TDtoResponse>> Get(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public virtual async Task<ActionResult<TDtoResponse>> Post([FromBody] TDtoRequest dto)
        {
            var created = await _service.CreateAsync(dto);
            var id = created?.GetType().GetProperty("Id")?.GetValue(created);
            return CreatedAtAction(nameof(Get), new { id }, created);
        }

        [HttpPut("{id:int}")]
        public virtual async Task<IActionResult> Put(int id, [FromBody] TDtoRequest dto)
        {
            var exists = await _service.GetByIdAsync(id);
            if (exists == null)
                return NotFound();

            var updated = await _service.UpdateAsync(dto);
            if (!updated)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var exists = await _service.GetByIdAsync(id);
            if (exists == null)
                return NotFound();

            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return BadRequest();

            return NoContent();
        }
    }
}
