using System;
using System.Collections.Generic;
using DA.Alquileres.Entidades.Vistas;
using Microsoft.EntityFrameworkCore;

namespace DA.Alquileres.Entidades.Entidades;

public partial class _dbAlquileresContext : DbContext
{
    public _dbAlquileresContext()
    {
    }

    public _dbAlquileresContext(DbContextOptions<_dbAlquileresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TabClientes> TabClientes { get; set; }

    public virtual DbSet<TabComprobanteDetalles> TabComprobanteDetalles { get; set; }

    public virtual DbSet<TabComprobantes> TabComprobantes { get; set; }

    public virtual DbSet<TabContratos> TabContratos { get; set; }

    public virtual DbSet<TabEmpresas> TabEmpresas { get; set; }

    public virtual DbSet<TabEstados> TabEstados { get; set; }

    public virtual DbSet<TabEventos> TabEventos { get; set; }

    public virtual DbSet<TabIncidencias> TabIncidencias { get; set; }

    public virtual DbSet<TabLocales> TabLocales { get; set; }

    public virtual DbSet<TabPermisos> TabPermisos { get; set; }

    public virtual DbSet<TabSecuencias> TabSecuencias { get; set; }

    public virtual DbSet<TabTipoComprobantes> TabTipoComprobantes { get; set; }

    public virtual DbSet<TabTipoDocumentos> TabTipoDocumentos { get; set; }

    public virtual DbSet<TabTipoIncidencias> TabTipoIncidencias { get; set; }

    public virtual DbSet<TabTipoLocales> TabTipoLocales { get; set; }

    public virtual DbSet<TabTipoMonedas> TabTipoMonedas { get; set; }

    public virtual DbSet<TabTipoUsuarios> TabTipoUsuarios { get; set; }

    public virtual DbSet<TabTipoUsuariosPermisos> TabTipoUsuariosPermisos { get; set; }

    public virtual DbSet<TabUsuarios> TabUsuarios { get; set; }

    public virtual DbSet<VisUsuarios> VisUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TabClientes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tabCLIEN__3214EC0727A4DEF5");

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdTipoComprobanteNavigation).WithMany(p => p.TabClientes).HasConstraintName("fk_Cliente_TipoComprobante");

            entity.HasOne(d => d.IdTipoDocumentoNavigation).WithMany(p => p.TabClientes).HasConstraintName("fk_Cliente_TipoDocumento");
        });

        modelBuilder.Entity<TabComprobanteDetalles>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tabCOMPR__3214EC07EEE526B6");

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdComprobanteNavigation).WithMany(p => p.TabComprobanteDetalles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ComDetalle_Comprobante");
        });

        modelBuilder.Entity<TabComprobantes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tabCOMPR__3214EC078D6BB3A4");

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.TabComprobantes).HasConstraintName("fk_Comprobante_Cliente");

            entity.HasOne(d => d.IdContratoNavigation).WithMany(p => p.TabComprobantes).HasConstraintName("fk_Comprobante_Contrato");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.TabComprobantes).HasConstraintName("fk_Comprobante_Empresa");

            entity.HasOne(d => d.IdTipoComprobanteNavigation).WithMany(p => p.TabComprobantes).HasConstraintName("fk_Comprobante_TipoComprobante");

            entity.HasOne(d => d.IdTipoMonedaNavigation).WithMany(p => p.TabComprobantes).HasConstraintName("fk_Comprobante_TipoMoneda");

            entity.HasOne(d => d.IdUsuarioRegistraNavigation).WithMany(p => p.TabComprobantes).HasConstraintName("fk_Comprobante_UsuRegistra");
        });

        modelBuilder.Entity<TabContratos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tabCONTR__3214EC076B228D20");

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.TabContratos).HasConstraintName("fk_Contrato_Cliente");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.TabContratos).HasConstraintName("fk_Contrato_Estado");

            entity.HasOne(d => d.IdLocalNavigation).WithMany(p => p.TabContratos).HasConstraintName("fk_Contrato_Local");

            entity.HasOne(d => d.IdUsuarioAutorizaNavigation).WithMany(p => p.TabContratosIdUsuarioAutorizaNavigation).HasConstraintName("fk_Contrato_UsuAutoriza");

            entity.HasOne(d => d.IdUsuarioRegistraNavigation).WithMany(p => p.TabContratosIdUsuarioRegistraNavigation).HasConstraintName("fk_Contrato_UsuRegistra");
        });

        modelBuilder.Entity<TabEmpresas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tabEMPRE__3214EC07EAC255FB");

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TabEstados>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tabESTAD__3214EC074B0C14A7");

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TabEventos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tabEVENT__3214EC07476AA862");

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TabIncidencias>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tabINCID__3214EC07E4E458D4");

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.TabIncidencias)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Incidente_Cliente");

            entity.HasOne(d => d.IdTipoIncidenteNavigation).WithMany(p => p.TabIncidencias)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Incidente_TipoIncidente");

            entity.HasOne(d => d.IdUsuarioRegistraNavigation).WithMany(p => p.TabIncidencias)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Incidente_UsuRegistra");
        });

        modelBuilder.Entity<TabLocales>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tabLOCAL__3214EC07417B4D38");

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.TabLocales).HasConstraintName("fk_Locales_Empresas");

            entity.HasOne(d => d.IdTipoLocalNavigation).WithMany(p => p.TabLocales).HasConstraintName("fk_Locales_Empresa");
        });

        modelBuilder.Entity<TabPermisos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tabPERMI__3214EC078ED26BCE");

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TabSecuencias>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tabSECUE__3214EC0728C9E631");

            entity.Property(e => e.Anio).IsFixedLength();
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Prefijo).IsFixedLength();
        });

        modelBuilder.Entity<TabTipoComprobantes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tabTIPO___3214EC07E5E00AC4");

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TabTipoDocumentos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tabTIPO___3214EC07D3591E42");

            entity.ToTable("tabTIPO_DOCUMENTOS", tb => tb.HasComment("Tabla que almacena los tipos de documentos de identidad (DNI, RUC, pasaporte, etc.)."));

            entity.Property(e => e.Id).HasComment("Identificador único del tipo de documento. Clave primaria autoincremental.");
            entity.Property(e => e.Abreviatura).HasComment("Abreviatura única del tipo de documento (ej. DNI, RUC, PAS).");
            entity.Property(e => e.Descripcion).HasComment("Descripción detallada del tipo de documento.");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha en la que se creó el registro del tipo de documento.");
            entity.Property(e => e.FechaDesactivacion).HasComment("Fecha en la que el tipo de documento fue desactivado, si corresponde.");
            entity.Property(e => e.FechaModificacion).HasComment("Fecha de la última modificación del tipo de documento.");
            entity.Property(e => e.Nombre).HasComment("Nombre completo o formal del tipo de documento.");
        });

        modelBuilder.Entity<TabTipoIncidencias>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tabTIPO___3214EC07C84C5305");

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TabTipoLocales>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tabTIPO___3214EC07F37E62A4");

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TabTipoMonedas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tabTIPO___3214EC077BFADD84");

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TabTipoUsuarios>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tabTIPO___3214EC07263ECC2B");

            entity.ToTable("tabTIPO_USUARIOS", tb => tb.HasComment("Tabla que almacena los diferentes tipos de usuarios del sistema (roles o perfiles)."));

            entity.Property(e => e.Id).HasComment("Identificador único del tipo de usuario. Clave primaria autoincremental.");
            entity.Property(e => e.Abreviatura).HasComment("Abreviatura única que representa el tipo de usuario (por ejemplo, ADM, CLI, etc.).");
            entity.Property(e => e.Descripcion).HasComment("Descripción detallada del tipo de usuario o su función en el sistema.");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha en la que se creó el registro del tipo de usuario.");
            entity.Property(e => e.FechaDesactivacion).HasComment("Fecha en la que se desactivó el tipo de usuario, si corresponde.");
            entity.Property(e => e.FechaModificacion).HasComment("Fecha de la última modificación del registro.");
            entity.Property(e => e.Nombre).HasComment("Nombre completo o formal del tipo de usuario.");
        });

        modelBuilder.Entity<TabTipoUsuariosPermisos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tabTIPO___3214EC0752EDBD42");

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdOperacionNavigation).WithMany(p => p.TabTipoUsuariosPermisos).HasConstraintName("fk_Permisos_Asignado");

            entity.HasOne(d => d.IdTipoUsuarioNavigation).WithMany(p => p.TabTipoUsuariosPermisos).HasConstraintName("fk_TipoUsuario_Asignado");
        });

        modelBuilder.Entity<TabUsuarios>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tabUSUAR__3214EC072ECE6569");

            entity.ToTable("tabUSUARIOS", tb => tb.HasComment("Información de usuarios del sistema"));

            entity.Property(e => e.Id).HasComment("Identificador único del usuario (PK).");
            entity.Property(e => e.Clave).HasComment("Contraseña del usuario.");
            entity.Property(e => e.Codigo).HasComment("Código único del usuario dentro del sistema.");
            entity.Property(e => e.Correo).HasComment("Correo electrónico del usuario.");
            entity.Property(e => e.Direccion).HasComment("Dirección física del usuario.");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de creación del registro.");
            entity.Property(e => e.FechaDesactivacion).HasComment("Fecha en la que el usuario fue desactivado.");
            entity.Property(e => e.FechaModificacion).HasComment("Fecha de la última modificación del registro.");
            entity.Property(e => e.IdTipoUsuario).HasComment("Referencia al tipo de usuario (rol).");
            entity.Property(e => e.IdtipoDocumento).HasComment("Referencia al tipo de documento de identidad.");
            entity.Property(e => e.Materno).HasComment("Apellido materno del usuario.");
            entity.Property(e => e.Nombre).HasComment("Nombres del usuario.");
            entity.Property(e => e.NumeroDocumento).HasComment("Número del documento de identidad del usuario.");
            entity.Property(e => e.Paterno).HasComment("Apellido paterno del usuario.");
            entity.Property(e => e.Telefono).HasComment("Teléfono de contacto del usuario.");

            entity.HasOne(d => d.IdTipoUsuarioNavigation).WithMany(p => p.TabUsuarios).HasConstraintName("fk_Usuario_TipoUsuario");

            entity.HasOne(d => d.IdtipoDocumentoNavigation).WithMany(p => p.TabUsuarios).HasConstraintName("fk_Usuario_TipoDocumento");
        });

        modelBuilder.Entity<VisUsuarios>(entity =>
        {
            entity.ToView("visUSUARIOS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
