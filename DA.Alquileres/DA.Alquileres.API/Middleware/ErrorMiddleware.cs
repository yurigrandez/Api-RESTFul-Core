using AutoMapper;
using DA.Alquileres.DTO.General;
using System.Text;

namespace DA.Alquileres.API.Middleware
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IMapper mapper;
        private readonly ILogger<ErrorMiddleware> logger;

        public ErrorMiddleware(RequestDelegate next, IMapper mapper, ILogger<ErrorMiddleware> logger)
        {
            this.next = next;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                context.Request.EnableBuffering();
                string requestBody;
                using (var reader = new StreamReader(context.Request.Body, encoding: Encoding.UTF8, leaveOpen: true))
                {
                    requestBody = await reader.ReadToEndAsync();
                }

                logger.LogInformation("Request Body: {RequestBody}", requestBody);
                context.Request.Body.Position = 0;

                //obteniento la cabecera ""CodigoAplicacion", de la petición HTTP
                string Empresa = context.Request.Headers["Empresa"].FirstOrDefault();

                if (Empresa != "DASolucionesInversiones")
                {
                    throw new Exception("Header => Empresa invalida");
                }

                await next(context);
            }
            catch (Exception ex)
            {
                var respuesta = new GeneralResponse();
                respuesta.Success = false;
                respuesta.ShowAlert = true;
                respuesta.Mensaje = ex.Message;
                respuesta.Title = "Middleware";
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                await context.Response.WriteAsJsonAsync(respuesta);
            }

        }
    }
}
