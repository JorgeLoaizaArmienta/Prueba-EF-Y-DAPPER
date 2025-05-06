using Microsoft.AspNetCore.Mvc;
using Productos.Application.Interfaces;

namespace Productos.Api.Controllers
{
    // Definimos que esta clase es un controlador de API con el atributo [ApiController]
    // y establecemos la ruta base de las solicitudes para este controlador.
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        // Declaramos la variable privada para almacenar el repositorio que se inyecta en el constructor.
        private readonly IProductoRepository _repo;

        // Constructor donde se inyecta el repositorio IProductoRepository.
        // Este repositorio es el que nos proporciona acceso a los datos de productos.
        public ProductosController(IProductoRepository repo)
        {
            _repo = repo;
        }

        // Ejemplo usando EF Core
        // Acción para obtener un producto por su ID utilizando EF Core (usando el repositorio con EF Core).
        // Se define la ruta para acceder a este endpoint: api/productos/{id}.
        // El parámetro `id` es pasado en la URL.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Llamamos al repositorio para obtener el producto por su ID.
            var producto = await _repo.GetByIdAsync(id);

            // Si el producto es encontrado, se devuelve un código de estado 200 (OK) con los datos del producto.
            return Ok(producto);
        }

        // Ejemplo usando Dapper (SP)
        // Acción para obtener un producto por su ID utilizando un procedimiento almacenado (SP).
        // La ruta para este endpoint es: api/productos/sp/{id}.
        // El parámetro `id` es pasado en la URL.
        [HttpGet("sp/{id}")]
        public async Task<IActionResult> GetByIdSP(int id)
        {
            // Llamamos al repositorio para obtener los productos usando el procedimiento almacenado.
            var productos = await _repo.SPGetByIdAsync(id);

            if (!productos.Success)
                return StatusCode(productos.Status, new
                {
                    message = productos.Message 
                });

            return StatusCode(productos.Status, productos.Data);
            // Devolvemos el resultado en un código de estado 200 (OK) con los productos obtenidos.
        }
    }
}
