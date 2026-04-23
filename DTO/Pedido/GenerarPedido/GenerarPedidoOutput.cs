using System;

namespace Delivery.DTO.Pedido.GenerarPedido;

public class GenerarPedidoOutput
{
    public Guid Id { get; set; }
    public DateTime Fecha { get; set; }
    public string? TipoPedido { get; set; }
    public decimal Total { get; set; }
    public string? Estado { get; set; }
}