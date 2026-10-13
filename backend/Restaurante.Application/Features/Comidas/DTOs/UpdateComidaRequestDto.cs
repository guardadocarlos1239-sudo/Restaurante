
namespace Restaurante.Application.Features.Comidas.DTOs;

public class UpdateComidaRequestDto
{
    public string Nombre { get; set; } = string.Empty;
    public decimal Precio { get; set; }
}
