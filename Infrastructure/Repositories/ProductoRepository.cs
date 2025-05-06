using Productos.Domain.Interfaces;
using Productos.Domain.Entities;
using Productos.Application.Interfaces;
using Productos.Infrastructure.Data;
using Newtonsoft.Json;
using Productos.Domain.Enums;
using Azure;
using Productos.Domain.Responses;

namespace Productos.Infrastructure.Repositories
{
    /// <summary>
    /// Implementación del repositorio para la entidad Producto.
    /// Este repositorio maneja las interacciones con la base de datos a través de Entity Framework Core (EF Core)
    /// y Dapper para el uso de procedimientos almacenados (Stored Procedures).
    /// </summary>
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _context;  // Contexto de base de datos usando Entity Framework Core
        private readonly IStoredProcedureExecutor _spExecutor;  // Ejecutador de procedimientos almacenados usando Dapper

        /// <summary>
        /// Constructor del repositorio que recibe el contexto de la base de datos (EF Core)
        /// y el ejecutor de procedimientos almacenados (Dapper).
        /// </summary>
        /// <param name="context">Contexto de base de datos (EF Core).</param>
        /// <param name="spExecutor">Ejecutor de procedimientos almacenados (Dapper).</param>
        public ProductoRepository(
            ApplicationDbContext context,
            IStoredProcedureExecutor spExecutor)
        {
            // Inyección de dependencias del contexto de base de datos y ejecutor de procedimientos almacenados.
            _context = context;
            _spExecutor = spExecutor;
        }

        // ---- Métodos con Entity Framework Core (EF Core) ----

        /// <summary>
        /// Obtiene un producto por su Id usando Entity Framework Core.
        /// Realiza una búsqueda directa en la base de datos usando el contexto de EF Core.
        /// </summary>
        /// <param name="id">Identificador único del producto.</param>
        /// <returns>Un producto con el Id proporcionado, o null si no se encuentra.</returns>
        public async Task<Producto?> GetByIdAsync(int id)
        {
            // Usando EF Core para buscar un producto por su Id. 
            // El método FindAsync busca en la tabla "Productos" en la base de datos.
            return await _context.Productos.FindAsync(id);
        }

        // ---- Métodos con Dapper (Procedimientos Almacenados) ----

        /// <summary>
        /// Obtiene productos mediante un procedimiento almacenado usando Dapper.
        /// Este método ejecuta un procedimiento almacenado en la base de datos para obtener productos.
        /// </summary>
        /// <param name="id">Identificador del producto a buscar.</param>
        /// <returns>Una lista de productos que coinciden con el Id proporcionado.</returns>
        public async Task<SpResponse<Producto>> SPGetByIdAsync(int id)
        {
            var jsonParams = JsonConvert.SerializeObject(new { Id = id });

            // Obtenemos el SpResponse completo
            var response = await _spExecutor.ExecuteStoredProcedureAsync<Producto>(
                "sp_BuscarProductos",
                SpOperation.QueryFirst,
                2,
                jsonParams
            );

            return response;
        }
    }
}
