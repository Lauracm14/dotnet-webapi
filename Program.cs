// Program.cs
// Punto de entrada de la aplicación Web API en .NET 7
// Configura los servicios, el contexto de base de datos y los controladores.

var builder = WebApplication.CreateBuilder(args);

// Configuración de la cadena de conexión SQLite
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Añadir EF Core con SQLite al contenedor de servicios
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

// Añadir controladores y habilitar Swagger para documentación de la API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
