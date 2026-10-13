
using Microsoft.EntityFrameworkCore;
using Restaurante.Application.Interfaces;
using Restaurante.Domain.Entities;
using Restaurante.Infrastructure.Data;

namespace Restaurante.Infrastructure.Repositories;

public class ComidaRepository : IComidaRepository
{
    private readonly HabitForgeDbContext _context;

    public ComidaRepository(HabitForgeDbContext context)
    {
        _context = context;
    }

    // Obtener todas las comidas
    public async Task<IEnumerable<Comida>> GetAllAsync()
    {
        return await _context.Comidas.ToListAsync();
    }

    // Crear una comida
    public async Task<Comida> AddAsync(Comida comida)
    {
        await _context.Comidas.AddAsync(comida);
        await _context.SaveChangesAsync();

        return comida;
    }

    // Buscar una comida por ID
    public async Task<Comida?> GetByIdAsync(int id)
    {
        return await _context.Comidas.FindAsync(id);
    }

    // Actualizar una comida
    public async Task UpdateAsync(Comida comida)
    {
        _context.Comidas.Update(comida);
        await _context.SaveChangesAsync();
    }

    // Eliminar una comida
    public async Task DeleteAsync(Comida comida)
    {
        _context.Comidas.Remove(comida);
        await _context.SaveChangesAsync();
    }
}
