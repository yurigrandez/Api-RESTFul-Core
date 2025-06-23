using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DA.Alquileres.Entidades.Entidades;

[Table("tabCOMPROBANTES")]
public partial class TabComprobantes
{
    [Key]
    public int Id { get; set; }

    public int? IdEmpresa { get; set; }

    public int? IdTipoComprobante { get; set; }

    [StringLength(10)]
    public string? NroComprobante { get; set; }

    public int? IdCliente { get; set; }

    public int? IdContrato { get; set; }

    public int? IdUsuarioRegistra { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaEmision { get; set; }

    public int? IdTipoMoneda { get; set; }

    public string? Observacion { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? ImporteTotal { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaCreacion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaModificacion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaDesactivacion { get; set; }

    [ForeignKey("IdCliente")]
    [InverseProperty("TabComprobantes")]
    public virtual TabClientes? IdClienteNavigation { get; set; }

    [ForeignKey("IdContrato")]
    [InverseProperty("TabComprobantes")]
    public virtual TabContratos? IdContratoNavigation { get; set; }

    [ForeignKey("IdEmpresa")]
    [InverseProperty("TabComprobantes")]
    public virtual TabEmpresas? IdEmpresaNavigation { get; set; }

    [ForeignKey("IdTipoComprobante")]
    [InverseProperty("TabComprobantes")]
    public virtual TabTipoComprobantes? IdTipoComprobanteNavigation { get; set; }

    [ForeignKey("IdTipoMoneda")]
    [InverseProperty("TabComprobantes")]
    public virtual TabTipoMonedas? IdTipoMonedaNavigation { get; set; }

    [ForeignKey("IdUsuarioRegistra")]
    [InverseProperty("TabComprobantes")]
    public virtual TabUsuarios? IdUsuarioRegistraNavigation { get; set; }

    [InverseProperty("IdComprobanteNavigation")]
    public virtual ICollection<TabComprobanteDetalles> TabComprobanteDetalles { get; set; } = new List<TabComprobanteDetalles>();
}
