﻿// <auto-generated />
using System;
using InventariosApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InventariosApi.Migrations
{
    [DbContext(typeof(InventariosDbContext))]
    [Migration("20221129043923_test")]
    partial class test
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EquiposDefectadosLabores", b =>
                {
                    b.Property<int>("EquiposDefectadosId")
                        .HasColumnType("int");

                    b.Property<int>("LaboresId")
                        .HasColumnType("int");

                    b.HasKey("EquiposDefectadosId", "LaboresId");

                    b.HasIndex("LaboresId");

                    b.ToTable("EquiposDefectadosLabores");
                });

            modelBuilder.Entity("InventariosApi.Entidades.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NombreArea")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Area");
                });

            modelBuilder.Entity("InventariosApi.Entidades.Componente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EquiposId")
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Serie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EquiposId");

                    b.ToTable("Componentes");
                });

            modelBuilder.Entity("InventariosApi.Entidades.Defectacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NombreDefectacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Defectaciones");
                });

            modelBuilder.Entity("InventariosApi.Entidades.Equipos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<float>("Depreciacion")
                        .HasColumnType("real");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<long>("Inventario")
                        .HasColumnType("bigint");

                    b.Property<long>("Sello")
                        .HasColumnType("bigint");

                    b.Property<int>("SucursalId")
                        .HasColumnType("int");

                    b.Property<int>("TipoEquipoId")
                        .HasColumnType("int");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("EstadoId");

                    b.HasIndex("SucursalId");

                    b.HasIndex("TipoEquipoId");

                    b.ToTable("Equipos");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Equipos");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("InventariosApi.Entidades.EquiposBaja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaBaja")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrdenId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrdenId")
                        .IsUnique();

                    b.ToTable("EquiposBajas");
                });

            modelBuilder.Entity("InventariosApi.Entidades.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NombreEstado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("InventariosApi.Entidades.Labores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NombreLabor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Labores");
                });

            modelBuilder.Entity("InventariosApi.Entidades.Orden", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EquiposId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaEntrada")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fundamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SucursalId")
                        .HasColumnType("int");

                    b.Property<int>("TecnicoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EquiposId")
                        .IsUnique()
                        .HasFilter("[EquiposId] IS NOT NULL");

                    b.HasIndex("SucursalId");

                    b.HasIndex("TecnicoId");

                    b.ToTable("Ordenes");
                });

            modelBuilder.Entity("InventariosApi.Entidades.Sucursal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CodigoSucursal")
                        .HasColumnType("int");

                    b.Property<string>("NombreSucursal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sucursales");
                });

            modelBuilder.Entity("InventariosApi.Entidades.Tecnico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("CI")
                        .HasColumnType("bigint");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SegundoApellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tecnicos");
                });

            modelBuilder.Entity("InventariosApi.Entidades.TipoEquipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NombreTipoEquipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoEquipos");
                });

            modelBuilder.Entity("InventariosApi.Entidades.EquiposDefectados", b =>
                {
                    b.HasBaseType("InventariosApi.Entidades.Equipos");

                    b.Property<int>("DefectacionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaReparada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("datetime2");

                    b.HasIndex("DefectacionId");

                    b.HasDiscriminator().HasValue("EquiposDefectados");
                });

            modelBuilder.Entity("EquiposDefectadosLabores", b =>
                {
                    b.HasOne("InventariosApi.Entidades.EquiposDefectados", null)
                        .WithMany()
                        .HasForeignKey("EquiposDefectadosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventariosApi.Entidades.Labores", null)
                        .WithMany()
                        .HasForeignKey("LaboresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InventariosApi.Entidades.Componente", b =>
                {
                    b.HasOne("InventariosApi.Entidades.Equipos", "Equipos")
                        .WithMany("Componentes")
                        .HasForeignKey("EquiposId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipos");
                });

            modelBuilder.Entity("InventariosApi.Entidades.Equipos", b =>
                {
                    b.HasOne("InventariosApi.Entidades.Area", "Area")
                        .WithMany("Equipos")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventariosApi.Entidades.Estado", "Estado")
                        .WithMany("Equipos")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventariosApi.Entidades.Sucursal", "Sucursal")
                        .WithMany("Equipos")
                        .HasForeignKey("SucursalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventariosApi.Entidades.TipoEquipo", "Medios")
                        .WithMany("Equipos")
                        .HasForeignKey("TipoEquipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("Estado");

                    b.Navigation("Medios");

                    b.Navigation("Sucursal");
                });

            modelBuilder.Entity("InventariosApi.Entidades.EquiposBaja", b =>
                {
                    b.HasOne("InventariosApi.Entidades.Orden", "Orden")
                        .WithOne("EquiposBaja")
                        .HasForeignKey("InventariosApi.Entidades.EquiposBaja", "OrdenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orden");
                });

            modelBuilder.Entity("InventariosApi.Entidades.Orden", b =>
                {
                    b.HasOne("InventariosApi.Entidades.Equipos", "Equipos")
                        .WithOne("Orden")
                        .HasForeignKey("InventariosApi.Entidades.Orden", "EquiposId");

                    b.HasOne("InventariosApi.Entidades.Sucursal", "Sucursal")
                        .WithMany("Ordenes")
                        .HasForeignKey("SucursalId");

                    b.HasOne("InventariosApi.Entidades.Tecnico", "Tecnico")
                        .WithMany("Ordenes")
                        .HasForeignKey("TecnicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipos");

                    b.Navigation("Sucursal");

                    b.Navigation("Tecnico");
                });

            modelBuilder.Entity("InventariosApi.Entidades.EquiposDefectados", b =>
                {
                    b.HasOne("InventariosApi.Entidades.Defectacion", "Defectacion")
                        .WithMany("EquiposDefectados")
                        .HasForeignKey("DefectacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Defectacion");
                });

            modelBuilder.Entity("InventariosApi.Entidades.Area", b =>
                {
                    b.Navigation("Equipos");
                });

            modelBuilder.Entity("InventariosApi.Entidades.Defectacion", b =>
                {
                    b.Navigation("EquiposDefectados");
                });

            modelBuilder.Entity("InventariosApi.Entidades.Equipos", b =>
                {
                    b.Navigation("Componentes");

                    b.Navigation("Orden")
                        .IsRequired();
                });

            modelBuilder.Entity("InventariosApi.Entidades.Estado", b =>
                {
                    b.Navigation("Equipos");
                });

            modelBuilder.Entity("InventariosApi.Entidades.Orden", b =>
                {
                    b.Navigation("EquiposBaja")
                        .IsRequired();
                });

            modelBuilder.Entity("InventariosApi.Entidades.Sucursal", b =>
                {
                    b.Navigation("Equipos");

                    b.Navigation("Ordenes");
                });

            modelBuilder.Entity("InventariosApi.Entidades.Tecnico", b =>
                {
                    b.Navigation("Ordenes");
                });

            modelBuilder.Entity("InventariosApi.Entidades.TipoEquipo", b =>
                {
                    b.Navigation("Equipos");
                });
#pragma warning restore 612, 618
        }
    }
}
