
using FluentValidation;
using Restaurante.Application.Features.Comidas.DTOs;

namespace Restaurante.Application.Features.Comidas.Validators;

public class UpdateComidaValidator : AbstractValidator<UpdateComidaRequestDto>
{
    public UpdateComidaValidator()
    {
        RuleFor(x => x.Nombre)
            .NotEmpty()
            .WithMessage("El nombre de la comida no puede estar vacío.")
            .MinimumLength(3)
            .WithMessage("La comida debe tener al menos 3 caracteres.")
            .MaximumLength(100)
            .WithMessage("El nombre de la comida es demasiado largo.");

        RuleFor(x => x.Precio)
            .GreaterThan(0)
            .WithMessage("El precio debe ser mayor que 0.");
    }
}
