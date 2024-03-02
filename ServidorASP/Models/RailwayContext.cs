using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ServidorASP.Models;

public partial class RailwayContext : DbContext
{
    public RailwayContext()
    {
    }

    public RailwayContext(DbContextOptions<RailwayContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Articulo> Articulos { get; set; }

    public virtual DbSet<ArticuloAutor> ArticuloAutors { get; set; }

    public virtual DbSet<ArticuloCategoria> ArticuloCategorias { get; set; }

    public virtual DbSet<AuthGroup> AuthGroups { get; set; }

    public virtual DbSet<AuthGroupPermission> AuthGroupPermissions { get; set; }

    public virtual DbSet<AuthPermission> AuthPermissions { get; set; }

    public virtual DbSet<AuthUser> AuthUsers { get; set; }

    public virtual DbSet<AuthUserGroup> AuthUserGroups { get; set; }

    public virtual DbSet<AuthUserUserPermission> AuthUserUserPermissions { get; set; }

    public virtual DbSet<Autore> Autores { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Cookie> Cookies { get; set; }

    public virtual DbSet<DjangoAdminLog> DjangoAdminLogs { get; set; }

    public virtual DbSet<DjangoContentType> DjangoContentTypes { get; set; }

    public virtual DbSet<DjangoMigration> DjangoMigrations { get; set; }

    public virtual DbSet<DjangoSession> DjangoSessions { get; set; }

    public virtual DbSet<DjangoSite> DjangoSites { get; set; }

    public virtual DbSet<EmailsEnviado> EmailsEnviados { get; set; }

    public virtual DbSet<EstadoArticulo> EstadoArticulos { get; set; }

    public virtual DbSet<Formulariocontacto> Formulariocontactos { get; set; }

    public virtual DbSet<IdentificadoresEmail> IdentificadoresEmails { get; set; }

    public virtual DbSet<InformacionJano> InformacionJanos { get; set; }

    public virtual DbSet<PortafolioCertificacione> PortafolioCertificaciones { get; set; }

    public virtual DbSet<PortafolioEmail> PortafolioEmails { get; set; }

    public virtual DbSet<PortafolioHabilidade> PortafolioHabilidades { get; set; }

    public virtual DbSet<PortafolioPortafolio> PortafolioPortafolios { get; set; }

    public virtual DbSet<PortafolioProyecto> PortafolioProyectos { get; set; }

    public virtual DbSet<Privacidad> Privacidads { get; set; }

    public virtual DbSet<RedesSocialesJano> RedesSocialesJanos { get; set; }

    public virtual DbSet<Termino> Terminos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Articulo_pkey");

            entity.ToTable("Articulo");

            entity.HasIndex(e => e.EstadoId, "Articulo_estado_id_4111e7ae");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Compartidos).HasColumnName("compartidos");
            entity.Property(e => e.Contenido).HasColumnName("contenido");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(360)
                .HasColumnName("descripcion");
            entity.Property(e => e.DescripcionImagen)
                .HasMaxLength(150)
                .HasColumnName("descripcion_imagen");
            entity.Property(e => e.EstadoId).HasColumnName("estado_id");
            entity.Property(e => e.FechaHoraCreacion).HasColumnName("fecha_hora_creacion");
            entity.Property(e => e.Image)
                .HasMaxLength(100)
                .HasColumnName("image");
            entity.Property(e => e.Likes).HasColumnName("likes");
            entity.Property(e => e.Prioridad).HasColumnName("prioridad");
            entity.Property(e => e.Tags)
                .HasMaxLength(400)
                .HasColumnName("tags");
            entity.Property(e => e.Titulo)
                .HasMaxLength(150)
                .HasColumnName("titulo");
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .HasColumnName("url");
            entity.Property(e => e.Visitas).HasColumnName("visitas");

            entity.HasOne(d => d.Estado).WithMany(p => p.Articulos)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("Articulo_estado_id_4111e7ae_fk_EstadoArticulos_id");
        });

        modelBuilder.Entity<ArticuloAutor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Articulo_autor_pkey");

            entity.ToTable("Articulo_autor");

            entity.HasIndex(e => e.ArticuloId, "Articulo_autor_articulo_id_aba1e477");

            entity.HasIndex(e => new { e.ArticuloId, e.AutoresId }, "Articulo_autor_articulo_id_autores_id_8bcef307_uniq").IsUnique();

            entity.HasIndex(e => e.AutoresId, "Articulo_autor_autores_id_e04963bc");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ArticuloId).HasColumnName("articulo_id");
            entity.Property(e => e.AutoresId).HasColumnName("autores_id");

            entity.HasOne(d => d.Articulo).WithMany(p => p.ArticuloAutors)
                .HasForeignKey(d => d.ArticuloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Articulo_autor_articulo_id_aba1e477_fk_Articulo_id");

            entity.HasOne(d => d.Autores).WithMany(p => p.ArticuloAutors)
                .HasForeignKey(d => d.AutoresId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Articulo_autor_autores_id_e04963bc_fk_Autores_id");
        });

        modelBuilder.Entity<ArticuloCategoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Articulo_categorias_pkey");

            entity.ToTable("Articulo_categorias");

            entity.HasIndex(e => e.ArticuloId, "Articulo_categorias_articulo_id_b6b4b836");

            entity.HasIndex(e => new { e.ArticuloId, e.CategoriaId }, "Articulo_categorias_articulo_id_categoria_id_59ec9e49_uniq").IsUnique();

            entity.HasIndex(e => e.CategoriaId, "Articulo_categorias_categoria_id_bbe6ef55");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ArticuloId).HasColumnName("articulo_id");
            entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");

            entity.HasOne(d => d.Articulo).WithMany(p => p.ArticuloCategoria)
                .HasForeignKey(d => d.ArticuloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Articulo_categorias_articulo_id_b6b4b836_fk_Articulo_id");

            entity.HasOne(d => d.Categoria).WithMany(p => p.ArticuloCategoria)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Articulo_categorias_categoria_id_bbe6ef55_fk_Categoria_id");
        });

        modelBuilder.Entity<AuthGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("auth_group_pkey");

            entity.ToTable("auth_group");

            entity.HasIndex(e => e.Name, "auth_group_name_a6ea08ec_like").HasOperators(new[] { "varchar_pattern_ops" });

            entity.HasIndex(e => e.Name, "auth_group_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
        });

        modelBuilder.Entity<AuthGroupPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("auth_group_permissions_pkey");

            entity.ToTable("auth_group_permissions");

            entity.HasIndex(e => e.GroupId, "auth_group_permissions_group_id_b120cbf9");

            entity.HasIndex(e => new { e.GroupId, e.PermissionId }, "auth_group_permissions_group_id_permission_id_0cd325b0_uniq").IsUnique();

            entity.HasIndex(e => e.PermissionId, "auth_group_permissions_permission_id_84c5c92e");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.PermissionId).HasColumnName("permission_id");

            entity.HasOne(d => d.Group).WithMany(p => p.AuthGroupPermissions)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_group_permissions_group_id_b120cbf9_fk_auth_group_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.AuthGroupPermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_group_permissio_permission_id_84c5c92e_fk_auth_perm");
        });

        modelBuilder.Entity<AuthPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("auth_permission_pkey");

            entity.ToTable("auth_permission");

            entity.HasIndex(e => e.ContentTypeId, "auth_permission_content_type_id_2f476e4b");

            entity.HasIndex(e => new { e.ContentTypeId, e.Codename }, "auth_permission_content_type_id_codename_01ab375a_uniq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codename)
                .HasMaxLength(100)
                .HasColumnName("codename");
            entity.Property(e => e.ContentTypeId).HasColumnName("content_type_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.HasOne(d => d.ContentType).WithMany(p => p.AuthPermissions)
                .HasForeignKey(d => d.ContentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_permission_content_type_id_2f476e4b_fk_django_co");
        });

        modelBuilder.Entity<AuthUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("auth_user_pkey");

            entity.ToTable("auth_user");

            entity.HasIndex(e => e.Username, "auth_user_username_6821ab7c_like").HasOperators(new[] { "varchar_pattern_ops" });

            entity.HasIndex(e => e.Username, "auth_user_username_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateJoined).HasColumnName("date_joined");
            entity.Property(e => e.Email)
                .HasMaxLength(254)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(150)
                .HasColumnName("first_name");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsStaff).HasColumnName("is_staff");
            entity.Property(e => e.IsSuperuser).HasColumnName("is_superuser");
            entity.Property(e => e.LastLogin).HasColumnName("last_login");
            entity.Property(e => e.LastName)
                .HasMaxLength(150)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(128)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(150)
                .HasColumnName("username");
        });

        modelBuilder.Entity<AuthUserGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("auth_user_groups_pkey");

            entity.ToTable("auth_user_groups");

            entity.HasIndex(e => e.GroupId, "auth_user_groups_group_id_97559544");

            entity.HasIndex(e => e.UserId, "auth_user_groups_user_id_6a12ed8b");

            entity.HasIndex(e => new { e.UserId, e.GroupId }, "auth_user_groups_user_id_group_id_94350c0c_uniq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Group).WithMany(p => p.AuthUserGroups)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_groups_group_id_97559544_fk_auth_group_id");

            entity.HasOne(d => d.User).WithMany(p => p.AuthUserGroups)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_groups_user_id_6a12ed8b_fk_auth_user_id");
        });

        modelBuilder.Entity<AuthUserUserPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("auth_user_user_permissions_pkey");

            entity.ToTable("auth_user_user_permissions");

            entity.HasIndex(e => e.PermissionId, "auth_user_user_permissions_permission_id_1fbb5f2c");

            entity.HasIndex(e => e.UserId, "auth_user_user_permissions_user_id_a95ead1b");

            entity.HasIndex(e => new { e.UserId, e.PermissionId }, "auth_user_user_permissions_user_id_permission_id_14a6b632_uniq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PermissionId).HasColumnName("permission_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.AuthUserUserPermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_user_permi_permission_id_1fbb5f2c_fk_auth_perm");

            entity.HasOne(d => d.User).WithMany(p => p.AuthUserUserPermissions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_user_permissions_user_id_a95ead1b_fk_auth_user_id");
        });

        modelBuilder.Entity<Autore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Autores_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NombreAutor)
                .HasMaxLength(50)
                .HasColumnName("nombre_autor");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Categoria_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Cookie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Cookies_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contenido).HasColumnName("contenido");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.NombreDeUsuario)
                .HasMaxLength(25)
                .HasColumnName("nombre_de_usuario");
            entity.Property(e => e.NombrePropietario)
                .HasMaxLength(40)
                .HasColumnName("nombre_propietario");
            entity.Property(e => e.UltimaActualizacion).HasColumnName("ultima_actualizacion");
        });

        modelBuilder.Entity<DjangoAdminLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("django_admin_log_pkey");

            entity.ToTable("django_admin_log");

            entity.HasIndex(e => e.ContentTypeId, "django_admin_log_content_type_id_c4bce8eb");

            entity.HasIndex(e => e.UserId, "django_admin_log_user_id_c564eba6");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionFlag).HasColumnName("action_flag");
            entity.Property(e => e.ActionTime).HasColumnName("action_time");
            entity.Property(e => e.ChangeMessage).HasColumnName("change_message");
            entity.Property(e => e.ContentTypeId).HasColumnName("content_type_id");
            entity.Property(e => e.ObjectId).HasColumnName("object_id");
            entity.Property(e => e.ObjectRepr)
                .HasMaxLength(200)
                .HasColumnName("object_repr");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.ContentType).WithMany(p => p.DjangoAdminLogs)
                .HasForeignKey(d => d.ContentTypeId)
                .HasConstraintName("django_admin_log_content_type_id_c4bce8eb_fk_django_co");

            entity.HasOne(d => d.User).WithMany(p => p.DjangoAdminLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("django_admin_log_user_id_c564eba6_fk_auth_user_id");
        });

        modelBuilder.Entity<DjangoContentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("django_content_type_pkey");

            entity.ToTable("django_content_type");

            entity.HasIndex(e => new { e.AppLabel, e.Model }, "django_content_type_app_label_model_76bd3d3b_uniq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AppLabel)
                .HasMaxLength(100)
                .HasColumnName("app_label");
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .HasColumnName("model");
        });

        modelBuilder.Entity<DjangoMigration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("django_migrations_pkey");

            entity.ToTable("django_migrations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.App)
                .HasMaxLength(255)
                .HasColumnName("app");
            entity.Property(e => e.Applied).HasColumnName("applied");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DjangoSession>(entity =>
        {
            entity.HasKey(e => e.SessionKey).HasName("django_session_pkey");

            entity.ToTable("django_session");

            entity.HasIndex(e => e.ExpireDate, "django_session_expire_date_a5c62663");

            entity.HasIndex(e => e.SessionKey, "django_session_session_key_c0390e0f_like").HasOperators(new[] { "varchar_pattern_ops" });

            entity.Property(e => e.SessionKey)
                .HasMaxLength(40)
                .HasColumnName("session_key");
            entity.Property(e => e.ExpireDate).HasColumnName("expire_date");
            entity.Property(e => e.SessionData).HasColumnName("session_data");
        });

        modelBuilder.Entity<DjangoSite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("django_site_pkey");

            entity.ToTable("django_site");

            entity.HasIndex(e => e.Domain, "django_site_domain_a2e37b91_like").HasOperators(new[] { "varchar_pattern_ops" });

            entity.HasIndex(e => e.Domain, "django_site_domain_a2e37b91_uniq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Domain)
                .HasMaxLength(100)
                .HasColumnName("domain");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<EmailsEnviado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("EmailsEnviados_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Body)
                .HasMaxLength(4000)
                .HasColumnName("_body");
            entity.Property(e => e.Datetime).HasColumnName("_datetime");
            entity.Property(e => e.From)
                .HasMaxLength(60)
                .HasColumnName("_from");
            entity.Property(e => e.Subject)
                .HasMaxLength(100)
                .HasColumnName("_subject");
            entity.Property(e => e.To)
                .HasMaxLength(100)
                .HasColumnName("_to");
        });

        modelBuilder.Entity<EstadoArticulo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("EstadoArticulos_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
        });

        modelBuilder.Entity<Formulariocontacto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("formulariocontacto_pkey");

            entity.ToTable("formulariocontacto");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Correo)
                .HasMaxLength(40)
                .HasColumnName("correo");
            entity.Property(e => e.EsSpam).HasColumnName("es_spam");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Mensaje)
                .HasMaxLength(4000)
                .HasColumnName("mensaje");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .HasColumnName("nombre");
            entity.Property(e => e.Terminos).HasColumnName("terminos");
        });

        modelBuilder.Entity<IdentificadoresEmail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("IdentificadoresEmails_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Identificador)
                .HasMaxLength(40)
                .HasColumnName("identificador");
        });

        modelBuilder.Entity<InformacionJano>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("InformacionJano_pkey");

            entity.ToTable("InformacionJano");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Frase)
                .HasMaxLength(150)
                .HasColumnName("frase");
            entity.Property(e => e.Icono)
                .HasMaxLength(100)
                .HasColumnName("icono");
            entity.Property(e => e.Imagen)
                .HasMaxLength(100)
                .HasColumnName("imagen");
            entity.Property(e => e.Portada)
                .HasMaxLength(100)
                .HasColumnName("portada");
            entity.Property(e => e.Texto).HasColumnName("texto");
            entity.Property(e => e.UltimaActualizacion).HasColumnName("ultima_actualizacion");
        });

        modelBuilder.Entity<PortafolioCertificacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Portafolio_certificaciones_pkey");

            entity.ToTable("Portafolio_certificaciones");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(230)
                .HasColumnName("descripcion");
            entity.Property(e => e.Enlace)
                .HasMaxLength(255)
                .HasColumnName("enlace");
            entity.Property(e => e.Imagen)
                .HasMaxLength(100)
                .HasColumnName("imagen");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<PortafolioEmail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Portafolio_emails_pkey");

            entity.ToTable("Portafolio_emails");

            entity.HasIndex(e => e.EmailAddress, "Portafolio_emails_email_address_7ac91e72_like").HasOperators(new[] { "varchar_pattern_ops" });

            entity.HasIndex(e => e.EmailAddress, "Portafolio_emails_email_address_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(60)
                .HasColumnName("email_address");
            entity.Property(e => e.SubscribeToNewsletter).HasColumnName("subscribe_to_newsletter");
        });

        modelBuilder.Entity<PortafolioHabilidade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Portafolio_habilidades_pkey");

            entity.ToTable("Portafolio_habilidades");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DescHabilidad)
                .HasMaxLength(100)
                .HasColumnName("descHabilidad");
        });

        modelBuilder.Entity<PortafolioPortafolio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Portafolio_portafolio_pkey");

            entity.ToTable("Portafolio_portafolio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Imagen)
                .HasMaxLength(100)
                .HasColumnName("imagen");
            entity.Property(e => e.TextoLargo).HasColumnName("texto_largo");
        });

        modelBuilder.Entity<PortafolioProyecto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Portafolio_proyectos_pkey");

            entity.ToTable("Portafolio_proyectos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AltImagen)
                .HasMaxLength(50)
                .HasColumnName("alt_imagen");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(230)
                .HasColumnName("descripcion");
            entity.Property(e => e.Enlace)
                .HasMaxLength(255)
                .HasColumnName("enlace");
            entity.Property(e => e.Imagen)
                .HasMaxLength(100)
                .HasColumnName("imagen");
            entity.Property(e => e.TextoEnlace)
                .HasMaxLength(50)
                .HasColumnName("texto_enlace");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<Privacidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Privacidad_pkey");

            entity.ToTable("Privacidad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contenido).HasColumnName("contenido");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.NombreDeUsuario)
                .HasMaxLength(25)
                .HasColumnName("nombre_de_usuario");
            entity.Property(e => e.NombrePropietario)
                .HasMaxLength(40)
                .HasColumnName("nombre_propietario");
            entity.Property(e => e.UltimaActualizacion).HasColumnName("ultima_actualizacion");
        });

        modelBuilder.Entity<RedesSocialesJano>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("RedesSocialesJano_pkey");

            entity.ToTable("RedesSocialesJano");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EnlaceRedSocial)
                .HasMaxLength(75)
                .HasColumnName("enlace_red_social");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IconoRedSocial)
                .HasMaxLength(100)
                .HasColumnName("icono_red_social");
            entity.Property(e => e.ImagenFondoRedSocial)
                .HasMaxLength(100)
                .HasColumnName("imagen_fondo_red_social");
            entity.Property(e => e.NombreRedSocial)
                .HasMaxLength(50)
                .HasColumnName("nombre_red_social");
        });

        modelBuilder.Entity<Termino>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Terminos_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contenido).HasColumnName("contenido");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.NombreDeUsuario)
                .HasMaxLength(25)
                .HasColumnName("nombre_de_usuario");
            entity.Property(e => e.NombrePropietario)
                .HasMaxLength(40)
                .HasColumnName("nombre_propietario");
            entity.Property(e => e.UltimaActualizacion).HasColumnName("ultima_actualizacion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
