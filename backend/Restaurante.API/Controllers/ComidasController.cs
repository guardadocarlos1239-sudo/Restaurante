
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Features.Comidas.DTOs;
using Restaurante.Application.Interfaces;
using Restaurante.Domain.Entities;

namespace Restaurante.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ComidasController : ControllerBase
{
    private readonly IComidaRepository _repository;
    private readonly IValidator<CreateComidaRequestDto> _createValidator;
    private readonly IValidator<UpdateComidaRequestDto> _updateValidator;

    public ComidasController(
        IComidaRepository repository,
        IValidator<CreateComidaRequestDto> createValidator,
        IValidator<UpdateComidaRequestDto> updateValidator)
    {
        _repository = repository;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    // GET: api/Comidas
    [HttpGet]
    public async Task<IActionResult> GetComidas()
    {
        var comidas = await _repository.GetAllAsync();

        var response = comidas.Select(c => new ComidaResponseDto
        {
            Id = c.Id,
            Nombre = c.Nombre,
            Precio = c.Precio
        });

        return Ok(response);
    }

    // GET: api/Comidas/1
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetComidaPorId(int id)
    {
        var comida = await _repository.GetByIdAsync(id);

        if (comida is null)
            return NotFound();

        var response = new ComidaResponseDto
        {
            Id = comida.Id,
            Nombre = comida.Nombre,
            Precio = comida.Precio
        };

        return Ok(response);
    }

    // POST: api/Comidas
    [HttpPost]
    public async Task<IActionResult> CrearComida(
        [FromBody] CreateComidaRequestDto request)
    {
        var validationResult = await _createValidator.ValidateAsync(request);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var nuevaComida = new Comida
        {
            Nombre = request.Nombre,
            Precio = request.Precio
        };

        var comidaCreada = await _repository.AddAsync(nuevaComida);

        var response = new ComidaResponseDto
        {
            Id = comidaCreada.Id,
            Nombre = comidaCreada.Nombre,
            Precio = comidaCreada.Precio
        };

        return CreatedAtAction(
            nameof(GetComidaPorId),
            new { id = response.Id },
            response);
    }

    // PUT: api/Comidas/1
    [HttpPut("{id:int}")]
    public async Task<IActionResult> ActualizarComida(
        int id,
        [FromBody] UpdateComidaRequestDto request)
    {
        var comida = await _repository.GetByIdAsync(id);

        if (comida is null)
            return NotFound();

        var validationResult = await _updateValidator.ValidateAsync(request);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        comida.Nombre = request.Nombre;
        comida.Precio = request.Precio;

        await _repository.UpdateAsync(comida);

        return NoContent();
    }

    // DELETE: api/Comidas/1
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> EliminarComida(int id)
    {
        var comida = await _repository.GetByIdAsync(id);

        if (comida is null)
            return NotFound();

        await _repository.DeleteAsync(comida);

        return NoContent();
    }
}
