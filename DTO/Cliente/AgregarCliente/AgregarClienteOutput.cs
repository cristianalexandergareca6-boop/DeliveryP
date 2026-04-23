namespace Delivery.DTO.Cliente.AgregarCliente;

public class AgregarClienteOutput
{
    public Guid Id { get; set; }
    public required string Nombre { get; set; }
    public string? Telefono { get; set; }
    public string? Direccion { get; set; }
    public string? Correo { get; set; }
}
