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
    [Migration("20201110123933_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeatherApp.Domain.Clouds", b =>
                {
                    b.Property<int>("CloudId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cloudiness")
                        .HasColumnType("int");

                    b.HasKey("CloudId");

                    b.ToTable("Clouds");
                });

            modelBuilder.Entity("WeatherApp.Domain.Coordinates", b =>
                {
                    b.Property<int>("CoordinateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("lat")
                        .HasColumnType("float");

                    b.Property<double>("lon")
                        .HasColumnType("float");

                    b.HasKey("CoordinateId");

                    b.ToTable("Coordinates");
                });

            modelBuilder.Entity("WeatherApp.Domain.Main", b =>
                {
                    b.Property<int>("MainId")
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

                    b.HasKey("MainId");

                    b.ToTable("Mains");
                });

            modelBuilder.Entity("WeatherApp.Domain.Root", b =>
                {
                    b.Property<int>("RootId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MainId")
                        .HasColumnType("int");

                    b.Property<int?>("SystemId")
                        .HasColumnType("int");

                    b.Property<int?>("WindId")
                        .HasColumnType("int");

                    b.Property<int>("city_Id")
                        .HasColumnType("int");

                    b.Property<string>("cityname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("cloudsCloudId")
                        .HasColumnType("int");

                    b.Property<int?>("coordinatesCoordinateId")
                        .HasColumnType("int");

                    b.Property<int>("timezone")
                        .HasColumnType("int");

                    b.Property<int>("update_time")
                        .HasColumnType("int");

                    b.Property<int>("visibility")
                        .HasColumnType("int");

                    b.HasKey("RootId");

                    b.HasIndex("MainId");

                    b.HasIndex("SystemId");

                    b.HasIndex("WindId");

                    b.HasIndex("cloudsCloudId");

                    b.HasIndex("coordinatesCoordinateId");

                    b.ToTable("Roots");
                });

            modelBuilder.Entity("WeatherApp.Domain.System", b =>
                {
                    b.Property<int>("SystemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("internal_parameter")
                        .HasColumnType("int");

                    b.Property<double>("message")
                        .HasColumnType("float");

                    b.Property<int>("sunrise")
                        .HasColumnType("int");

                    b.Property<int>("sunset")
                        .HasColumnType("int");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("SystemId");

                    b.ToTable("Systems");
                });

            modelBuilder.Entity("WeatherApp.Domain.Weather", b =>
                {
                    b.Property<int>("WeatherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RootId")
                        .HasColumnType("int");

                    b.Property<int>("condition")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("main")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("request_date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("WeatherId");

                    b.HasIndex("RootId");

                    b.ToTable("Weathers");
                });

            modelBuilder.Entity("WeatherApp.Domain.Wind", b =>
                {
                    b.Property<int>("WindId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("deg")
                        .HasColumnType("int");

                    b.Property<double>("speed")
                        .HasColumnType("float");

                    b.HasKey("WindId");

                    b.ToTable("Winds");
                });

            modelBuilder.Entity("WeatherApp.Domain.Root", b =>
                {
                    b.HasOne("WeatherApp.Domain.Main", "main")
                        .WithMany()
                        .HasForeignKey("MainId");

                    b.HasOne("WeatherApp.Domain.System", "system")
                        .WithMany()
                        .HasForeignKey("SystemId");

                    b.HasOne("WeatherApp.Domain.Wind", "wind")
                        .WithMany()
                        .HasForeignKey("WindId");

                    b.HasOne("WeatherApp.Domain.Clouds", "clouds")
                        .WithMany()
                        .HasForeignKey("cloudsCloudId");

                    b.HasOne("WeatherApp.Domain.Coordinates", "coordinates")
                        .WithMany()
                        .HasForeignKey("coordinatesCoordinateId");
                });

            modelBuilder.Entity("WeatherApp.Domain.Weather", b =>
                {
                    b.HasOne("WeatherApp.Domain.Root", null)
                        .WithMany("weather")
                        .HasForeignKey("RootId");
                });
#pragma warning restore 612, 618
        }
    }
}
