﻿// <auto-generated />
using System;
using Assets.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Holdings.Repository.Migrations
{
    [DbContext(typeof(HoldingsContext))]
    [Migration("20210515215229_Vaccines")]
    partial class Vaccines
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Faker.Domain.DimDate", b =>
                {
                    b.Property<int>("DateKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("CalendarQuarter")
                        .HasColumnType("tinyint");

                    b.Property<byte>("CalendarSemester")
                        .HasColumnType("tinyint");

                    b.Property<short>("CalendarYear")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("FullDateAlternateKey")
                        .HasColumnType("datetime2");

                    b.HasKey("DateKey");

                    b.ToTable("DimDate");
                });

            modelBuilder.Entity("Faker.Domain.DimGeography", b =>
                {
                    b.Property<int>("GeographyKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryRegionCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnglishCountryRegionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IpAddressLocator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateProvinceCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateProvinceName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GeographyKey");

                    b.ToTable("DimGeography");
                });

            modelBuilder.Entity("Faker.Domain.DimHospital", b =>
                {
                    b.Property<int>("HospitalKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Direction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HealthWorkers")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HospitalKey");

                    b.ToTable("DimHospitals");
                });

            modelBuilder.Entity("Faker.Domain.DimIndividual", b =>
                {
                    b.Property<int>("IndividualKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<int>("DocumentNumber")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HospitalDistance")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Occupation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Vaccine1")
                        .HasColumnType("bit");

                    b.Property<bool>("Vaccine2")
                        .HasColumnType("bit");

                    b.HasKey("IndividualKey");

                    b.ToTable("DimIndividual");
                });

            modelBuilder.Entity("Faker.Domain.DimVaccines", b =>
                {
                    b.Property<int>("VaccineKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Effectiveness")
                        .HasColumnType("int");

                    b.Property<int>("LaboratoryKey")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VaccineKey");

                    b.ToTable("DimVaccines");
                });
#pragma warning restore 612, 618
        }
    }
}
