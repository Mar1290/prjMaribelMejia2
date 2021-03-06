// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using prjMaribelMejia.Data;

namespace prjMaribelMejia.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220303002231_tbMarcas2")]
    partial class tbMarcas2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("prjMaribelMejia.Models.Categorias", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("DescripcionCategoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacionCategoria")
                        .HasColumnType("datetime2");

                    b.HasKey("IdCategoria");

                    b.ToTable("categorias");
                });

            modelBuilder.Entity("prjMaribelMejia.Models.Marcas", b =>
                {
                    b.Property<int>("IdMarca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaCreacionMarca")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreMarca")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("UsuarioRegistraMarca")
                        .HasColumnType("int");

                    b.HasKey("IdMarca");

                    b.ToTable("marcas");
                });

            modelBuilder.Entity("prjMaribelMejia.Models.Modulos", b =>
                {
                    b.Property<int>("IdModulo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaCreacionModulo")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPropietario")
                        .HasColumnType("int");

                    b.Property<string>("Modulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("IdModulo");

                    b.HasIndex("IdPropietario");

                    b.ToTable("modulos");
                });

            modelBuilder.Entity("prjMaribelMejia.Models.Productos", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("FechaCreacionProducto")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Producto")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdProducto");

                    b.HasIndex("IdCategoria");

                    b.ToTable("producto");
                });

            modelBuilder.Entity("prjMaribelMejia.Models.Propietarios", b =>
                {
                    b.Property<int>("IdPropietario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DireccionPropietario")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("IdentificacionPropietario")
                        .IsRequired()
                        .HasColumnType("nvarchar(14)")
                        .HasMaxLength(14);

                    b.Property<string>("NombrePropietario")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("PropietarioActivo")
                        .HasColumnType("bit");

                    b.Property<string>("TelefonoPropietario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPropietario");

                    b.ToTable("propietarios");
                });

            modelBuilder.Entity("prjMaribelMejia.Models.Modulos", b =>
                {
                    b.HasOne("prjMaribelMejia.Models.Propietarios", "Propietarios")
                        .WithMany()
                        .HasForeignKey("IdPropietario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("prjMaribelMejia.Models.Productos", b =>
                {
                    b.HasOne("prjMaribelMejia.Models.Categorias", "Categorias")
                        .WithMany()
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
