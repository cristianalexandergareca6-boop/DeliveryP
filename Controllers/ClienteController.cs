using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Delivery.Data;
using Delivery.DTO.Cliente.AgregarCliente;
using Delivery.DTO.Cliente.ListarClientes;
using Delivery.Entidades;

namespace Delivery.Controllers
{
    public class ClientesController : BaseApiController
    {
        private readonly AppDbContext _contexto;

        public ClientesController(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ListarClientesOutput>>> GetClientes()
        {
            var clientes = await _contexto.Clientes
                .AsNoTracking()
                .Select(x => new ListarClientesOutput
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Telefono = x.Telefono,
                    Direccion = x.Direccion,
                    Correo = x.Correo
                })
                .ToListAsync();

            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(Guid id)
        {
            var cliente = await _contexto.Clientes.FindAsync(id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<AgregarClienteOutput>> CreateCliente([FromBody] AgregarClienteInput cliente)
        {
            var entrada = new Cliente
            {
                Nombre = cliente.Nombre,
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion,
                Correo = cliente.Correo
            };

            entrada.Id = Guid.NewGuid();

            _contexto.Clientes.Add(entrada);
            await _contexto.SaveChangesAsync();

            var salida = new AgregarClienteOutput
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Telefono = entrada.Telefono,
                Direccion = entrada.Direccion,
                Correo = entrada.Correo
            };

            return CreatedAtAction(nameof(GetCliente), new { id = salida.Id }, salida);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(Guid id, [FromBody] Cliente cliente)
        {
            if (id != cliente.Id)
                return BadRequest();

            var existing = await _contexto.Clientes.FindAsync(id);

            if (existing == null)
                return NotFound();

            existing.Nombre = cliente.Nombre;
            existing.Telefono = cliente.Telefono;
            existing.Direccion = cliente.Direccion;
            existing.Correo = cliente.Correo;

            await _contexto.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(Guid id)
        {
            var cliente = await _contexto.Clientes.FindAsync(id);

            if (cliente == null)
                return NotFound();

            _contexto.Clientes.Remove(cliente);
            await _contexto.SaveChangesAsync();

            return NoContent();
        }
    }
}
