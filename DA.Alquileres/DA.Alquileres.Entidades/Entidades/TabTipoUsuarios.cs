using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DA.Alquileres.Entidades.Entidades;

/// <summary>
/// Tabla que almacena los diferentes tipos de usuarios del sistema (roles o perfiles).
/// </summary>
[Table("tabTIPO_USUARIOS")]
[Index("Abreviatura", Name = "UQ__tabTIPO___902DE78D291CC1D0", IsUnique = true)]
public partial class TabTipoUsuarios
{
    /// <summary>
    /// Identificador único del tipo de usuario. Clave primaria autoincremental.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Abreviatura única que representa el tipo de usuario (por ejemplo, ADM, CLI, etc.).
    /// </summary>
    [StringLength(10)]
    public string Abreviatura { get; set; } = null!;

    /// <summary>
    /// Nombre completo o formal del tipo de usuario.
    /// </summary>
    [StringLength(25)]
    public string? Nombre { get; set; }

    /// <summary>
    /// Descripción detallada del tipo de usuario o su función en el sistema.
    /// </summary>
    [StringLength(100)]
    public string? Descripcion { get; set; }

    /// <summary>
    /// Fecha en la que se creó el registro del tipo de usuario.
    /// </summary>
    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaCreacion { get; set; }

    /// <summary>
    /// Fecha de la última modificación del registro.
    /// </summary>
    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaModificacion { get; set; }

    /// <summary>
    /// Fecha en la que se desactivó el tipo de usuario, si corresponde.
    /// </summary>
    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaDesactivacion { get; set; }

    [InverseProperty("IdTipoUsuarioNavigation")]
    public virtual ICollection<TabTipoUsuariosPermisos> TabTipoUsuariosPermisos { get; set; } = new List<TabTipoUsuariosPermisos>();

    [InverseProperty("IdTipoUsuarioNavigation")]
    public virtual ICollection<TabUsuarios> TabUsuarios { get; set; } = new List<TabUsuarios>();
}
