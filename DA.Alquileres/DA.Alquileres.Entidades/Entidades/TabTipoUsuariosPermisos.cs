using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DA.Alquileres.Entidades.Entidades;

[Table("tabTIPO_USUARIOS_PERMISOS")]
public partial class TabTipoUsuariosPermisos
{
    [Key]
    public int Id { get; set; }

    public int? IdTipoUsuario { get; set; }

    public int? IdOperacion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaCreacion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaModificacion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaDesactivacion { get; set; }

    [ForeignKey("IdOperacion")]
    [InverseProperty("TabTipoUsuariosPermisos")]
    public virtual TabPermisos? IdOperacionNavigation { get; set; }

    [ForeignKey("IdTipoUsuario")]
    [InverseProperty("TabTipoUsuariosPermisos")]
    public virtual TabTipoUsuarios? IdTipoUsuarioNavigation { get; set; }
}
