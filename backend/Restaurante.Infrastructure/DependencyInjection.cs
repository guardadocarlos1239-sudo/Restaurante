using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurante.Application.Interfaces;
using Restaurante.Infrastructure.Data;
using Restaurante.Infrastructure.Repositories;

namespace Restaurante.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<HabitForgeDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<IComidaRepository, ComidaRepository>();

        return services;
    }
}