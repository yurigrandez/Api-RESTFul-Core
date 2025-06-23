using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DA.Alquileres.Entidades.Entidades;

[Table("tabESTADOS")]
[Index("Abreviatura", Name = "UQ__tabESTAD__902DE78D49AD32AC", IsUnique = true)]
public partial class TabEstados
{
    [Key]
    public int Id { get; set; }

    [StringLength(10)]
    public string Abreviatura { get; set; } = null!;

    [StringLength(15)]
    public string? Nombre { get; set; }

    [StringLength(100)]
    public string? Descripcion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaCreacion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaModificacion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaDesactivacion { get; set; }

    [InverseProperty("IdEstadoNavigation")]
    public virtual ICollection<TabContratos> TabContratos { get; set; } = new List<TabContratos>();
}
