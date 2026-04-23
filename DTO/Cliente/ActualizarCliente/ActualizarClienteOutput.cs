using System;

namespace Delivery.DTO.Cliente.ActualizarCliente;

public class ActualizarClienteOutput
{
    public Guid Id { get; set; }
    public required string Nombre { get; set; }
    public string? Telefono { get; set; }
    public string? Direccion { get; set; }
    public string? Correo { get; set; }
}
