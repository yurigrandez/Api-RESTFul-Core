using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DA.Alquileres.Entidades.Entidades;

[Table("tabEMPRESAS")]
public partial class TabEmpresas
{
    [Key]
    public int Id { get; set; }

    [StringLength(15)]
    public string Codigo { get; set; } = null!;

    [StringLength(100)]
    public string? Nombre { get; set; }

    [StringLength(250)]
    public string? Direccion { get; set; }

    [StringLength(11)]
    public string? Ruc { get; set; }

    [StringLength(25)]
    public string? Telefono { get; set; }

    [StringLength(15)]
    public string? Movil { get; set; }

    [StringLength(150)]
    public string? NombreContacto { get; set; }

    [StringLength(50)]
    public string? CorreoContacto { get; set; }

    [StringLength(15)]
    public string? TlfContacto { get; set; }

    [StringLength(15)]
    public string? MovilContacto { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaCreacion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaModificacion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaDesactivacion { get; set; }

    public byte[]? ImgEmpresa { get; set; }

    [StringLength(5)]
    public string? ExtensionImg { get; set; }

    [InverseProperty("IdEmpresaNavigation")]
    public virtual ICollection<TabComprobantes> TabComprobantes { get; set; } = new List<TabComprobantes>();

    [InverseProperty("IdEmpresaNavigation")]
    public virtual ICollection<TabLocales> TabLocales { get; set; } = new List<TabLocales>();
}
