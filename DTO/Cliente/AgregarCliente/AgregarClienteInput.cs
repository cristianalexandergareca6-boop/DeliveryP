using System.ComponentModel.DataAnnotations;

namespace Delivery.DTO.Cliente.AgregarCliente;

public class AgregarClienteInput
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(50, MinimumLength = 2)]
    public required string Nombre { get; set; }

    [Phone]
    public string? Telefono { get; set; }

    [StringLength(100)]
    public string? Direccion { get; set; }

    [EmailAddress]
    public string? Correo { get; set; }
}
