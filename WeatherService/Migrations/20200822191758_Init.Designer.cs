﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherApp.DataAccessLayer;

namespace WeatherService.Migrations
{
    [DbContext(typeof(WeatherContext))]
    [Migration("20200822191758_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeatherApp.Domain.Main", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("feels_like")
                        .HasColumnType("float");

                    b.Property<int>("humidity")
                        .HasColumnType("int");

                    b.Property<int>("pressure")
                        .HasColumnType("int");

                    b.Property<double>("temp")
                        .HasColumnType("float");

                    b.Property<double>("temp_max")
                        .HasColumnType("float");

                    b.Property<double>("temp_min")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Mains");
                });

            modelBuilder.Entity("WeatherApp.Domain.Root", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cityname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("datetime")
                        .HasColumnType("int");

                    b.Property<int?>("mainId")
                        .HasColumnType("int");

                    b.Property<int?>("sysid")
                        .HasColumnType("int");

                    b.Property<int>("timezone")
                        .HasColumnType("int");

                    b.Property<int>("visibility")
                        .HasColumnType("int");

                    b.Property<int?>("windId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("mainId");

                    b.HasIndex("sysid");

                    b.HasIndex("windId");

                    b.ToTable("Roots");
                });

            modelBuilder.Entity("WeatherApp.Domain.System", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("message")
                        .HasColumnType("float");

                    b.Property<int>("sunrise")
                        .HasColumnType("int");

                    b.Property<int>("sunset")
                        .HasColumnType("int");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Systems");
                });

            modelBuilder.Entity("WeatherApp.Domain.Weather", b =>
                {
                    b.Property<int>("weather_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Rootid")
                        .HasColumnType("int");

                    b.Property<int>("condition")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("main")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("weather_Id");

                    b.HasIndex("Rootid");

                    b.ToTable("Weathers");
                });

            modelBuilder.Entity("WeatherApp.Domain.Wind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("deg")
                        .HasColumnType("int");

                    b.Property<double>("speed")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Winds");
                });

            modelBuilder.Entity("WeatherApp.Domain.Root", b =>
                {
                    b.HasOne("WeatherApp.Domain.Main", "main")
                        .WithMany()
                        .HasForeignKey("mainId");

                    b.HasOne("WeatherApp.Domain.System", "sys")
                        .WithMany()
                        .HasForeignKey("sysid");

                    b.HasOne("WeatherApp.Domain.Wind", "wind")
                        .WithMany()
                        .HasForeignKey("windId");
                });

            modelBuilder.Entity("WeatherApp.Domain.Weather", b =>
                {
                    b.HasOne("WeatherApp.Domain.Root", null)
                        .WithMany("weather")
                        .HasForeignKey("Rootid");
                });
#pragma warning restore 612, 618
        }
    }
}
