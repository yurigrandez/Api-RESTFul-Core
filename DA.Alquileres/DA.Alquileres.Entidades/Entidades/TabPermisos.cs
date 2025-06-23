using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DA.Alquileres.Entidades.Entidades;

[Table("tabPERMISOS")]
public partial class TabPermisos
{
    [Key]
    public int Id { get; set; }

    public int? Codigo { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Modulo { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string? Accion { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaCreacion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaModificacion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaDesactivacion { get; set; }

    [InverseProperty("IdOperacionNavigation")]
    public virtual ICollection<TabTipoUsuariosPermisos> TabTipoUsuariosPermisos { get; set; } = new List<TabTipoUsuariosPermisos>();
}
