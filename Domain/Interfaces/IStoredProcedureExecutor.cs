using System.Threading.Tasks;
using Productos.Domain.Enums;
using Productos.Domain.Responses;

namespace Productos.Domain.Interfaces
{
    /// <summary>
    /// Esta interfaz define los métodos necesarios para ejecutar procedimientos almacenados en la base de datos.
    /// Se utiliza para la ejecución de procedimientos que interactúan con la base de datos, como consultas, inserciones, actualizaciones, etc.
    /// </summary>
    public interface IStoredProcedureExecutor
    {
        /// <summary>
        /// Ejecuta un procedimiento almacenado en la base de datos de forma asincrónica.
        /// 
        /// Este método es genérico y permite ejecutar procedimientos que pueden retornar cualquier tipo de datos,
        /// además de manejar diferentes tipos de operaciones (consultas, inserciones, actualizaciones, etc.).
        /// </summary>
        /// <typeparam name="T">El tipo de dato que se espera recibir como resultado del procedimiento almacenado.</typeparam>
        /// <param name="spName">El nombre del procedimiento almacenado que se desea ejecutar.</param>
        /// <param name="operation">El tipo de operación que se desea realizar (consultar, insertar, etc.).</param>
        /// <param name="jsonParameters">Los parámetros de entrada para el procedimiento almacenado, en formato JSON.</param>
        /// <returns>Un resultado de tipo <see cref="SpResponse{T}"/> que contiene los datos obtenidos o el resultado de la operación.</returns>
        Task<SpResponse<T>> ExecuteStoredProcedureAsync<T>(
            string spName,          // Nombre del procedimiento almacenado a ejecutar.
            SpOperation consulta, // Tipo de operación que define si se realiza un query, insert, update, etc.
            int operacion,
            string jsonParameters  // Parámetros de entrada, generalmente en formato JSON.
        );
    }
}
