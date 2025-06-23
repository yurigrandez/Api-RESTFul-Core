using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DA.Alquileres.Entidades.Entidades;

/// <summary>
/// Tabla que almacena los tipos de documentos de identidad (DNI, RUC, pasaporte, etc.).
/// </summary>
[Table("tabTIPO_DOCUMENTOS")]
[Index("Abreviatura", Name = "UQ__tabTIPO___902DE78DB94D452B", IsUnique = true)]
public partial class TabTipoDocumentos
{
    /// <summary>
    /// Identificador único del tipo de documento. Clave primaria autoincremental.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Abreviatura única del tipo de documento (ej. DNI, RUC, PAS).
    /// </summary>
    [StringLength(10)]
    public string Abreviatura { get; set; } = null!;

    /// <summary>
    /// Nombre completo o formal del tipo de documento.
    /// </summary>
    [StringLength(25)]
    public string? Nombre { get; set; }

    /// <summary>
    /// Descripción detallada del tipo de documento.
    /// </summary>
    [StringLength(100)]
    public string? Descripcion { get; set; }

    /// <summary>
    /// Fecha en la que se creó el registro del tipo de documento.
    /// </summary>
    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaCreacion { get; set; }

    /// <summary>
    /// Fecha de la última modificación del tipo de documento.
    /// </summary>
    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaModificacion { get; set; }

    /// <summary>
    /// Fecha en la que el tipo de documento fue desactivado, si corresponde.
    /// </summary>
    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaDesactivacion { get; set; }

    [InverseProperty("IdTipoDocumentoNavigation")]
    public virtual ICollection<TabClientes> TabClientes { get; set; } = new List<TabClientes>();

    [InverseProperty("IdtipoDocumentoNavigation")]
    public virtual ICollection<TabUsuarios> TabUsuarios { get; set; } = new List<TabUsuarios>();
}
