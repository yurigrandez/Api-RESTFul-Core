using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Alquileres.DTO.Usuario
{
    public class UsuarioLoginRequestDTO
    {
        public string? Correo { get; set; }
        public string? Clave { get; set; }
    }
}
