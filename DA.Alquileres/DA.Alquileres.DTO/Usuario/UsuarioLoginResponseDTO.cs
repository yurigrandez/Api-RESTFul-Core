using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Alquileres.DTO.Usuario
{
    public class UsuarioLoginResponseDTO
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Paterno { get; set; }
        public string? Materno { get; set; }
        public int? IdTipoUsuario { get; set; }
        public string NombreCompleto
        {
            get
            {
                return string.Concat(Nombre, " ", Paterno, " ", Materno);
            }
        }
        public string Token { get; set; }
    }
}
