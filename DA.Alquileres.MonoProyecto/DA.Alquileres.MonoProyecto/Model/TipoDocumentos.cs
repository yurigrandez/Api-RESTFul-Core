using System.ComponentModel.DataAnnotations.Schema;

namespace DA.Alquileres.MonoProyecto.Model
{
    [Table("tabTIPO_DOCUMENTOS")]
    public class TipoDocumentos
    {
        public int Id { get; set; }
        public string? Abreviatura { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaDesactivacion { get; set; }
    }
}
