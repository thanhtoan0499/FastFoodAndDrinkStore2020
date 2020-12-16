using System.ComponentModel.DataAnnotations;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.Property(m => m.LastName)
                .HasMaxLength(60)
                .HasAnnotation("MinLength", 3)
                .IsRequired();

            builder.Property(m => m.FirstName)
                .HasMaxLength(60)
                .HasAnnotation("MinLength", 3)
                .IsRequired();

            builder.Property(m => m.Dob)
                .IsRequired();

            builder.Property(m => m.Gender)
                .HasMaxLength(6)
                .IsRequired();

            builder.Property(m => m.Address)
                .HasMaxLength(60)
                .HasAnnotation("MinLength", 3)
                .IsRequired();

            builder.Property(m => m.Position)
                .HasMaxLength(60)
                .HasAnnotation("MinLength", 3)
                .IsRequired();

            builder.Property(m => m.SalaryRate)
                .HasAnnotation("Range", (0, 100))
                .HasColumnType("decimal(18,2)");
        }
    }
}