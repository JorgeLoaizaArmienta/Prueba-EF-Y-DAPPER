using Productos.Domain.Entities;  // Se importa la entidad Producto, que es el objeto que se va a manejar en el repositorio
using Productos.Domain.Responses; // Se importa la respuesta del procedimiento almacenado

namespace Productos.Application.Interfaces
{
    /// <summary>
    /// La interfaz IProductoRepository define los métodos que debe implementar cualquier clase encargada de
    /// interactuar con los datos de los productos. Esta interfaz establece las operaciones básicas que se
    /// realizarán sobre la entidad Producto en el sistema.
    /// </summary>
    public interface IProductoRepository
    {
        /// <summary>
        /// Método asincrónico para obtener un producto por su ID.
        /// Este método debe devolver el producto si lo encuentra o null si no existe.
        /// </summary>
        /// <param name="id">ID del producto a buscar</param>
        /// <returns>Un objeto Producto si lo encuentra, de lo contrario null</returns>
        Task<Producto?> GetByIdAsync(int id);

        /// <summary>
        /// Método asincrónico para obtener una lista de productos utilizando un procedimiento almacenado.
        /// Este método se utiliza cuando se desea realizar una consulta más compleja o específica,
        /// que puede ser ejecutada mediante un procedimiento almacenado en la base de datos.
        /// </summary>
        /// <param name="id">ID para filtrar los productos a obtener</param>
        /// <returns>Una colección de productos obtenidos mediante el procedimiento almacenado</returns>
        Task<SpResponse<Producto>> SPGetByIdAsync(int id);
    }
}
