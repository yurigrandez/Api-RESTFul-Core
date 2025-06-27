using DA.Alquileres.API;
using DA.Alquileres.API.Middleware;
using DA.Alquileres.API.Validadores;
using DA.Alquileres.Entidades.Entidades;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<UsuarioNuevoDTOValidador>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

#region cadena de conexion

builder.Services.AddDbContext<_dbAlquileresContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbAlquileres"));
});

#endregion cadena de conexion

#region Configurando Swagger y Documentación

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Da.Alquileres",
        Version = "v1",
        Description = "Documentación del WS de la aplicación DA.Alquileres",
        Contact = new OpenApiContact
        {
            Name = "Yuri Grandez Del Aguila",
            Email = "yurigrandez@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/yuri-grandez-del-aguila-ab8a124b/"),
        },
    });
    c.MapType<string>(() => new OpenApiSchema { Nullable = true });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

#endregion Configurando Swagger y Documentación

#region Configurando Serilog

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("Log/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

#endregion Configurando Serilog

//agregando la inyección de dependencias de la capa de dominio
builder.Services.AddMyServices();

//agregando las validaciones de la capa de modelos en el DTO
builder.Services.AddMyValidations();

#region Configurando Jwt

var jwtSetting = builder.Configuration.GetSection("Jwt");
var Key = Encoding.UTF8.GetBytes(jwtSetting["key"]!);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSetting["Issuer"],
        ValidAudience = jwtSetting["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Key)
    };
});

#endregion Configurando Jwt

#region Configurando CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "origins",
                        builder =>
                        {
                            builder.AllowAnyMethod();
                            //builder.AllowAnyOrigin();
                            builder.WithOrigins("http://localhost:550");
                            builder.AllowAnyHeader();
                        });

});

#endregion Configurando CORS


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //configurando Swagger
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("origins");
app.MapControllers();
app.Run();
