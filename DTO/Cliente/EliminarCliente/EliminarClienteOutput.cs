using System;

namespace Delivery.DTO.Cliente.EliminarCliente;

public class EliminarClienteOutput
{
    public Guid Id { get; set; }
    public required string Nombre { get; set; }
    public string Mensaje { get; set; } = "Cliente eliminado correctamente.";
}
