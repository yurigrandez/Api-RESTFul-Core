using DA.Alquileres.Entidades;
using DA.Alquileres.IRepository;
using DA.Alquileres.IServices;
using DA.Alquileres.Repository;
using DA.Alquileres.Services;

namespace DA.Alquileres.API
{
    /// <summary>
    /// Clase para agregar las inyecion de dependencias
    /// </summary>
    public static class ServicesInyeccionDependenciesExtensions
    {
        /// <summary>
        /// Método para registrar las inyecciones de dependencia
        /// </summary>
        /// <param name="services">services del program</param>
        /// <returns></returns>
        public static IServiceCollection AddMyServices(this IServiceCollection services)
        {
            /*AutoMapper*/
            services.AddAutoMapper(typeof(IStartup).Assembly, typeof(AutoMapping).Assembly);

            /*Repository*/
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            /*Services*/
            services.AddScoped<IUsuarioServices, UsuarioServices>();

            return services;
        }
    }
}
