﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderService.Infra.Data.Context;

#nullable disable

namespace OrderService.Infra.Data.Migrations
{
    [DbContext(typeof(OrderServiceContext))]
    partial class OrderServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OrderService.Domain.Models.Cart", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("OrderService.Domain.Models.Order", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<decimal>("totalPrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OrderService.Domain.Models.Product", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<int>("category")
                        .HasColumnType("int");

                    b.Property<DateTime>("created")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("updated")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OrderService.Domain.Models.User", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("created")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("roles")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OrderService.Domain.Models.Cart", b =>
                {
                    b.HasOne("OrderService.Domain.Models.User", null)
                        .WithMany("carts")
                        .HasForeignKey("userId");
                });

            modelBuilder.Entity("OrderService.Domain.Models.Order", b =>
                {
                    b.HasOne("OrderService.Domain.Models.User", null)
                        .WithMany("orders")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrderService.Domain.Models.User", b =>
                {
                    b.Navigation("carts");

                    b.Navigation("orders");
                });
#pragma warning restore 612, 618
        }
    }
}
