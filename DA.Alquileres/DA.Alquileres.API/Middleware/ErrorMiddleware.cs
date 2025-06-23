using AutoMapper;
using DA.Alquileres.DTO.General;
using System.Text;

namespace DA.Alquileres.API.Middleware
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IMapper mapper;

        public ErrorMiddleware(RequestDelegate next, IMapper mapper)
        {
            this.next = next;
            this.mapper = mapper;
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

                context.Request.Body.Position = 0;

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
