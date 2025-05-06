namespace Productos.Domain.Enums
{
    /// <summary>
    /// Enum que representa los diferentes tipos de operaciones que se pueden realizar en un procedimiento almacenado (Stored Procedure).
    /// Cada valor de este enum define un tipo de operación que se puede ejecutar a través de Dapper o Entity Framework.
    /// </summary>
    public enum SpOperation
    {
        /// <summary>
        /// Operación para realizar un SELECT que retorna múltiples registros.
        /// Usado cuando un procedimiento almacenado devuelve una lista de resultados (por ejemplo, una consulta que devuelve varios productos).
        /// </summary>
        Query,          // Para SELECT que retorna múltiples registros

        /// <summary>
        /// Operación para realizar un SELECT que retorna solo un registro.
        /// Usado cuando un procedimiento almacenado devuelve solo un único resultado (por ejemplo, buscar un producto por su ID).
        /// </summary>
        QueryFirst,     // Para SELECT que retorna un solo registro

        /// <summary>
        /// Operación para ejecutar un procedimiento que realiza una acción de modificación de datos (INSERT, UPDATE, DELETE).
        /// Usado para procedimientos que no retornan datos, pero que modifican la base de datos.
        /// </summary>
        Execute,        // Para INSERT/UPDATE/DELETE

        /// <summary>
        /// Operación para realizar un SELECT que retorna múltiples tablas.
        /// Usado cuando el procedimiento almacenado devuelve más de una tabla o conjunto de resultados (por ejemplo, obtener productos y sus categorías).
        /// </summary>
        QueryMultiple   // Para SPs que retornan múltiples tablas
    }
}
