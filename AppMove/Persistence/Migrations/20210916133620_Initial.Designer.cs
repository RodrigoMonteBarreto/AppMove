﻿// <auto-generated />
using System;
using AppMove.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppMove.Persistence.Migrations
{
    [DbContext(typeof(ProdutoContext))]
    [Migration("20210916133620_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("AppMove.Entities.Cartao", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bandeira")
                        .HasColumnType("TEXT");

                    b.Property<int>("CCV")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataExpiracao")
                        .HasColumnType("TEXT");

                    b.Property<int>("Numero")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titular")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Cartao");
                });

            modelBuilder.Entity("AppMove.Entities.Compra", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CartaoID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataCompra")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("produtoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("CartaoID");

                    b.HasIndex("produtoId");

                    b.ToTable("tb_Compras");
                });

            modelBuilder.Entity("AppMove.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Estoque")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Valor")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("tb_Product");
                });

            modelBuilder.Entity("AppMove.Entities.Compra", b =>
                {
                    b.HasOne("AppMove.Entities.Cartao", "Cartao")
                        .WithMany()
                        .HasForeignKey("CartaoID");

                    b.HasOne("AppMove.Entities.Product", "produto")
                        .WithMany("Reviews")
                        .HasForeignKey("produtoId");

                    b.Navigation("Cartao");

                    b.Navigation("produto");
                });

            modelBuilder.Entity("AppMove.Entities.Product", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}