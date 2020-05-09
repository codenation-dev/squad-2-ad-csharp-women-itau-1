﻿// <auto-generated />
using System;
using CentralDeErros.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CentralDeErros.Migrations
{
    [DbContext(typeof(CentralErrosContext))]
    [Migration("20200507024503_identity3")]
    partial class identity3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CentralDeErros.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Archived")
                        .HasColumnName("archived");

                    b.Property<string>("CollectedBy")
                        .IsRequired()
                        .HasColumnName("collectedBy")
                        .HasMaxLength(45);

                    b.Property<DateTime>("Data")
                        .HasColumnName("data");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasMaxLength(250);

                    b.Property<string>("Environment")
                        .IsRequired()
                        .HasColumnName("environment")
                        .HasMaxLength(45);

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnName("level")
                        .HasMaxLength(45);

                    b.Property<string>("Log")
                        .IsRequired()
                        .HasColumnName("log")
                        .HasMaxLength(4000);

                    b.Property<string>("LogId")
                        .IsRequired()
                        .HasColumnName("logId")
                        .HasMaxLength(45);

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnName("origin")
                        .HasMaxLength(250);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasMaxLength(45);

                    b.HasKey("Id");

                    b.ToTable("event");
                });

            modelBuilder.Entity("CentralDeErros.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("Created_at");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnName("Login")
                        .HasMaxLength(45);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(250);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("Password")
                        .HasMaxLength(45);

                    b.HasKey("Id");

                    b.ToTable("user");
                });
#pragma warning restore 612, 618
        }
    }
}
