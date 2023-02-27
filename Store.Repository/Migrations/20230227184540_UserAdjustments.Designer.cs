﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store.Repository.Contexts;

namespace Store.Repository.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20230227184540_UserAdjustments")]
    partial class UserAdjustments
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Store.Domain.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<DateTime?>("Approved");

                    b.Property<DateTime?>("Canceled");

                    b.Property<DateTime?>("Commited");

                    b.Property<DateTime>("Created");

                    b.Property<int>("Status");

                    b.Property<string>("Ticket");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Store.Domain.Models.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<Guid?>("OrderId");

                    b.Property<Guid?>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("Store.Domain.Models.PictureUrl", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<Guid?>("ProductId");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("PictureUrl");
                });

            modelBuilder.Entity("Store.Domain.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Code");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Store.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<int>("Profile");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Store.Domain.Models.Order", b =>
                {
                    b.HasOne("Store.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Store.Domain.Models.OrderItem", b =>
                {
                    b.HasOne("Store.Domain.Models.Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.HasOne("Store.Domain.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Store.Domain.Models.PictureUrl", b =>
                {
                    b.HasOne("Store.Domain.Models.Product")
                        .WithMany("Pictures")
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
