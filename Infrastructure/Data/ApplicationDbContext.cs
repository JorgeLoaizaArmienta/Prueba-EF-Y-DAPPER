// Infrastructure/Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using Productos.Domain.Entities;

namespace Productos.Infrastructure.Data
{
    /// <summary>
    /// Clase que representa el contexto de la base de datos para la aplicación.
    /// Inicia la conexión a la base de datos y mapea las entidades a las tablas correspondientes.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Constructor que recibe las opciones de configuración para el contexto de base de datos.
        /// </summary>
        /// <param name="options">Opciones de configuración para la base de datos.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Propiedad que representa la tabla "Productos" en la base de datos.
        /// </summary>
        public DbSet<Producto> Productos { get; set; }

        /// <summary>
        /// Método para configurar las entidades y sus relaciones usando Fluent API.
        /// Aquí se pueden personalizar los detalles del mapeo entre las entidades y las tablas.
        /// </summary>
        /// <param name="modelBuilder">Modelo que se utiliza para configurar las entidades.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuraciones adicionales para la entidad Producto usando Fluent API.
            modelBuilder.Entity<Producto>(entity =>
            {
                // Mapea la entidad Producto a la tabla "Productos"
                entity.ToTable("Productos");

                // Define la clave primaria de la entidad Producto
                entity.HasKey(p => p.Id);
            });
        }
    }
}
