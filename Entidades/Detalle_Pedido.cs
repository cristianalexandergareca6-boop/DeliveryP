using System;

namespace Delivery.Entidades;

public class Detalle_Pedido
{
    public Guid Id { get; set; }

    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }

    public Guid PedidoId { get; set; }
    public required Pedido Pedido { get; set; }

    public Guid ProductoId { get; set; }
    public required Producto Producto { get; set; }

}
