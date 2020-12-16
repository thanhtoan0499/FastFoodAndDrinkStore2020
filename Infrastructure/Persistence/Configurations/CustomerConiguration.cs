using System.ComponentModel.DataAnnotations;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(m => m.Name)
                .HasMaxLength(60)
                .HasAnnotation("MinLength", 3)
                .IsRequired();

            builder.Property(m => m.Gender)
                .HasMaxLength(6)
                .IsRequired();

            builder.Property(m => m.Address)
                .HasMaxLength(60)
                .HasAnnotation("MinLength", 3)
                .IsRequired();

            builder.Property(m => m.Phone)
                .HasMaxLength(11)
                .HasAnnotation("RegularExpression","^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$")
                .IsRequired();

        }
    }
}