using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VerbsAPI.Context;

public partial class EnglishContext : DbContext
{
    public EnglishContext()
    {
    }

    public EnglishContext(DbContextOptions<EnglishContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aprendizaje> Aprendizajes { get; set; }

    public virtual DbSet<Audio> Audios { get; set; }

    public virtual DbSet<Imagene> Imagenes { get; set; }

    public virtual DbSet<Ruta> Rutas { get; set; }

    public virtual DbSet<TiemposVerbale> TiemposVerbales { get; set; }

    public virtual DbSet<Traduccione> Traducciones { get; set; }

    public virtual DbSet<TraduccionesVerb> TraduccionesVerbs { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Verb> Verbs { get; set; }

    public virtual DbSet<VerbsTiempo> VerbsTiempos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Aprendizaje>(entity =>
        {
            entity.HasKey(e => e.CveAprendizaje).HasName("PRIMARY");

            entity.ToTable("aprendizaje");

            entity.HasIndex(e => e.CveVerbs, "FK__verbs");

            entity.HasIndex(e => e.CveUsuarios, "FK_aprendizaje_usuarios");

            entity.Property(e => e.CveAprendizaje)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("cve_aprendizaje");
            entity.Property(e => e.CveUsuarios)
                .HasColumnType("int(11)")
                .HasColumnName("cve_usuarios");
            entity.Property(e => e.CveVerbs)
                .HasColumnType("int(11)")
                .HasColumnName("cve_verbs");
        });

        modelBuilder.Entity<Audio>(entity =>
        {
            entity.HasKey(e => e.CveAudios).HasName("PRIMARY");

            entity.ToTable("audios");

            entity.Property(e => e.CveAudios)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("cve_audios");
            entity.Property(e => e.Audio1)
                .HasColumnType("blob")
                .HasColumnName("audio");
        });

        modelBuilder.Entity<Imagene>(entity =>
        {
            entity.HasKey(e => e.CveImagenes).HasName("PRIMARY");

            entity.ToTable("imagenes");

            entity.Property(e => e.CveImagenes)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("cve_imagenes");
            entity.Property(e => e.Imagen)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("imagen");
        });

        modelBuilder.Entity<Ruta>(entity =>
        {
            entity.HasKey(e => e.CveRutas).HasName("PRIMARY");

            entity.ToTable("rutas");

            entity.Property(e => e.CveRutas)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("cve_rutas");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TiemposVerbale>(entity =>
        {
            entity.HasKey(e => e.CveTiemposVerbales).HasName("PRIMARY");

            entity.ToTable("tiempos_verbales");

            entity.Property(e => e.CveTiemposVerbales)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("cve_tiempos_verbales");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Traduccione>(entity =>
        {
            entity.HasKey(e => e.CveTraducciones).HasName("PRIMARY");

            entity.ToTable("traducciones");

            entity.HasIndex(e => e.CveImagenes, "FK__imagenes");

            entity.Property(e => e.CveTraducciones)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("cve_traducciones");
            entity.Property(e => e.CveImagenes)
                .HasColumnType("int(11)")
                .HasColumnName("cve_imagenes");
            entity.Property(e => e.Traduccion)
                .HasMaxLength(50)
                .HasColumnName("traduccion");
        });

        modelBuilder.Entity<TraduccionesVerb>(entity =>
        {
            entity.HasKey(e => e.CveTraduccionesVerbs).HasName("PRIMARY");

            entity.ToTable("traducciones_verbs");

            entity.HasIndex(e => e.CveTraducciones, "FK__traducciones");

            entity.Property(e => e.CveTraduccionesVerbs)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("cve_traducciones_verbs");
            entity.Property(e => e.CveTraducciones)
                .HasColumnType("int(11)")
                .HasColumnName("cve_traducciones");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.CveUsuarios).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.Property(e => e.CveUsuarios)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("cve_usuarios");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(100)
                .HasColumnName("contraseña");
            entity.Property(e => e.Correo)
                .HasMaxLength(120)
                .HasColumnName("correo");
        });

        modelBuilder.Entity<Verb>(entity =>
        {
            entity.HasKey(e => e.CveVerbs).HasName("PRIMARY");

            entity.ToTable("verbs");

            entity.HasIndex(e => e.CveAudios, "FK__audios");

            entity.HasIndex(e => e.CveTraduccionesVerbs, "FK_verbs_traducciones_verbs");

            entity.Property(e => e.CveVerbs)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("cve_verbs");
            entity.Property(e => e.Aprendido)
                .HasColumnType("bit(1)")
                .HasColumnName("aprendido");
            entity.Property(e => e.CveAudios)
                .HasColumnType("int(11)")
                .HasColumnName("cve_audios");
            entity.Property(e => e.CveTraduccionesVerbs)
                .HasColumnType("int(11)")
                .HasColumnName("cve_traducciones_verbs");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");
            entity.Property(e => e.PhrasalWeb)
                .HasColumnType("bit(1)")
                .HasColumnName("phrasal_web");
            entity.Property(e => e.Regular)
                .HasColumnType("bit(1)")
                .HasColumnName("regular");
        });

        modelBuilder.Entity<VerbsTiempo>(entity =>
        {
            entity.HasKey(e => e.CveVerbsTiempos).HasName("PRIMARY");

            entity.ToTable("verbs_tiempos");

            entity.HasIndex(e => e.CveTiemposVerbales, "FK__tiempos_verbales");

            entity.HasIndex(e => e.CveVerbs, "FK__verbs");

            entity.Property(e => e.CveVerbsTiempos)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("cve_verbs_tiempos");
            entity.Property(e => e.CveTiemposVerbales)
                .HasColumnType("int(11)")
                .HasColumnName("cve_tiempos_verbales");
            entity.Property(e => e.CveVerbs)
                .HasColumnType("int(11)")
                .HasColumnName("cve_verbs");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
