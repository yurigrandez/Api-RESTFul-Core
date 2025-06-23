using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DA.Alquileres.Entidades.Entidades;

[Table("tabTIPO_LOCALES")]
public partial class TabTipoLocales
{
    [Key]
    public int Id { get; set; }

    [StringLength(5)]
    public string? TipoLocal { get; set; }

    [StringLength(150)]
    public string? Descripcion { get; set; }

    [Column("fechaCreacion", TypeName = "smalldatetime")]
    public DateTime? FechaCreacion { get; set; }

    [Column("fechaModificacion", TypeName = "smalldatetime")]
    public DateTime? FechaModificacion { get; set; }

    [Column("fechaDesactivacion", TypeName = "smalldatetime")]
    public DateTime? FechaDesactivacion { get; set; }

    [InverseProperty("IdTipoLocalNavigation")]
    public virtual ICollection<TabLocales> TabLocales { get; set; } = new List<TabLocales>();
}
