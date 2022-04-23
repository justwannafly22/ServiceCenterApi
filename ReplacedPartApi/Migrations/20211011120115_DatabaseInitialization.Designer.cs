﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReplacedPartApi.Repository.Entities;

namespace ReplacedPartApi.Migrations
{
    [DbContext(typeof(RepositoryDbContext))]
    [Migration("20211011120115_DatabaseInitialization")]
    partial class DatabaseInitialization
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReplacedPartApi.Repository.Entities.ReplacedPart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdvancedInfo")
                        .IsRequired()
                        .HasColumnName("advanced_info")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("Count")
                        .HasColumnName("replaced_part_count")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("replaced_part_name")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<double>("Price")
                        .HasColumnName("price")
                        .HasColumnType("float");

                    b.Property<Guid>("ProductId")
                        .HasColumnName("product_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RepairId")
                        .HasColumnName("repair_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("ReplacedParts");
                });
#pragma warning restore 612, 618
        }
    }
}
