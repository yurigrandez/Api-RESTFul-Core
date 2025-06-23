using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DA.Alquileres.Entidades.Entidades;

[Table("tabEVENTOS")]
public partial class TabEventos
{
    [Key]
    public int Id { get; set; }

    [StringLength(25)]
    public string? Estacion { get; set; }

    [StringLength(15)]
    public string? Entidad { get; set; }

    public int? IdUsuario { get; set; }

    [StringLength(15)]
    public string? CodigoUsuario { get; set; }

    [Column("mensaje")]
    public string? Mensaje { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaCreacion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaModificacion { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? FechaDesactivacion { get; set; }
}
