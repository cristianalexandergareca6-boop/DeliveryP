using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Delivery.Data;
using Delivery.DTO.Pedido.GenerarPedido;
using Delivery.Entidades;

namespace Delivery.Controllers;

public class PedidoController : BaseApiController
{
    private readonly AppDbContext _contexto;

    public PedidoController(AppDbContext contexto)
    {
        _contexto = contexto;
    }

    [HttpPost]
    public async Task<ActionResult<GenerarPedidoOutput>> GenerarPedido([FromBody] GenerarPedidoInput entrada)
    {
        try
        {
            var cliente = await _contexto.Clientes.FindAsync(entrada.ClienteId);

            if (cliente == null)
                return BadRequest("Cliente no encontrado.");

            var repartidor = await _contexto.Repartidores
                .FirstOrDefaultAsync(x => x.Disponible == true);

            if (repartidor == null)
                return BadRequest("No hay repartidores disponibles.");

            decimal total = 0;

            var pedido = new Pedido
            {
                Id = Guid.NewGuid(),
                Fecha = DateTime.Now,
                TipoPedido = "Delivery",
                Estado = "Pendiente",
                ClienteId = cliente.Id,
                Cliente = cliente,
                RepartidorId = repartidor.Id,
                Repartidor = repartidor,
                Total = 0
            };

            _contexto.Pedidos.Add(pedido);

            foreach (var item in entrada.Detalle)
            {
                var producto = await _contexto.Productos
                    .FirstOrDefaultAsync(x => x.Nombre == item.Nombre && x.LocalId == entrada.LocalId);

                if (producto == null)
                    return BadRequest("El producto " + item.Nombre + " no existe.");

                var detalle = new Detalle_Pedido
                {
                    Id = Guid.NewGuid(),
                    PedidoId = pedido.Id,
                    Pedido = pedido,
                    ProductoId = producto.Id,
                    Producto = producto,
                    Cantidad = item.Cantidad,
                    PrecioUnitario = producto.Precio
                };

                total += producto.Precio * item.Cantidad;

                _contexto.DetallePedidos.Add(detalle);
            }

            pedido.Total = total;
            repartidor.Disponible = false;

            await _contexto.SaveChangesAsync();

            var salida = new GenerarPedidoOutput
            {
                Id = pedido.Id,
                Fecha = pedido.Fecha,
                TipoPedido = pedido.TipoPedido,
                Total = pedido.Total,
                Estado = pedido.Estado
            };

            return Ok(salida);
        }
        catch (Exception ex)
        {
            return BadRequest("Error al generar pedido: " + ex.Message);
        }
    }
}
