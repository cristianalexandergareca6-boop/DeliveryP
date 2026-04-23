using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Delivery.Data;
using Delivery.Entidades;

namespace Delivery.Controllers
{
    public class LocalController : BaseApiController
    {
        private readonly AppDbContext _contexto;

        public LocalController(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Local>>> GetLocales()
        {
            var locales = await _contexto.Locales
                .AsNoTracking()
                .ToListAsync();

            return Ok(locales);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Local>> GetLocal(Guid id)
        {
            var local = await _contexto.Locales.FindAsync(id);

            if (local == null)
                return NotFound();

            return Ok(local);
        }

        [HttpPost]
        public async Task<ActionResult<Local>> CreateLocal([FromBody] Local local)
        {
            local.Id = Guid.NewGuid();

            _contexto.Locales.Add(local);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLocal), new { id = local.Id }, local);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocal(Guid id, [FromBody] Local local)
        {
            if (id != local.Id)
                return BadRequest();

            var existing = await _contexto.Locales.FindAsync(id);

            if (existing == null)
                return NotFound();

            existing.Nombre = local.Nombre;
            existing.Direccion = local.Direccion;
            existing.Telefono = local.Telefono;
            existing.TipoComida = local.TipoComida;

            await _contexto.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocal(Guid id)
        {
            var local = await _contexto.Locales.FindAsync(id);

            if (local == null)
                return NotFound();

            _contexto.Locales.Remove(local);
            await _contexto.SaveChangesAsync();

            return NoContent();
        }
    }
}
