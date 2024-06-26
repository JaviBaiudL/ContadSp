﻿// <auto-generated />
using System;
using ContadSP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContadSP.Migrations
{
    [DbContext(typeof(ContadSPContext))]
    [Migration("20240506155215_Nueva bd completa")]
    partial class Nuevabdcompleta
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ContadSP.Models.Articulo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("categoria_id")
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("fecha_ultimo_monto")
                        .HasColumnType("date");

                    b.Property<string>("foto")
                        .HasColumnType("longtext");

                    b.Property<double>("monto_aprox")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.HasIndex("categoria_id");

                    b.ToTable("Articulo");
                });

            modelBuilder.Entity("ContadSP.Models.Categoria", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("categoria")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("ContadSP.Models.Destino", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("destino")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Destino");
                });

            modelBuilder.Entity("ContadSP.Models.DetallePedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("articulo_id")
                        .HasColumnType("int");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<bool>("estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("pedido_id")
                        .HasColumnType("int");

                    b.Property<double>("precio")
                        .HasColumnType("double");

                    b.Property<string>("precio_letra")
                        .HasColumnType("longtext");

                    b.Property<double>("subtotal")
                        .HasColumnType("double");

                    b.Property<string>("subtotal_letra")
                        .HasColumnType("longtext");

                    b.Property<int>("unidad_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("articulo_id");

                    b.HasIndex("pedido_id");

                    b.HasIndex("unidad_id");

                    b.ToTable("DetallePedido");
                });

            modelBuilder.Entity("ContadSP.Models.Pedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("fecha_pedido")
                        .HasColumnType("date");

                    b.Property<string>("numero_acta")
                        .HasColumnType("longtext");

                    b.Property<int>("numero_proceso")
                        .HasColumnType("int");

                    b.Property<int>("provision_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("provision_id");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("ContadSP.Models.Proceso", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("monto_maximo")
                        .HasColumnType("double");

                    b.Property<double>("monto_minimo")
                        .HasColumnType("double");

                    b.Property<string>("proceso")
                        .HasColumnType("longtext");

                    b.Property<int>("tipo_pedido_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("tipo_pedido_id");

                    b.ToTable("Proceso");
                });

            modelBuilder.Entity("ContadSP.Models.Provision", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .HasColumnType("longtext");

                    b.Property<int>("destino_id")
                        .HasColumnType("int");

                    b.Property<DateOnly>("fecha_provision")
                        .HasColumnType("date");

                    b.Property<int>("proceso_id")
                        .HasColumnType("int");

                    b.Property<double>("total")
                        .HasColumnType("double");

                    b.Property<string>("total_letra")
                        .HasColumnType("longtext");

                    b.Property<int>("usuario_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("destino_id");

                    b.HasIndex("proceso_id");

                    b.HasIndex("usuario_id");

                    b.ToTable("Provision");
                });

            modelBuilder.Entity("ContadSP.Models.TipoPedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("tipo")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("TipoPedido");
                });

            modelBuilder.Entity("ContadSP.Models.UnidadMedida", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("unidad")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("UnidadMedida");
                });

            modelBuilder.Entity("ContadSP.Models.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("longtext");

                    b.Property<string>("nombre_usuario")
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .HasColumnType("longtext");

                    b.Property<string>("rol")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ContadSP.Models.Articulo", b =>
                {
                    b.HasOne("ContadSP.Models.Categoria", "Categoria")
                        .WithMany("Articulo")
                        .HasForeignKey("categoria_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("ContadSP.Models.DetallePedido", b =>
                {
                    b.HasOne("ContadSP.Models.Articulo", "Articulo")
                        .WithMany("DetallePedido")
                        .HasForeignKey("articulo_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ContadSP.Models.Pedido", "Pedido")
                        .WithMany("DetallePedido")
                        .HasForeignKey("pedido_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ContadSP.Models.UnidadMedida", "UnidadMedida")
                        .WithMany("DetallePedido")
                        .HasForeignKey("unidad_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulo");

                    b.Navigation("Pedido");

                    b.Navigation("UnidadMedida");
                });

            modelBuilder.Entity("ContadSP.Models.Pedido", b =>
                {
                    b.HasOne("ContadSP.Models.Provision", "Provision")
                        .WithMany("Pedido")
                        .HasForeignKey("provision_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provision");
                });

            modelBuilder.Entity("ContadSP.Models.Proceso", b =>
                {
                    b.HasOne("ContadSP.Models.TipoPedido", "TipoPedido")
                        .WithMany("Proceso")
                        .HasForeignKey("tipo_pedido_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoPedido");
                });

            modelBuilder.Entity("ContadSP.Models.Provision", b =>
                {
                    b.HasOne("ContadSP.Models.Destino", "Destino")
                        .WithMany("Provision")
                        .HasForeignKey("destino_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ContadSP.Models.Proceso", "Proceso")
                        .WithMany("Provision")
                        .HasForeignKey("proceso_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ContadSP.Models.Usuario", "Usuario")
                        .WithMany("Provision")
                        .HasForeignKey("usuario_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destino");

                    b.Navigation("Proceso");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ContadSP.Models.Articulo", b =>
                {
                    b.Navigation("DetallePedido");
                });

            modelBuilder.Entity("ContadSP.Models.Categoria", b =>
                {
                    b.Navigation("Articulo");
                });

            modelBuilder.Entity("ContadSP.Models.Destino", b =>
                {
                    b.Navigation("Provision");
                });

            modelBuilder.Entity("ContadSP.Models.Pedido", b =>
                {
                    b.Navigation("DetallePedido");
                });

            modelBuilder.Entity("ContadSP.Models.Proceso", b =>
                {
                    b.Navigation("Provision");
                });

            modelBuilder.Entity("ContadSP.Models.Provision", b =>
                {
                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("ContadSP.Models.TipoPedido", b =>
                {
                    b.Navigation("Proceso");
                });

            modelBuilder.Entity("ContadSP.Models.UnidadMedida", b =>
                {
                    b.Navigation("DetallePedido");
                });

            modelBuilder.Entity("ContadSP.Models.Usuario", b =>
                {
                    b.Navigation("Provision");
                });
#pragma warning restore 612, 618
        }
    }
}
