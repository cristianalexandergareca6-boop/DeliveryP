using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Delivery.Data;
using Delivery.Entidades;

namespace Delivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepartidoresController : ControllerBase
    {
        private readonly AppDbContext _contexto;

        public RepartidoresController(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Repartidor>>> GetRepartidores()
        {
            var lista = await _contexto.Repartidores.ToListAsync();
            return Ok(lista);
        }

        [HttpGet("activos")]
        public async Task<ActionResult<ICollection<Repartidor>>> GetRepartidoresActivos()
        {
            var lista = await _contexto.Repartidores
                .Where(r => r.Disponible == true)
                .ToListAsync();

            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Repartidor>> GetRepartidor(Guid id)
        {
            var repartidor = await _contexto.Repartidores.FindAsync(id);

            if (repartidor == null)
                return NotFound();

            return Ok(repartidor);
        }

        [HttpPost]
        public async Task<ActionResult<Repartidor>> CreateRepartidor([FromBody] Repartidor repartidor)
        {
            _contexto.Repartidores.Add(repartidor);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRepartidor), new { id = repartidor.Id }, repartidor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRepartidor(Guid id, [FromBody] Repartidor repartidor)
        {
            if (id != repartidor.Id)
                return BadRequest("ID incorrecto");

            var existing = await _contexto.Repartidores.FindAsync(id);
            if (existing == null)
                return NotFound();

            existing.Nombre = repartidor.Nombre;
            existing.Telefono = repartidor.Telefono;
            existing.PlacaVehiculo = repartidor.PlacaVehiculo;
            existing.Disponible = repartidor.Disponible;

            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepartidor(Guid id)
        {
            var repartidor = await _contexto.Repartidores.FindAsync(id);

            if (repartidor == null)
                return NotFound();

            _contexto.Repartidores.Remove(repartidor);
            await _contexto.SaveChangesAsync();

            return NoContent();
        }
    }
}