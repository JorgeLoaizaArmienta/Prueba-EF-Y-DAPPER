using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;  



namespace Productos.Domain.Entities
{
    /// <summary>
    /// La clase Producto representa un producto en el sistema.
    /// Contiene las propiedades esenciales que definen un producto y sus características.
    /// </summary>
    public class Producto
    {
        /// <summary>
        /// ID único del producto. Se utiliza para identificar de manera única cada producto en la base de datos.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del producto. Representa el nombre o descripción del producto.
        /// Puede ser nulo, ya que algunos productos podrían no tener un nombre definido.
        /// </summary>
        public string? Nombre { get; set; }

        /// <summary>
        /// Precio del producto. Representa el valor del producto en la moneda local.
        /// Este valor es necesario para la venta o compra del producto.
        /// </summary>
        [Precision(18, 2)]
        public decimal Precio { get; set; }
        /// <summary>
        /// Stock disponible del producto. Indica la cantidad de unidades disponibles en inventario.
        /// </summary>
        public int Stock { get; set; }
    }
}
