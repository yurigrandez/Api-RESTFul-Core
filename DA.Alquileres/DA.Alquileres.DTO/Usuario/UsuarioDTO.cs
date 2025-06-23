using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Alquileres.DTO.Usuario
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Paterno { get; set; }
        public string? Materno { get; set; }
        public string? Correo { get; set; }
        public string? Clave { get; set; }
        public int? IdTipoUsuario { get; set; }
        public int? IdtipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaDesactivacion { get; set; }
        public string NombreCompleto
        {
            get
            {
                return string.Concat(Nombre, " ", Paterno, " ", Materno);
            }
        }
    }
}
