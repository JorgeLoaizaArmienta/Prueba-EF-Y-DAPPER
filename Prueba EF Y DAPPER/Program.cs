using Microsoft.EntityFrameworkCore;
using Productos.Application.UseCases.Productos;  // Importa casos de uso relacionados con productos
using Productos.Infrastructure.Data;
using Productos.IoC;  // Importa el contenedor de Inyección de Dependencias (IoC)

var builder = WebApplication.CreateBuilder(args); // Crea una nueva instancia de WebApplication

// Obtener la cadena de conexión de la base de datos desde el archivo de configuración (appsettings.json o variables de entorno).
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configura los servicios de infraestructura, usando un método de extensión propio (probablemente en Productos.IoC).
builder.Services.AddInfrastructureServices(builder.Configuration);

// Configura el caso de uso BuscarProductosUseCase como un servicio de ámbito (Scoped).
builder.Services.AddScoped<BuscarProductosUseCase>();


// Agrega los servicios necesarios para los controladores de la API.
builder.Services.AddControllers();

// Configuración de Swagger para documentación interactiva de la API.
// Agrega el soporte para explorar los puntos finales de la API y generar la documentación OpenAPI.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build(); // Construye la aplicación con los servicios configurados.


// Configura el pipeline de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    // Solo habilitar Swagger si el entorno es de desarrollo.
    app.UseSwagger();
    app.UseSwaggerUI(); // Muestra la interfaz de Swagger para interactuar con la API.
}

app.UseHttpsRedirection(); // Redirige las solicitudes HTTP a HTTPS para asegurar la comunicación.

app.UseAuthorization(); // Habilita el middleware de autorización (esto permite manejar autenticación y autorización).

app.MapControllers(); // Mapea las rutas de los controladores a los puntos finales de la API.

app.Run(); // Inicia la aplicación.
