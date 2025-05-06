using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Productos.Application.Interfaces;
using Productos.Application.UseCases.Productos;
using Productos.Domain.Interfaces;
using Productos.Infrastructure.Repositories;
using Productos.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Productos.Infrastructure.Data;
using Microsoft.Extensions.Configuration;

namespace Productos.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Configuración de EF Core
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Registro de la conexión IDbConnection para Dapper
            services.AddScoped<IDbConnection>(sp =>
                new SqlConnection(configuration.GetConnectionString("DefaultConnection")));

            // Registro de repositorios
            services.AddScoped<IProductoRepository, ProductoRepository>();

            // Registro de servicios Dapper
            services.AddScoped<IStoredProcedureExecutor, StoredProcedureExecutor>();

            // Registro de casos de uso
            services.AddScoped<BuscarProductosUseCase>();

            return services;
        }
    }
}
