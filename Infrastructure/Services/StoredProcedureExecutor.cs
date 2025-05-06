using Dapper;
using Productos.Domain.Enums;
using Productos.Domain.Interfaces;
using Productos.Domain.Responses;
using Newtonsoft.Json;
using System.Data;

namespace Productos.Infrastructure.Services
{
    /// <summary>
    /// Implementación de IStoredProcedureExecutor que ejecuta procedimientos almacenados 
    /// utilizando Dapper y maneja las respuestas de dichos procedimientos.
    /// </summary>
    public class StoredProcedureExecutor : IStoredProcedureExecutor
    {
        private readonly IDbConnection _dbConnection;  // Conexión a la base de datos

        /// <summary>
        /// Constructor que inyecta la conexión a la base de datos.
        /// </summary>
        /// <param name="dbConnection">Conexión a la base de datos.</param>
        public StoredProcedureExecutor(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado y maneja la respuesta según el tipo de operación especificado.
        /// </summary>
        public async Task<SpResponse<T>> ExecuteStoredProcedureAsync<T>(
            string spName,
            SpOperation consulta,
            int operacion,
            string jsonParameters)
        {
            var response = new SpResponse<T> { Success = true, Status = 200 };

            try
            {
                // 1. Preparar DynamicParameters
                var parameters = new DynamicParameters();
                parameters.Add("@operation", operacion);
                parameters.Add("@json", jsonParameters);
                parameters.Add("@success", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                parameters.Add("@message", dbType: DbType.String, size: 1024, direction: ParameterDirection.Output);
                parameters.Add("@exception", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                parameters.Add("@status", dbType: DbType.Int32, direction: ParameterDirection.Output);

                // 2. Ejecutar según tipo de operación
                switch (consulta)
                {
                    case SpOperation.Query:
                        var queryResult = await _dbConnection
                            .QueryAsync<T>(spName, parameters, commandType: CommandType.StoredProcedure);
                        response.Data = queryResult; // Asigna la lista directamente
                        break;

                    case SpOperation.QueryFirst:
                        response.Data = await _dbConnection
                            .QueryFirstOrDefaultAsync<T>(spName, parameters, commandType: CommandType.StoredProcedure);
                        break;

                    case SpOperation.Execute:
                        await _dbConnection.ExecuteAsync(spName, parameters, commandType: CommandType.StoredProcedure);
                        break;

                    case SpOperation.QueryMultiple:
                        //var multi = await _dbConnection
                        //    .QueryMultipleAsync(spName, parameters, commandType: CommandType.StoredProcedure);
                        //response.Data = MapMultipleResults<T>(multi);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(consulta), "Operación no válida.");
                }

                // 3. Leer parámetros de salida
                response.Success = parameters.Get<bool>("@success");
                response.Message = parameters.Get<string>("@message");
                response.Status = parameters.Get<int>("@status");
                response.Exception = parameters.Get<bool>("@exception");
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Status = 500;
                response.Message = $"Error ejecutando SP: {ex.Message}";
                response.Data = default;
            }

            return response;
        }



        /// <summary>
        /// Mapea los resultados de múltiples consultas de un procedimiento almacenado.
        /// </summary>
        private T MapMultipleResults<T>(SqlMapper.GridReader multiResult)
        {
            var resultType = typeof(T);
            var genericArgs = resultType.GetGenericArguments();
            var results = new List<object>();

            foreach (var type in genericArgs)
            {
                var method = typeof(SqlMapper.GridReader)
                    .GetMethod("Read", Array.Empty<Type>())!
                    .MakeGenericMethod(type);
                results.Add(method.Invoke(multiResult, null)!);
            }

            return (T)Activator.CreateInstance(resultType, results.ToArray())!;
        }
    }
}
