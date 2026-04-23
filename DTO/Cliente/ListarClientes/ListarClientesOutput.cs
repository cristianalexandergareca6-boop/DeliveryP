using System;

namespace Delivery.DTO.Cliente.ListarClientes;

public class ListarClientesOutput
{
    public Guid Id { get; set; }
    public required string Nombre { get; set; }
    public string? Telefono { get; set; }
    public string? Direccion { get; set; }
    public string? Correo { get; set; }
}
