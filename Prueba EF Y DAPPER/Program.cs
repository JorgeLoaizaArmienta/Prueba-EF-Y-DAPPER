using Microsoft.EntityFrameworkCore;
using Productos.Application.UseCases.Productos;  // Importa casos de uso relacionados con productos
using Productos.Infrastructure.Data;
using Productos.IoC;  // Importa el contenedor de Inyecci�n de Dependencias (IoC)

var builder = WebApplication.CreateBuilder(args); // Crea una nueva instancia de WebApplication

// Obtener la cadena de conexi�n de la base de datos desde el archivo de configuraci�n (appsettings.json o variables de entorno).
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configura los servicios de infraestructura, usando un m�todo de extensi�n propio (probablemente en Productos.IoC).
builder.Services.AddInfrastructureServices(builder.Configuration);

// Configura el caso de uso BuscarProductosUseCase como un servicio de �mbito (Scoped).
builder.Services.AddScoped<BuscarProductosUseCase>();


// Agrega los servicios necesarios para los controladores de la API.
builder.Services.AddControllers();

// Configuraci�n de Swagger para documentaci�n interactiva de la API.
// Agrega el soporte para explorar los puntos finales de la API y generar la documentaci�n OpenAPI.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build(); // Construye la aplicaci�n con los servicios configurados.


// Configura el pipeline de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    // Solo habilitar Swagger si el entorno es de desarrollo.
    app.UseSwagger();
    app.UseSwaggerUI(); // Muestra la interfaz de Swagger para interactuar con la API.
}

app.UseHttpsRedirection(); // Redirige las solicitudes HTTP a HTTPS para asegurar la comunicaci�n.

app.UseAuthorization(); // Habilita el middleware de autorizaci�n (esto permite manejar autenticaci�n y autorizaci�n).

app.MapControllers(); // Mapea las rutas de los controladores a los puntos finales de la API.

app.Run(); // Inicia la aplicaci�n.
