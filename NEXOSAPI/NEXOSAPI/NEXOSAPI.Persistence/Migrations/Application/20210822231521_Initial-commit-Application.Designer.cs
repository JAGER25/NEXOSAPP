﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NEXOSAPI.Persistence;
using Oracle.EntityFrameworkCore.Metadata;

namespace NEXOSAPI.Persistence.Migrations.Application
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210822231521_Initial-commit-Application")]
    partial class InitialcommitApplication
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NEXOSAPI.Domain.Entities.Author", b =>
                {
                    b.Property<int>("IdMaximumBooks")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityOrigin")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("DateBirth")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("FullName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("Id")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("MaximumBooksId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("IdMaximumBooks");

                    b.HasIndex("MaximumBooksId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("NEXOSAPI.Domain.Entities.Book", b =>
                {
                    b.Property<int>("IdAuthor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthorIdMaximumBooks")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Gender")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("Id")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("NumberPages")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Title")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("Year")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("IdAuthor");

                    b.HasIndex("AuthorIdMaximumBooks");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("NEXOSAPI.Domain.Entities.MaximumBooks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Total")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.ToTable("MaximumBooks");
                });

            modelBuilder.Entity("NEXOSAPI.Domain.Entities.Author", b =>
                {
                    b.HasOne("NEXOSAPI.Domain.Entities.MaximumBooks", "MaximumBooks")
                        .WithMany()
                        .HasForeignKey("MaximumBooksId");

                    b.Navigation("MaximumBooks");
                });

            modelBuilder.Entity("NEXOSAPI.Domain.Entities.Book", b =>
                {
                    b.HasOne("NEXOSAPI.Domain.Entities.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorIdMaximumBooks");

                    b.Navigation("Author");
                });
#pragma warning restore 612, 618
        }
    }
}