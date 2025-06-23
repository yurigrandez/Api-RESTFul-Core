Configurar Swagger
==================
1. Instalar los siguientes Nugget:
	- Swashbuckle.AspNetCore.Swagger
	- Swashbuckle.AspNetCore.SwaggerGen
	- Swashbuckle.AspNetCore.SwaggerUI

2. Configurar clase Program.cs:
	- En la parte de los services agregar la línea: 
			builder.Services.AddSwaggerGen();
	- En el if de app.Environment.IsDevelopmen() agregar las siguientes líneas
			app.UseSwagger();
			app.UseSwaggerUI();

3. Configurar Properties/launchSetting.json
	- En la sección "profiles" y "https" modificar:
		"launchBrowser": true
	- En la sección "profiles" y "https" agregar:
		"launchUrl": "swagger"

4. Al ejecutar el proyecto se abrirá el navegador y completar la url con la palabra "swagger"

Acceso a BD mediante ADO
========================
Anteriormente se usaba la librería System.Data.SqlCliente pero está siendo reemplazada (Deprecada) por Microsoft.Data.SqlCliente.

Documentación de la aplicación
==============================
1. Abrir las propiedades del proyecto Api y en la sección <PropertyGroup> agregar la siguiente línea:
	<GenerateDocumentationFile>true</GenerateDocumentationFile>

2. En la clase Program.cs modificar la línea builder.Services.AddSwaggerGen de la siguiente manera:
	builder.Services.AddSwaggerGen( c => {
		c.SwaggerDoc("v1", new OpenApiInfo{
			Title = "Da.Alquileres",
			Version = "v1",
			Description = "Documentación del WS de la aplicación DA.Alquileres",
			Contact = new OpenApiContact{
				Name = "Yuri Grandez Del Aguila",
				Email = "yurigrandez@gmail.com",
				Url = new Uri("https://www.linkedin.com/in/yuri-grandez-del-aguila-ab8a124b/"),
			},
		});
		c.MapType<string>(()=> new OpenApiSchema {Nullable = true});
		var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
		var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
		c.IncludeXmlComments(xmlPath);
	});

Instalación de EntityFrameWorkCore
==================================
Se debe instalar los siguientes paquetes Nugget:
	- Microsoft.EntityFrameWorkCore
	- Microsoft.EntityFrameWorkCore.Design
	- Microsoft.EntityFrameWorkCore.Relational
	- Microsoft.EntityFrameWorkCore.SqlServer
	- Microsoft.EntityFrameWorkCore.Tools

Obtener entidades de la BD
==========================
1. Abrir la consola de administrador de paquetes y seleccionar el proyecto destino
2. Escribir la siguiente sentencia:
	Scaffold-DbContext "Server=NBYURI;Database=dbALQUILERES;Uid=sa;Password=280390;Encrypt=false" Microsoft.EntityFrameWorkCore.SqlServer -OutputDir "Entidades" -DataAnnotations -Context "_dbAlquileresContext" -NoPluralize -Force

Notas:
======
Para poder ejecutar la sentencia Scaffold-DbContext tuve que establecer al proyecto DA.Alquileres.Enidades como proyecto de inicio de la solución

Log
===
Para usar Serilog se debe instalar los siguientes Nugget:
	Serilog.AspNetCore

Para usar el serilog se debe configurar en el archivo Program.cs lo siguiente:
1. Instanciar la librería con la sentencia:
	using Serilog;

2. En la región de los servicios incluir el siguiente código:
	Log.Logger = new LoggerConfiguration()
		.MinimumLevel.Debug()
		.MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
		.Enrich.FromLogContext()
		.WriteTo.Console()
		.WriteTo.File("Log/log-.txt", rollingInterval: RollingInterval.Day)
		.CreateLogger();

	builder.Host.UseSerilog();

JWT (Token)
===========
Para usar Serilog se debe instalar los siguientes Nugget:
	Microsoft.AspNetcore.Authentication.JwtBearer

Para usar el Jwt se debe configurar en el archivo Program.cs lo siguiente:
1. Configurar los parámetros necesarios en el archivo appsettings.json
	"Jwt":{
		"Key": "DA.Alquileres",
		"Issuer": "http://localhost:5057",
		"Audience": "http://localhost:5057",
		"Subject": "Alquileres",
		"ExpirationMinutes": 2
	}

2. En la región de los servicios incluir el siguiente código:
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

3. En la sección de app colocar la siguiente líne antes del UseAuthorization
	app.UseAuthentication();

FluenValidation
===============
1. Se debe intalar los siguientes Nugget:
	FluentValidation
	* FluentValidation.DependencyInjectionExtensions
	* FluentValidation.AspNetCore

	* A veces en necesario eliminar el Nugget FluentValidation.DependencyInjectionExtensions y reemplazarla por FluentValidation.AspNetCore (Aunque esté deprecada)

2. Agregar en la sección de servicios de la clase Program.cs:
	* builder.Services.AddFluentValidationAutoValidation()
	builder.Services.AddValidatorsFromAssemblyContaining<NombreClaseValidador>();

	*Se agrega cuando se usa el Nugget FluentValidation.AspNetCore

Mapster
=======
Para usar mapster se debe configurar lo siguiente:
1. Instalar el Nugget Mapster.DependencyInjection
2. En la clase Program.cs se debe instalanciar la librería:
	using Mapster;

3. En la sección de servicios agregar:
	builder.services.AddMapster();

Mapper
======
Para usar mapster se debe configurar lo siguiente:
1. Instalar el Nugget Dapper
2. Crear el context y en la sección de servicios de la clase Program.cs se agregar:
	builder.services.AddSingleton<DapperContext>();

AutoMapper
==========
Se debe instalar el Nugget:
	AutoMapper.Extensions.Microsoft.DependencyInjection

