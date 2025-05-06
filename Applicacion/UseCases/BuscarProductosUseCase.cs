using Productos.Application.Interfaces;  // Interfaz que define el repositorio de productos
using Productos.Domain.Entities;  // Entidades de dominio (en este caso, Producto)
using Productos.Domain.Responses; // Respuestas de procedimientos almacenados

namespace Productos.Application.UseCases.Productos
{
    /// <summary>
    /// El caso de uso "BuscarProductosUseCase" define una tarea que permite buscar productos
    /// en el sistema, en este caso, a través de un ID. Los casos de uso son responsables de coordinar
    /// las acciones necesarias para cumplir con la solicitud de un usuario o sistema.
    /// </summary>
    public class BuscarProductosUseCase
    {
        // Dependencia que se inyecta, el repositorio de productos que maneja la interacción con la base de datos
        private readonly IProductoRepository _productoRepository;

        /// <summary>
        /// Constructor que recibe una instancia del repositorio de productos.
        /// Este repositorio se utilizará para interactuar con la base de datos y recuperar los datos.
        /// </summary>
        /// <param name="productoRepository">Repositorio que gestiona las operaciones relacionadas con productos</param>
        public BuscarProductosUseCase(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        /// <summary>
        /// Ejecuta la lógica del caso de uso. Devuelve el objeto SpResponse con todos sus campos:
        /// Success, Status, Message y Data (la lista de productos).
        /// </summary>
        /// <param name="id">ID del producto que se quiere buscar</param>
        /// <returns>Un SpResponse que incluye código, mensaje y datos</returns>
        public async Task<SpResponse<Producto>> Execute(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero.", nameof(id));

            // Llama al método que ya devuelve un SpResponse completo
            var response = await _productoRepository.SPGetByIdAsync(id);

            // Opcional: podrías validar Success aquí y lanzar si quieres,
            // pero normalmente dejas que el controlador interprete el response.

            return response;
        }
    }
}
