using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DA.Alquileres.Entidades.Entidades;

[Table("tabTIPO_INCIDENCIAS")]
[Index("Abreviatura", Name = "UQ__tabTIPO___902DE78D53EBC8DA", IsUnique = true)]
public partial class TabTipoIncidencias
{
    [Key]
    public int Id { get; set; }

    [StringLength(10)]
    public string Abreviatura { get; set; } = null!;

    [StringLength(25)]
    public string? Nombre { get; set; }

    [StringLength(100)]
    public string? Descripcion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaCreacion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaModificacion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaDesactivacion { get; set; }

    [InverseProperty("IdTipoIncidenteNavigation")]
    public virtual ICollection<TabIncidencias> TabIncidencias { get; set; } = new List<TabIncidencias>();
}
