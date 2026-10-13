namespace Restaurante.Application.Features.Comidas.DTOs;

public class ComidaResponseDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public decimal Precio { get; set; }
}