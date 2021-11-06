using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using dwc.Models;

#nullable disable

namespace dwc.Data
{
    public partial class FARMACIASContext : DbContext
    {
        public FARMACIASContext()
        {
        }

        public FARMACIASContext(DbContextOptions<FARMACIASContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Factperiodo> Factperiodos { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Farmacia> Farmacias { get; set; }
        public virtual DbSet<Laboratorio> Laboratorios { get; set; }
        public virtual DbSet<Medfamilia> Medfamilias { get; set; }
        public virtual DbSet<Medicamento> Medicamentos { get; set; }
        public virtual DbSet<Pedestado> Pedestados { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Pedlinea> Pedlineas { get; set; }
        public virtual DbSet<Precio> Precios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:Farmacias");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Factperiodo>(entity =>
            {
                entity.HasKey(e => e.Idperiodo)
                    .HasName("PK__FACTPERI__A7A0134934467F7E");

                entity.ToTable("FACTPERIODO");

                entity.Property(e => e.Idperiodo)
                    .ValueGeneratedNever()
                    .HasColumnName("IDPERIODO");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.Idfactura)
                    .HasName("PK__FACTURAS__F7D4C9C7F06FAF9D");

                entity.ToTable("FACTURAS");

                entity.Property(e => e.Idfactura)
                    .ValueGeneratedNever()
                    .HasColumnName("IDFACTURA");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("FECHA")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Idfarmacia)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("IDFARMACIA");

                entity.Property(e => e.Total)
                    .HasColumnType("money")
                    .HasColumnName("TOTAL");

                entity.HasOne(d => d.IdfarmaciaNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.Idfarmacia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FACTURAS__IDFARM__45F365D3");
            });

            modelBuilder.Entity<Farmacia>(entity =>
            {
                entity.HasKey(e => e.Idfarmacia)
                    .HasName("PK__FARMACIA__A087BF494E0FB409");

                entity.ToTable("FARMACIAS");

                entity.Property(e => e.Idfarmacia)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("IDFARMACIA");

                entity.Property(e => e.Idperiodo).HasColumnName("IDPERIODO");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Poblacion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("POBLACION");

                entity.Property(e => e.Ultfactura)
                    .HasColumnType("date")
                    .HasColumnName("ULTFACTURA");

                entity.HasOne(d => d.IdperiodoNavigation)
                    .WithMany(p => p.Farmacia)
                    .HasForeignKey(d => d.Idperiodo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FARMACIAS__IDPER__267ABA7A");
            });

            modelBuilder.Entity<Laboratorio>(entity =>
            {
                entity.HasKey(e => e.Idlaboratorio)
                    .HasName("PK__LABORATO__85331BE96B9AD926");

                entity.ToTable("LABORATORIOS");

                entity.Property(e => e.Idlaboratorio)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("IDLABORATORIO");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<Medfamilia>(entity =>
            {
                entity.HasKey(e => e.Idfamilia)
                    .HasName("PK__MEDFAMIL__8A44F9938E3CA4A7");

                entity.ToTable("MEDFAMILIAS");

                entity.Property(e => e.Idfamilia)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("IDFAMILIA");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");
            });

            modelBuilder.Entity<Medicamento>(entity =>
            {
                entity.HasKey(e => e.Idmedicamento)
                    .HasName("PK__MEDICAME__6A5231A3CD91E90F");

                entity.ToTable("MEDICAMENTOS");

                entity.Property(e => e.Idmedicamento)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("IDMEDICAMENTO");

                entity.Property(e => e.Generico)
                    .HasColumnName("GENERICO")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Idfamilia)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("IDFAMILIA");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Posoligia)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("POSOLIGIA");

                entity.Property(e => e.Prescripcion)
                    .HasColumnType("text")
                    .HasColumnName("PRESCRIPCION");

                entity.HasOne(d => d.IdfamiliaNavigation)
                    .WithMany(p => p.Medicamentos)
                    .HasForeignKey(d => d.Idfamilia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MEDICAMEN__IDFAM__35BCFE0A");
            });

            modelBuilder.Entity<Pedestado>(entity =>
            {
                entity.HasKey(e => e.Idestado)
                    .HasName("PK__PEDESTAD__A93E12E2B6A28119");

                entity.ToTable("PEDESTADOS");

                entity.Property(e => e.Idestado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("IDESTADO");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.Idpedido)
                    .HasName("PK__PEDIDOS__769F9E4EA25AB915");

                entity.ToTable("PEDIDOS");

                entity.Property(e => e.Idpedido)
                    .ValueGeneratedNever()
                    .HasColumnName("IDPEDIDO");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("FECHA")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Idestado)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("IDESTADO")
                    .HasDefaultValueSql("('RE')");

                entity.Property(e => e.Idfactura).HasColumnName("IDFACTURA");

                entity.Property(e => e.Idfarmacia)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("IDFARMACIA");

                entity.Property(e => e.Total)
                    .HasColumnType("money")
                    .HasColumnName("TOTAL");

                entity.HasOne(d => d.IdestadoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.Idestado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PEDIDOS__IDESTAD__2E1BDC42");

                entity.HasOne(d => d.IdfarmaciaNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.Idfarmacia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PEDIDOS__IDFARMA__2C3393D0");
            });

            modelBuilder.Entity<Pedlinea>(entity =>
            {
                entity.HasKey(e => new { e.Idpedido, e.Idmedicamento, e.Idlaboratorio })
                    .HasName("PK__PEDLINEA__B8BF8E4FA3D8A36C");

                entity.ToTable("PEDLINEAS");

                entity.Property(e => e.Idpedido).HasColumnName("IDPEDIDO");

                entity.Property(e => e.Idmedicamento)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("IDMEDICAMENTO");

                entity.Property(e => e.Idlaboratorio)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("IDLABORATORIO");

                entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

                entity.Property(e => e.Precio)
                    .HasColumnType("money")
                    .HasColumnName("PRECIO");

                entity.HasOne(d => d.IdlaboratorioNavigation)
                    .WithMany(p => p.Pedlineas)
                    .HasForeignKey(d => d.Idlaboratorio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PEDLINEAS__IDLAB__4222D4EF");

                entity.HasOne(d => d.IdmedicamentoNavigation)
                    .WithMany(p => p.Pedlineas)
                    .HasForeignKey(d => d.Idmedicamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PEDLINEAS__IDMED__412EB0B6");

                entity.HasOne(d => d.IdpedidoNavigation)
                    .WithMany(p => p.Pedlineas)
                    .HasForeignKey(d => d.Idpedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PEDLINEAS__IDPED__403A8C7D");
            });

            modelBuilder.Entity<Precio>(entity =>
            {
                entity.HasKey(e => new { e.Idmedicamento, e.Idlaboratorio })
                    .HasName("PK__PRECIOS__E201001D3C7694D6");

                entity.ToTable("PRECIOS");

                entity.Property(e => e.Idmedicamento)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("IDMEDICAMENTO");

                entity.Property(e => e.Idlaboratorio)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("IDLABORATORIO");

                entity.Property(e => e.Coste)
                    .HasColumnType("money")
                    .HasColumnName("COSTE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Precio1)
                    .HasColumnType("money")
                    .HasColumnName("PRECIO")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdlaboratorioNavigation)
                    .WithMany(p => p.Precios)
                    .HasForeignKey(d => d.Idlaboratorio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PRECIOS__IDLABOR__3A81B327");

                entity.HasOne(d => d.IdmedicamentoNavigation)
                    .WithMany(p => p.Precios)
                    .HasForeignKey(d => d.Idmedicamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PRECIOS__IDMEDIC__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
