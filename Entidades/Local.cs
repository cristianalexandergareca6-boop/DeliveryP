using System;

namespace Delivery.Entidades;

public class Local
{
    public Guid Id { get; set; }
    public required string Nombre { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string? TipoComida { get; set; } 

}
