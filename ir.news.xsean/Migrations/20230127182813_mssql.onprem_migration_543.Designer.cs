﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ir.news.xsean;

#nullable disable

namespace ir.news.xsean.Migrations
{
    [DbContext(typeof(dbcontext))]
    [Migration("20230127182813_mssql.onprem_migration_543")]
    partial class mssqlonprem_migration_543
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("coment", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("com")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("newsId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("newsId");

                    b.ToTable("coment");
                });

            modelBuilder.Entity("ir.news.xsean.catgory", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("count")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.ToTable("catgories");
                });

            modelBuilder.Entity("ir.news.xsean.newsfi", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("CatgoryName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("coment")
                        .HasColumnType("int");

                    b.Property<string>("datetime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("like")
                        .HasColumnType("int");

                    b.Property<int?>("seen")
                        .HasColumnType("int");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CatgoryName");

                    b.ToTable("newsfi");
                });

            modelBuilder.Entity("ir.news.xsean.newss", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("CatgoryName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("datetime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("like")
                        .HasColumnType("int");

                    b.Property<string>("news")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("newser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("seen")
                        .HasColumnType("int");

                    b.Property<string>("shorts")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("site")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("titleimg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("titleimgdo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CatgoryName");

                    b.HasIndex("url")
                        .IsUnique();

                    b.ToTable("newss");
                });

            modelBuilder.Entity("ir.news.xsean.urlscro", b =>
                {
                    b.Property<string>("url")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("bad")
                        .HasColumnType("bit");

                    b.Property<bool>("crowel")
                        .HasColumnType("bit");

                    b.HasKey("url");

                    b.ToTable("urlscros");
                });

            modelBuilder.Entity("coment", b =>
                {
                    b.HasOne("ir.news.xsean.newss", "news")
                        .WithMany("coment")
                        .HasForeignKey("newsId");

                    b.Navigation("news");
                });

            modelBuilder.Entity("ir.news.xsean.newsfi", b =>
                {
                    b.HasOne("ir.news.xsean.catgory", "Catgory")
                        .WithMany()
                        .HasForeignKey("CatgoryName");

                    b.Navigation("Catgory");
                });

            modelBuilder.Entity("ir.news.xsean.newss", b =>
                {
                    b.HasOne("ir.news.xsean.catgory", "Catgory")
                        .WithMany("Newsses")
                        .HasForeignKey("CatgoryName");

                    b.Navigation("Catgory");
                });

            modelBuilder.Entity("ir.news.xsean.catgory", b =>
                {
                    b.Navigation("Newsses");
                });

            modelBuilder.Entity("ir.news.xsean.newss", b =>
                {
                    b.Navigation("coment");
                });
#pragma warning restore 612, 618
        }
    }
}
