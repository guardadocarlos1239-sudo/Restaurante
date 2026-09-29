namespace Restaurante.Domain.Entities;

public class Bebida
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public decimal Precio { get; set; }
}
