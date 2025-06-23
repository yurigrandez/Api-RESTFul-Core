using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DA.Alquileres.Entidades.Vistas;

[Keyless]
public partial class VisUsuarios
{
    public int Id { get; set; }

    [StringLength(15)]
    public string Codigo { get; set; } = null!;

    [StringLength(50)]
    public string? Nombre { get; set; }

    [StringLength(50)]
    public string? Paterno { get; set; }

    [StringLength(50)]
    public string? Materno { get; set; }

    [StringLength(50)]
    public string? Correo { get; set; }

    [StringLength(50)]
    public string? Clave { get; set; }

    public int? IdTipoUsuario { get; set; }

    [StringLength(25)]
    public string? TipoUsuario { get; set; }

    public int? IdtipoDocumento { get; set; }

    [StringLength(25)]
    public string? TipoDocumento { get; set; }

    [StringLength(25)]
    public string? NumeroDocumento { get; set; }

    [StringLength(250)]
    public string? Direccion { get; set; }

    [StringLength(25)]
    public string? Telefono { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaCreacion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaModificacion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaDesactivacion { get; set; }
}
