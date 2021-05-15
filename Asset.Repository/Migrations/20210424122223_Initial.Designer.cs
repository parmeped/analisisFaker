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
    [Migration("20210424122223_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Holdings.Domain.Asset", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<double>("AnnualInterest")
                        .HasColumnType("float");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InsertedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("Holdings.Domain.Entry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<Guid?>("AssetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InsertedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Platform")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssetId");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("Holdings.Domain.Entry", b =>
                {
                    b.HasOne("Holdings.Domain.Asset", "Asset")
                        .WithMany()
                        .HasForeignKey("AssetId");

                    b.Navigation("Asset");
                });
#pragma warning restore 612, 618
        }
    }
}
