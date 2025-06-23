using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DA.Alquileres.Entidades.Entidades;

[Table("tabCOMPROBANTE_DETALLES")]
public partial class TabComprobanteDetalles
{
    [Key]
    public int Id { get; set; }

    public int IdComprobante { get; set; }

    [StringLength(250)]
    public string? Concepto { get; set; }

    public int? Cantidad { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? PrecioUnitario { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? SubTotal { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaCreacion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaModificacion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaDesactivacion { get; set; }

    [ForeignKey("IdComprobante")]
    [InverseProperty("TabComprobanteDetalles")]
    public virtual TabComprobantes IdComprobanteNavigation { get; set; } = null!;
}
