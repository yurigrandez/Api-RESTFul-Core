using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DA.Alquileres.Entidades.Entidades;

[Table("tabINCIDENCIAS")]
public partial class TabIncidencias
{
    [Key]
    public int Id { get; set; }

    public int IdUsuarioRegistra { get; set; }

    public int IdCliente { get; set; }

    public int IdTipoIncidente { get; set; }

    public string? Descripcion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaCreacion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaModificacion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaDesactivacion { get; set; }

    [ForeignKey("IdCliente")]
    [InverseProperty("TabIncidencias")]
    public virtual TabClientes IdClienteNavigation { get; set; } = null!;

    [ForeignKey("IdTipoIncidente")]
    [InverseProperty("TabIncidencias")]
    public virtual TabTipoIncidencias IdTipoIncidenteNavigation { get; set; } = null!;

    [ForeignKey("IdUsuarioRegistra")]
    [InverseProperty("TabIncidencias")]
    public virtual TabUsuarios IdUsuarioRegistraNavigation { get; set; } = null!;
}
