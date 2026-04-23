using System.ComponentModel.DataAnnotations;

namespace Delivery.DTO.Cliente.ActualizarCliente;

public class ActualizarClienteInput
{
    [Required]
    [StringLength(50)]
    public required string Nombre { get; set; }

    [Phone]
    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    [EmailAddress]
    public string? Correo { get; set; }
}
