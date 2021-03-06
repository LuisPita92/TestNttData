// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ntt.data.test.luis.pita.Data;

namespace ntt.data.test.luis.pita.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220410190911_Migracion3")]
    partial class Migracion3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ntt.data.test.luis.pita.Models.ClienteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<int>("PersonaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId");

                    b.ToTable("tbCliente");
                });

            modelBuilder.Entity("ntt.data.test.luis.pita.Models.CuentaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TipoCuentaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("TipoCuentaId");

                    b.ToTable("tbCuenta");
                });

            modelBuilder.Entity("ntt.data.test.luis.pita.Models.MovimientoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CuentaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<double>("Saldo")
                        .HasColumnType("float");

                    b.Property<double>("SaldoInicial")
                        .HasColumnType("float");

                    b.Property<string>("TipoMovimiento")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CuentaId");

                    b.ToTable("tbMovimiento");
                });

            modelBuilder.Entity("ntt.data.test.luis.pita.Models.PersonaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("tbPersona");
                });

            modelBuilder.Entity("ntt.data.test.luis.pita.Models.TipoCuentaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbTipoCuenta");
                });

            modelBuilder.Entity("ntt.data.test.luis.pita.Models.ClienteModel", b =>
                {
                    b.HasOne("ntt.data.test.luis.pita.Models.PersonaModel", "Persona")
                        .WithMany()
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("ntt.data.test.luis.pita.Models.CuentaModel", b =>
                {
                    b.HasOne("ntt.data.test.luis.pita.Models.ClienteModel", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ntt.data.test.luis.pita.Models.TipoCuentaModel", "TipoCuenta")
                        .WithMany()
                        .HasForeignKey("TipoCuentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("TipoCuenta");
                });

            modelBuilder.Entity("ntt.data.test.luis.pita.Models.MovimientoModel", b =>
                {
                    b.HasOne("ntt.data.test.luis.pita.Models.CuentaModel", "Cuenta")
                        .WithMany()
                        .HasForeignKey("CuentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuenta");
                });
#pragma warning restore 612, 618
        }
    }
}
