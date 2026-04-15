using System;

namespace Delivery.Entidades;

public class Producto
{
    public Guid Id { get; set; }
    public required string Nombre { get; set; }
    public decimal Precio { get; set; }
    public string? Descripcion { get; set; }

    public Guid LocalId { get; set; }
    public required Local Local { get; set; }

}
