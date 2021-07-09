using DbPlugin1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbPlugin1.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user", "user");
            builder.HasKey(x => x.UserId);
            builder.HasIndex(x => x.Login);
            ConfigureColumns(builder);
            InitializeData(builder);
        }

        private void ConfigureColumns(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.UserId)
                .HasColumnName("user_id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.Login)
                .HasColumnName("login")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.FirstName)
                .HasColumnName("first_name")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.LastName)
                .HasColumnName("last_name")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasMaxLength(200);

            builder.Property(x => x.City)
                .HasColumnName("city")
                .HasMaxLength(200);
        }

        private void InitializeData(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User[]
                {
                    new User()
                    {
                        UserId = 1,
                        Login = "super",
                        FirstName = "Super",
                        LastName = "Superowski",
                        Email = "super@test.com",
                        City = null
                    },
                    new User()
                    {
                        UserId = 2,
                        Login = "admin",
                        FirstName = "Admin",
                        LastName = "Adminowski",
                        Email = "admin@test.com",
                        City = null
                    }
                }
            );
        }
    }
}
