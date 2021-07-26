﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherApiApp.Data;

namespace WeatherApiApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("WeatherApiApp.Models.PrevisaoOpenUV", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Horario")
                        .HasColumnType("datetime2");

                    b.Property<float>("IndiceUV")
                        .HasColumnType("real");

                    b.Property<int?>("MunicipioID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MunicipioID");

                    b.ToTable("PrevisoesOpenUV");
                });

            modelBuilder.Entity("WeatherApiApp.Models.ReqOpenW", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("HorarioRequisicao")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("RequisicoesOpenW");
                });

            modelBuilder.Entity("WeatherApiApp.Models.PrevisaoOpenUV", b =>
                {
                    b.HasOne("WeatherApiApp.Models.Municipio", "Municipio")
                        .WithMany("PrevisoesOpenUV")
                        .HasForeignKey("MunicipioID");

                    b.Navigation("Municipio");
                });

            modelBuilder.Entity("WeatherApiApp.Models.Municipio", b =>
                {
                    b.Navigation("PrevisoesOpenUV");
                });
#pragma warning restore 612, 618
        }
    }
}
