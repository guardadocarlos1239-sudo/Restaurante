using DotNetEnv;
using Restaurante.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

Env.Load(Path.Combine(builder.Environment.ContentRootPath, ".env"));

var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__PostgresConnection")
                       ?? throw new InvalidOperationException("Falta la cadena de conexión.");

// Llamamos al método que inyecta los repositorios y la base de datos
builder.Services.AddInfrastructure(connectionString);

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
