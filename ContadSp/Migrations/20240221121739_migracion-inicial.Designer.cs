﻿// <auto-generated />
using System;
using ContadSp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContadSp.Migrations
{
    [DbContext(typeof(ContadSpContext))]
    [Migration("20240221121739_migracion-inicial")]
    partial class migracioninicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ContadSp.Modelos.Modelo_ABM_Categoria", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("categoria")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Modelo_ABM_Categoria");
                });

            modelBuilder.Entity("ContadSp.Modelos.Modelo_Articulos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("fecha_ultimo_monto")
                        .HasColumnType("date");

                    b.Property<int>("id_categoria")
                        .HasColumnType("int");

                    b.Property<double>("monto_aprox")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.HasIndex("id_categoria");

                    b.ToTable("Modelo_Articulos");
                });

            modelBuilder.Entity("ContadSp.Modelos.Modelo_Articulos", b =>
                {
                    b.HasOne("ContadSp.Modelos.Modelo_ABM_Categoria", "Categoria")
                        .WithMany("Articulos")
                        .HasForeignKey("id_categoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("ContadSp.Modelos.Modelo_ABM_Categoria", b =>
                {
                    b.Navigation("Articulos");
                });
#pragma warning restore 612, 618
        }
    }
}
