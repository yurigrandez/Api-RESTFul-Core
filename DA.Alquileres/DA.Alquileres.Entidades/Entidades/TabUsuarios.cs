using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DA.Alquileres.Entidades.Entidades;

/// <summary>
/// Información de usuarios del sistema
/// </summary>
[Table("tabUSUARIOS")]
[Index("Codigo", Name = "UQ__tabUSUAR__06370DAC81126265", IsUnique = true)]
public partial class TabUsuarios
{
    /// <summary>
    /// Identificador único del usuario (PK).
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Código único del usuario dentro del sistema.
    /// </summary>
    [StringLength(15)]
    public string Codigo { get; set; } = null!;

    /// <summary>
    /// Nombres del usuario.
    /// </summary>
    [StringLength(50)]
    public string? Nombre { get; set; }

    /// <summary>
    /// Apellido paterno del usuario.
    /// </summary>
    [StringLength(50)]
    public string? Paterno { get; set; }

    /// <summary>
    /// Apellido materno del usuario.
    /// </summary>
    [StringLength(50)]
    public string? Materno { get; set; }

    /// <summary>
    /// Correo electrónico del usuario.
    /// </summary>
    [StringLength(50)]
    public string? Correo { get; set; }

    /// <summary>
    /// Contraseña del usuario.
    /// </summary>
    [StringLength(50)]
    public string? Clave { get; set; }

    /// <summary>
    /// Referencia al tipo de usuario (rol).
    /// </summary>
    public int? IdTipoUsuario { get; set; }

    /// <summary>
    /// Referencia al tipo de documento de identidad.
    /// </summary>
    public int? IdtipoDocumento { get; set; }

    /// <summary>
    /// Número del documento de identidad del usuario.
    /// </summary>
    [StringLength(25)]
    public string? NumeroDocumento { get; set; }

    /// <summary>
    /// Dirección física del usuario.
    /// </summary>
    [StringLength(250)]
    public string? Direccion { get; set; }

    /// <summary>
    /// Teléfono de contacto del usuario.
    /// </summary>
    [StringLength(25)]
    public string? Telefono { get; set; }

    /// <summary>
    /// Fecha de creación del registro.
    /// </summary>
    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaCreacion { get; set; }

    /// <summary>
    /// Fecha de la última modificación del registro.
    /// </summary>
    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaModificacion { get; set; }

    /// <summary>
    /// Fecha en la que el usuario fue desactivado.
    /// </summary>
    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaDesactivacion { get; set; }

    [ForeignKey("IdTipoUsuario")]
    [InverseProperty("TabUsuarios")]
    public virtual TabTipoUsuarios? IdTipoUsuarioNavigation { get; set; }

    [ForeignKey("IdtipoDocumento")]
    [InverseProperty("TabUsuarios")]
    public virtual TabTipoDocumentos? IdtipoDocumentoNavigation { get; set; }

    [InverseProperty("IdUsuarioRegistraNavigation")]
    public virtual ICollection<TabComprobantes> TabComprobantes { get; set; } = new List<TabComprobantes>();

    [InverseProperty("IdUsuarioAutorizaNavigation")]
    public virtual ICollection<TabContratos> TabContratosIdUsuarioAutorizaNavigation { get; set; } = new List<TabContratos>();

    [InverseProperty("IdUsuarioRegistraNavigation")]
    public virtual ICollection<TabContratos> TabContratosIdUsuarioRegistraNavigation { get; set; } = new List<TabContratos>();

    [InverseProperty("IdUsuarioRegistraNavigation")]
    public virtual ICollection<TabIncidencias> TabIncidencias { get; set; } = new List<TabIncidencias>();
}
