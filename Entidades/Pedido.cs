using System;

namespace Delivery.Entidades;

public class Pedido
{
    public Guid Id { get; set; }
    public DateTime Fecha { get; set; }
    
    public string TipoPedido { get; set; }
    public decimal Total { get; set; }
    public string Estado { get; set; } = "Pendiente";

    public Guid ClienteId { get; set; }
    public required Cliente Cliente { get; set; }

    public Guid RepartidorId { get; set; }
    public required Repartidor Repartidor { get; set; }

}
