namespace Restaurante.Application.Features.Comidas.DTOs;

public class CreateComidaRequestDto
{
    public string Nombre { get; set; } = string.Empty;
    public decimal Precio { get; set; }
}