using System;

namespace Delivery.DTO.Cliente.ObtenerCliente;

public class ObtenerClienteOutput
{
    public Guid Id { get; set; }
    public required string Nombre { get; set; }
    public string? Telefono { get; set; }
    public string? Direccion { get; set; }
    public string? Correo { get; set; }
}
