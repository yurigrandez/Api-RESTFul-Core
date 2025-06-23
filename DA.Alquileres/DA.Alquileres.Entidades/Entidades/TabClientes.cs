using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DA.Alquileres.Entidades.Entidades;

[Table("tabCLIENTES")]
[Index("Codigo", Name = "UQ__tabCLIEN__06370DAC00D372B5", IsUnique = true)]
public partial class TabClientes
{
    [Key]
    public int Id { get; set; }

    [StringLength(15)]
    public string Codigo { get; set; } = null!;

    [StringLength(50)]
    public string? Nombre { get; set; }

    [StringLength(50)]
    public string? Paterno { get; set; }

    [StringLength(50)]
    public string? Materno { get; set; }

    public int? IdTipoDocumento { get; set; }

    [StringLength(25)]
    public string? NumeroDocumento { get; set; }

    [StringLength(50)]
    public string? Correo { get; set; }

    [StringLength(250)]
    public string? Direccion { get; set; }

    [StringLength(25)]
    public string? Yelefono { get; set; }

    public int? IdTipoComprobante { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaCreacion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaModificacion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaDesactivacion { get; set; }

    [ForeignKey("IdTipoComprobante")]
    [InverseProperty("TabClientes")]
    public virtual TabTipoComprobantes? IdTipoComprobanteNavigation { get; set; }

    [ForeignKey("IdTipoDocumento")]
    [InverseProperty("TabClientes")]
    public virtual TabTipoDocumentos? IdTipoDocumentoNavigation { get; set; }

    [InverseProperty("IdClienteNavigation")]
    public virtual ICollection<TabComprobantes> TabComprobantes { get; set; } = new List<TabComprobantes>();

    [InverseProperty("IdClienteNavigation")]
    public virtual ICollection<TabContratos> TabContratos { get; set; } = new List<TabContratos>();

    [InverseProperty("IdClienteNavigation")]
    public virtual ICollection<TabIncidencias> TabIncidencias { get; set; } = new List<TabIncidencias>();
}
