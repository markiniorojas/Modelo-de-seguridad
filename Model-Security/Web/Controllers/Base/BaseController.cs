using Entity.Dto.Base;
using Microsoft.AspNetCore.Mvc;
using Business.Interfaces;

namespace Web.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public abstract class BaseController<TEntity, TDto, TDtoGet> : ControllerBase
        where TEntity : ModelBase
    {
        protected readonly IBaseBusiness<TEntity, TDto, TDtoGet> service;

        protected BaseController(IBaseBusiness<TEntity, TDto, TDtoGet> service)
        {
            this.service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<ActionResult<IEnumerable<TDtoGet>>> Get()
        {
            var result = await service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<TDtoGet>> Get(int id)
        {
            var result = await service.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<ActionResult<TDto>> Post([FromBody] TDto dto)
        {
            var createdEntity = await service.CreateAsync(dto);
            var idProp = createdEntity?.GetType().GetProperty("Id")?.GetValue(createdEntity);
            return CreatedAtAction(nameof(Get), new { id = idProp }, createdEntity);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Put(int id, [FromBody] TDto dto)
        {
            var exists = await service.GetByIdAsync(id);
            if (exists == null)
                return NotFound();

            var updated = await service.UpdateAsync(dto);
            if (!updated)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var exists = await service.GetByIdAsync(id);
            if (exists == null)
                return NotFound();

            var deleted = await service.DeleteAsync(id);
            if (!deleted)
                return BadRequest();

            return NoContent();
        }

        [HttpPatch("{id:int}/soft-delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> SoftDelete(int id)
        {
            var entity = await service.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            // Este método depende de si el DTOGet o DTO tiene is_deleted
            var prop = entity.GetType().GetProperty("is_deleted");
            if (prop != null)
                prop.SetValue(entity, true);

            var updated = await service.UpdateAsync((TDto)(object)entity);
            if (!updated)
                return BadRequest();

            return NoContent();
        }
    }
}
