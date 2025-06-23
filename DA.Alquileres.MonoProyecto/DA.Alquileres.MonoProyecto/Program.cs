using DA.Alquileres.MonoProyecto.Data;
using DA.Alquileres.MonoProyecto.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

#region cadena de conexion

builder.Services.AddDbContext<dbAlquileresContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbAlquileres"));
});

#endregion cadena de conexion

builder.Services.AddScoped<ITipoDocumentosServices, TipoDocumentosServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
