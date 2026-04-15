using System;

namespace Delivery.Entidades;

public class Repartidor
{
    public Guid Id { get; set; }
    public required string Nombre { get; set; }
    public string? Telefono { get; set; }
    public string? PlacaVehiculo { get; set; } 
    public bool Disponible { get; set; }

}
