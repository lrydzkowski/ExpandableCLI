// <auto-generated />
using System;
using DbPlugin2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DbPlugin2.Migrations
{
    [DbContext(typeof(DbPlugin2DbContext))]
    partial class DbPlugin2DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("DbPlugin2.Models.Operation", b =>
                {
                    b.Property<long>("RecId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("rec_id");

                    b.Property<DateTime>("EndDateTimeUTC")
                        .HasColumnType("TEXT")
                        .HasColumnName("end_date_time_utc");

                    b.Property<string>("OperationKey")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("operation_key");

                    b.Property<DateTime>("StartDateTimeUTC")
                        .HasColumnType("TEXT")
                        .HasColumnName("start_date_time_utc");

                    b.HasKey("RecId");

                    b.ToTable("operation");

                    b.HasData(
                        new
                        {
                            RecId = 1L,
                            EndDateTimeUTC = new DateTime(2021, 5, 29, 10, 10, 0, 0, DateTimeKind.Utc),
                            OperationKey = "login",
                            StartDateTimeUTC = new DateTime(2021, 5, 29, 10, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            RecId = 2L,
                            EndDateTimeUTC = new DateTime(2021, 6, 1, 10, 10, 0, 0, DateTimeKind.Utc),
                            OperationKey = "create_user",
                            StartDateTimeUTC = new DateTime(2021, 6, 1, 10, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            RecId = 3L,
                            EndDateTimeUTC = new DateTime(2021, 5, 29, 10, 10, 0, 0, DateTimeKind.Utc),
                            OperationKey = "delete_user",
                            StartDateTimeUTC = new DateTime(2021, 5, 29, 10, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            RecId = 4L,
                            EndDateTimeUTC = new DateTime(2021, 5, 29, 10, 10, 0, 0, DateTimeKind.Utc),
                            OperationKey = "create_user",
                            StartDateTimeUTC = new DateTime(2021, 5, 29, 10, 0, 0, 0, DateTimeKind.Utc)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
