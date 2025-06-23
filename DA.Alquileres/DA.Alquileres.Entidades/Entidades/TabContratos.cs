using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DA.Alquileres.Entidades.Entidades;

[Table("tabCONTRATOS")]
[Index("Codigo", Name = "UQ__tabCONTR__06370DACB4165995", IsUnique = true)]
public partial class TabContratos
{
    [Key]
    public int Id { get; set; }

    [StringLength(15)]
    public string Codigo { get; set; } = null!;

    public int? IdCliente { get; set; }

    public int? IdUsuarioRegistra { get; set; }

    public int? IdUsuarioAutoriza { get; set; }

    public int? IdLocal { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaInicio { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaFin { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? MontoAlquiler { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? MontoLuz { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? MontoAgua { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? MontoMantenimiento { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? MontoOtros { get; set; }

    public string? Observaciones { get; set; }

    public int? IdEstado { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaCreacion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaModificacion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaDesactivacion { get; set; }

    [ForeignKey("IdCliente")]
    [InverseProperty("TabContratos")]
    public virtual TabClientes? IdClienteNavigation { get; set; }

    [ForeignKey("IdEstado")]
    [InverseProperty("TabContratos")]
    public virtual TabEstados? IdEstadoNavigation { get; set; }

    [ForeignKey("IdLocal")]
    [InverseProperty("TabContratos")]
    public virtual TabLocales? IdLocalNavigation { get; set; }

    [ForeignKey("IdUsuarioAutoriza")]
    [InverseProperty("TabContratosIdUsuarioAutorizaNavigation")]
    public virtual TabUsuarios? IdUsuarioAutorizaNavigation { get; set; }

    [ForeignKey("IdUsuarioRegistra")]
    [InverseProperty("TabContratosIdUsuarioRegistraNavigation")]
    public virtual TabUsuarios? IdUsuarioRegistraNavigation { get; set; }

    [InverseProperty("IdContratoNavigation")]
    public virtual ICollection<TabComprobantes> TabComprobantes { get; set; } = new List<TabComprobantes>();
}
