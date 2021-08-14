﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prueba_Tecnica.Context;

namespace Prueba_Tecnica.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Prueba_Tecnica.Entidades.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TelefonoContacto")
                        .HasColumnType("int");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Prueba_Tecnica.Entidades.Pedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int?>("ClienteIdCliente")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaAprobacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEmision")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<int>("IdVendedor")
                        .HasColumnType("int");

                    b.Property<int>("IdVendedorAprobado")
                        .HasColumnType("int");

                    b.Property<int?>("ProductoIdProducto")
                        .HasColumnType("int");

                    b.Property<int?>("VendedorIdVendedor")
                        .HasColumnType("int");

                    b.HasKey("IdPedido");

                    b.HasIndex("ClienteIdCliente");

                    b.HasIndex("ProductoIdProducto");

                    b.HasIndex("VendedorIdVendedor");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Prueba_Tecnica.Entidades.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Existencia")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Provedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProducto");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Prueba_Tecnica.Entidades.Vendedor", b =>
                {
                    b.Property<int>("IdVendedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdVendedor");

                    b.ToTable("Vendedores");
                });

            modelBuilder.Entity("Prueba_Tecnica.Entidades.Pedido", b =>
                {
                    b.HasOne("Prueba_Tecnica.Entidades.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteIdCliente");

                    b.HasOne("Prueba_Tecnica.Entidades.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoIdProducto");

                    b.HasOne("Prueba_Tecnica.Entidades.Vendedor", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorIdVendedor");

                    b.Navigation("Cliente");

                    b.Navigation("Producto");

                    b.Navigation("Vendedor");
                });
#pragma warning restore 612, 618
        }
    }
}
