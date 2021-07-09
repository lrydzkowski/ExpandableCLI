﻿// <auto-generated />
using DbPlugin1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DbPlugin1.Migrations
{
    [DbContext(typeof(DbPlugin1DbContext))]
    [Migration("20210709175401_1.0.0-init-db")]
    partial class _100initdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("DbPlugin1.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("user_id");

                    b.Property<string>("City")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT")
                        .HasColumnName("city");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT")
                        .HasColumnName("last_name");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("login");

                    b.HasKey("UserId");

                    b.HasIndex("Login");

                    b.ToTable("user", "user");

                    b.HasData(
                        new
                        {
                            UserId = 1L,
                            Email = "super@test.com",
                            FirstName = "Super",
                            LastName = "Superowski",
                            Login = "super"
                        },
                        new
                        {
                            UserId = 2L,
                            Email = "admin@test.com",
                            FirstName = "Admin",
                            LastName = "Adminowski",
                            Login = "admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
