using System.ComponentModel.DataAnnotations;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(m => m.Staff)
                .HasMaxLength(60)
                .HasAnnotation("MinLength", 3)
                .IsRequired();

            builder.Property(m => m.Supplier)
                .HasMaxLength(60)
                .HasAnnotation("MinLength", 3)
                .IsRequired();

            builder.Property(m => m.ImportDate)
                .IsRequired();

            builder.Property(m => m.Cost)
                .IsRequired();
        }
    }
}