using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GestaoLogistica.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Deposito> Depositos { get; set; }
        public virtual DbSet<Entrega> Entregas { get; set; }
        public virtual DbSet<Mercadoria> Mercadorias { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<Permissao> Permissoes { get; set; }
        public virtual DbSet<Permissoesperfil> Permissoesperfil { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;uid=root;pwd=sabino477401;database=gsl");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deposito>(entity =>
            {
                entity.HasKey(e => e.IdDeposito)
                    .HasName("PRIMARY");

                entity.ToTable("depositos");

                entity.Property(e => e.IdDeposito)
                    .HasColumnName("iddeposito")
                    .HasMaxLength(36);

                entity.Property(e => e.Ativo)
                    .HasColumnName("ativo")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(255);

                entity.Property(e => e.Endereco)
                    .HasColumnName("endereco")
                    .HasMaxLength(255);

                entity.Property(e => e.Imagem)
                    .HasColumnName("imagem")
                    .HasMaxLength(255);

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("double");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("double");
            });

            modelBuilder.Entity<Entrega>(entity =>
            {
                entity.HasKey(e => e.IdEntrega)
                    .HasName("PRIMARY");

                entity.ToTable("entregas");

                entity.HasIndex(e => e.IdDeposito)
                    .HasName("fkdeposito_idx");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fkusuario_idx");

                entity.Property(e => e.IdEntrega)
                    .HasColumnName("identrega")
                    .HasMaxLength(36);

                entity.Property(e => e.Endereco)
                    .HasColumnName("endereco")
                    .HasMaxLength(255);

                entity.Property(e => e.IdDeposito)
                    .HasColumnName("idDeposito")
                    .HasMaxLength(36);

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasMaxLength(36);

                entity.Property(e => e.Imagem)
                    .HasColumnName("imagem")
                    .HasMaxLength(255);

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("double");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("double");

                entity.Property(e => e.Situacao)
                    .HasColumnName("situacao")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdDepositoNavigation)
                    .WithMany(p => p.Entregas)
                    .HasForeignKey(d => d.IdDeposito)
                    .HasConstraintName("fkdeposito");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Entregas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fkusuario");
            });

            modelBuilder.Entity<Mercadoria>(entity =>
            {
                entity.HasKey(e => e.IdMercadoria)
                    .HasName("PRIMARY");

                entity.ToTable("mercadorias");

                entity.Property(e => e.IdMercadoria)
                    .HasColumnName("idmercadorias")
                    .HasMaxLength(36);

                entity.Property(e => e.Estoque)
                    .HasColumnName("estoque")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Imagem)
                    .HasColumnName("imagem")
                    .HasMaxLength(250);

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(100);

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(e => e.IdPerfil)
                    .HasName("PRIMARY");

                entity.ToTable("perfil");

                entity.Property(e => e.IdPerfil)
                    .HasColumnName("idperfil")
                    .HasMaxLength(36);

                entity.Property(e => e.Ativo)
                    .HasColumnName("ativo")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Permissao>(entity =>
            {
                entity.HasKey(e => e.Idpermissao)
                    .HasName("PRIMARY");

                entity.ToTable("permissoes");

                entity.Property(e => e.Idpermissao)
                    .HasColumnName("idpermissao")
                    .HasMaxLength(36);

                entity.Property(e => e.Deletar)
                    .HasColumnName("deletar")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Editar)
                    .HasColumnName("editar")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Incluir)
                    .HasColumnName("incluir")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Ler)
                    .HasColumnName("ler")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Modulo)
                    .HasColumnName("modulo")
                    .HasMaxLength(100);

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Permissoesperfil>(entity =>
            {
                entity.HasKey(e => e.IdPermissoesPerfil)
                    .HasName("PRIMARY");

                entity.ToTable("permissoesperfil");

                entity.HasIndex(e => e.IdPerfil)
                    .HasName("fkperfil_idx");

                entity.HasIndex(e => e.IdPermissao)
                    .HasName("fkpermissao_idx");

                entity.Property(e => e.IdPermissoesPerfil)
                    .HasColumnName("idPermissoesPerfil")
                    .HasMaxLength(36);

                entity.Property(e => e.IdPerfil)
                    .IsRequired()
                    .HasColumnName("idPerfil")
                    .HasMaxLength(36);

                entity.Property(e => e.IdPermissao)
                    .IsRequired()
                    .HasColumnName("idPermissao")
                    .HasMaxLength(36);

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Permissoesperfil)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkperfil");

                entity.HasOne(d => d.IdPermissaoNavigation)
                    .WithMany(p => p.Permissoesperfil)
                    .HasForeignKey(d => d.IdPermissao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkpermissao");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.IdPerfil)
                    .HasName("fkperfil_idx");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idusuarios")
                    .HasMaxLength(36);

                entity.Property(e => e.Ativo)
                    .HasColumnName("ativo")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(250);

                entity.Property(e => e.IdPerfil)
                    .HasColumnName("idPerfil")
                    .HasMaxLength(36);

                entity.Property(e => e.Login)
                    .HasColumnName("login")
                    .HasMaxLength(80);

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(100);

                entity.Property(e => e.Senha)
                    .HasColumnName("senha")
                    .HasMaxLength(80);

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPerfil)
                    .HasConstraintName("fk_userperfil");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
