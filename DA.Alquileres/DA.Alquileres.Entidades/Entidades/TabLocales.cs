using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DA.Alquileres.Entidades.Entidades;

[Table("tabLOCALES")]
[Index("Codigo", Name = "UQ__tabLOCAL__06370DAC4F1BD166", IsUnique = true)]
public partial class TabLocales
{
    [Key]
    public int Id { get; set; }

    [StringLength(15)]
    public string Codigo { get; set; } = null!;

    public int? IdTipoLocal { get; set; }

    public int? IdEmpresa { get; set; }

    [StringLength(250)]
    public string? Direccion { get; set; }

    public int? Interior { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TotalM2 { get; set; }

    [StringLength(150)]
    public string? Dimensiones { get; set; }

    public int? NroPisos { get; set; }

    public byte[]? ImgFrontis { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaCreacion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaModificacion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaDesactivacion { get; set; }

    [ForeignKey("IdEmpresa")]
    [InverseProperty("TabLocales")]
    public virtual TabEmpresas? IdEmpresaNavigation { get; set; }

    [ForeignKey("IdTipoLocal")]
    [InverseProperty("TabLocales")]
    public virtual TabTipoLocales? IdTipoLocalNavigation { get; set; }

    [InverseProperty("IdLocalNavigation")]
    public virtual ICollection<TabContratos> TabContratos { get; set; } = new List<TabContratos>();
}
