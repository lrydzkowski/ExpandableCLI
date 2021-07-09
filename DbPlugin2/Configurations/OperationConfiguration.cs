using DbPlugin2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DbPlugin2.Configurations
{
    class OperationConfiguration : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            builder.ToTable("operation");
            builder.HasKey(x => x.RecId);
            ConfigureColumns(builder);
            InitializeData(builder);
        }

        private void ConfigureColumns(EntityTypeBuilder<Operation> builder)
        {
            builder.Property(x => x.RecId)
                .HasColumnName("rec_id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.OperationKey)
                .HasColumnName("operation_key")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.StartDateTimeUTC)
                .HasColumnName("start_date_time_utc")
                .IsRequired();

            builder.Property(x => x.EndDateTimeUTC)
                .HasColumnName("end_date_time_utc")
                .IsRequired();
        }

        private void InitializeData(EntityTypeBuilder<Operation> builder)
        {
            builder.HasData(
                new Operation[]
                {
                    new Operation()
                    {
                        RecId = 1,
                        OperationKey = "login",
                        StartDateTimeUTC = new DateTime(2021, 5, 29, 10, 0, 0, DateTimeKind.Utc),
                        EndDateTimeUTC = new DateTime(2021, 5, 29, 10, 10, 0, DateTimeKind.Utc)
                    },
                    new Operation()
                    {
                        RecId = 2,
                        OperationKey = "create_user",
                        StartDateTimeUTC = new DateTime(2021, 6, 1, 10, 0, 0, DateTimeKind.Utc),
                        EndDateTimeUTC = new DateTime(2021, 6, 1, 10, 10, 0, DateTimeKind.Utc)
                    },
                    new Operation()
                    {
                        RecId = 3,
                        OperationKey = "delete_user",
                        StartDateTimeUTC = new DateTime(2021, 5, 29, 10, 0, 0, DateTimeKind.Utc),
                        EndDateTimeUTC = new DateTime(2021, 5, 29, 10, 10, 0, DateTimeKind.Utc)
                    },
                    new Operation()
                    {
                        RecId = 4,
                        OperationKey = "create_user",
                        StartDateTimeUTC = new DateTime(2021, 5, 29, 10, 0, 0, DateTimeKind.Utc),
                        EndDateTimeUTC = new DateTime(2021, 5, 29, 10, 10, 0, DateTimeKind.Utc)
                    }
                }
            );
        }
    }
}
