namespace DA.Alquileres.API
{
    /// <summary>
    /// Clase para registrar las clases de validación
    /// </summary>
    public static class ServicesValidationExtensions
    {
        /// <summary>
        /// Método para registrar las clases de validación
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMyValidations(this IServiceCollection services)
        {
            //services.AddValidatorsFromAssemblyContaining<HorarioDtoValidator>();
            //services.AddTransient<IValidator<HorarioDto>, HorarioDtoValidator>();
            return services;
        }
    }
}
