﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReceitaDespesas.Persistence.Contextos;

namespace ReceitaDespesas.Persistence.Migrations
{
    [DbContext(typeof(ReceitaDespesasContext))]
    [Migration("20220912173413_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ReceitaDespesas.Domain.Despesas", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("Despesas");
                });

            modelBuilder.Entity("ReceitaDespesas.Domain.Receita", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("Receitas");
                });

            modelBuilder.Entity("ReceitaDespesas.Domain.ReceitasEDespesas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DespesasId")
                        .HasColumnType("int");

                    b.Property<int>("ReceitaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DespesasId");

                    b.HasIndex("ReceitaId");

                    b.ToTable("ReceitasEDespesas");
                });

            modelBuilder.Entity("ReceitaDespesas.Domain.ReceitasEDespesas", b =>
                {
                    b.HasOne("ReceitaDespesas.Domain.Despesas", "Despesas")
                        .WithMany("ReceitaDespesas")
                        .HasForeignKey("DespesasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReceitaDespesas.Domain.Receita", "Receita")
                        .WithMany("ReceitasDespesas")
                        .HasForeignKey("ReceitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Despesas");

                    b.Navigation("Receita");
                });

            modelBuilder.Entity("ReceitaDespesas.Domain.Despesas", b =>
                {
                    b.Navigation("ReceitaDespesas");
                });

            modelBuilder.Entity("ReceitaDespesas.Domain.Receita", b =>
                {
                    b.Navigation("ReceitasDespesas");
                });
#pragma warning restore 612, 618
        }
    }
}