namespace Productos.Domain.Responses
{
    /// <summary>
    /// Esta clase encapsula la respuesta de un procedimiento almacenado, incluyendo los datos obtenidos y la información del estado de la operación.
    /// </summary>
    public class SpResponse<T>
    {
        /// <summary>
        /// Indica si la operación fue exitosa.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Código de estado HTTP o un código específico que indica el estado de la operación.
        /// Ejemplos: 200 para OK, 500 para Error, etc.
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Un mensaje opcional que proporciona detalles sobre el resultado de la operación.
        /// Puede ser útil para describir errores o advertencias.
        /// </summary>
        public string? Message { get; set; }

        public bool Exception { get; set; }

        /// <summary>
        /// Los datos obtenidos como resultado de la ejecución del procedimiento almacenado.
        /// Este es un valor genérico que puede ser cualquier tipo de dato (puede ser un objeto, lista, etc.).
        /// </summary>
        public object? Data { get; set; } // Cambia de T a object
    }
}
