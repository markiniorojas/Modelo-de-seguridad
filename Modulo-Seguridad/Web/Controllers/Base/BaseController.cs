using Business.Interfaces;
using Entity.Dto.Base;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public abstract class BaseController<T> : ControllerBase where T : ModelBase
    {
        protected readonly IBaseBusiness<T> service;

        protected BaseController(IBaseBusiness<T> service)
        {
            this.service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<ActionResult<IEnumerable<T>>> Get()
        {
            var result = await service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<T>> Get(int id)
        {
            var result = await service.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<ActionResult<T>> Post([FromBody] T dto)
        {
            var createdEntity = await service.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = createdEntity.Id }, createdEntity);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Put(int id, [FromBody] T dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("El ID del cuerpo con coincide con el ID de la URL");
            }

            var exists = await service.GetByIdAsync(id);
            if (exists == null)
            {
                return NotFound();
            }

            var updated = await service.UpdateAsync(dto);
            if (!updated)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var exists = await service.GetByIdAsync(id);
            if (exists == null)
            {
                return NotFound();
            }

            var deleted = await service.DeleteAsync(id);
            if (!deleted)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpPatch("{id:int}/soft-delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> SoftDelete(int id)
        {
            var entity = await service.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            entity.is_deleted = true;
            var updated = await service.UpdateAsync(entity);
            if (!updated)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
