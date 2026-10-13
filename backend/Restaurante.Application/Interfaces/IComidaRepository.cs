
using Restaurante.Domain.Entities;

namespace Restaurante.Application.Interfaces;

public interface IComidaRepository
{
    Task<IEnumerable<Comida>> GetAllAsync();

    Task<Comida> AddAsync(Comida comida);

    Task<Comida?> GetByIdAsync(int id);

    Task UpdateAsync(Comida comida);

    Task DeleteAsync(Comida comida);
}
