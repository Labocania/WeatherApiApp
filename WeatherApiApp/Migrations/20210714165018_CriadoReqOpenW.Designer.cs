﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherApiApp.Data;

namespace WeatherApiApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210714165018_CriadoReqOpenW")]
    partial class CriadoReqOpenW
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeatherApiApp.Models.Municipio", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Altitude")
                        .HasColumnType("real");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("UltimaModificacao")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("ID");

                    b.ToTable("Municipios");
                });

            modelBuilder.Entity("WeatherApiApp.Models.ReqOpenUV", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("HorarioRequisicao")
                        .HasColumnType("datetime2");

                    b.Property<int>("MunicipioId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MunicipioId");

                    b.ToTable("RequisicoesOpenUV");
                });

            modelBuilder.Entity("WeatherApiApp.Models.ReqOpenW", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("HorarioRequisicao")
                        .HasColumnType("datetime2");

                    b.Property<int>("MunicipioId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MunicipioId");

                    b.ToTable("RequisicoesOpenW");
                });

            modelBuilder.Entity("WeatherApiApp.Models.ReqOpenUV", b =>
                {
                    b.HasOne("WeatherApiApp.Models.Municipio", null)
                        .WithMany("RequisicoesOpenUV")
                        .HasForeignKey("MunicipioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WeatherApiApp.Models.ReqOpenW", b =>
                {
                    b.HasOne("WeatherApiApp.Models.Municipio", null)
                        .WithMany("RequisicoesOpenW")
                        .HasForeignKey("MunicipioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WeatherApiApp.Models.Municipio", b =>
                {
                    b.Navigation("RequisicoesOpenUV");

                    b.Navigation("RequisicoesOpenW");
                });
#pragma warning restore 612, 618
        }
    }
}
