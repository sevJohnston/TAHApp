﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TakeAHike.Repositories;

namespace TakeAHike.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200316014323_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TakeAHike.Models.Hike", b =>
                {
                    b.Property<int>("HikeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrailName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HikeID");

                    b.ToTable("Hikes");
                });

            modelBuilder.Entity("TakeAHike.Models.Resource", b =>
                {
                    b.Property<int>("ResourceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResourceID1")
                        .HasColumnType("int");

                    b.Property<string>("ResourceName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResourceID");

                    b.HasIndex("ResourceID1");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("TakeAHike.Models.Resource", b =>
                {
                    b.HasOne("TakeAHike.Models.Resource", null)
                        .WithMany("Resources")
                        .HasForeignKey("ResourceID1");
                });
#pragma warning restore 612, 618
        }
    }
}