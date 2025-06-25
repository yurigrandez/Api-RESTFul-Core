using DA.Alquileres.DTO.Usuario;
using FluentValidation;

namespace DA.Alquileres.API.Validadores
{
    /// <summary>
    /// Clase que valida a la entidad
    /// </summary>
    public class UsuarioNuevoDTOValidador : AbstractValidator<UsuarioNuevoDTO>
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public UsuarioNuevoDTOValidador()
        {
            RuleFor(x => x.Codigo)
                .NotEmpty().WithMessage("El código es requerido");
            RuleFor(x => x.Correo)
                .NotEmpty().WithMessage("Debe ingresar un correo");
            RuleFor(x => x.Clave)
                .NotEmpty().WithMessage("Debe ingresar una clave");
        }
    }
}
