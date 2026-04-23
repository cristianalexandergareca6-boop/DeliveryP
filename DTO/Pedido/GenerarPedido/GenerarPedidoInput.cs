using System.ComponentModel.DataAnnotations;

namespace Delivery.DTO.Pedido.GenerarPedido;

public class GenerarPedidoInput
{
    [Required]
    public Guid ClienteId { get; set; }

    [Required]
    public Guid LocalId { get; set; }

    public List<ProductosDeEntrada> Detalle { get; set; } = new();
}

public class ProductosDeEntrada
{
    public required string Nombre { get; set; }
    public int Cantidad { get; set; }
}

