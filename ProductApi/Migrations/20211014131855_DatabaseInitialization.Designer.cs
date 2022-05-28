﻿// <auto-generated />
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ProductApi.Migrations
{
    [DbContext(typeof(RepositoryDbContext))]
    [Migration("20211014131855_DatabaseInitialization")]
    partial class DatabaseInitialization
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProductApi.Repository.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("product_description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("product_name")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<double>("Price")
                        .HasColumnName("price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("ReplacedParts");
                });
#pragma warning restore 612, 618
        }
    }
}
