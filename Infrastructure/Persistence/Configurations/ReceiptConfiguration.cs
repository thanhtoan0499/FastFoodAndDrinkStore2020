using System.ComponentModel.DataAnnotations;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            builder.Property(m => m.StaffID)
                .HasMaxLength(60)
                .HasAnnotation("MinLength", 3)
                .IsRequired();

            builder.Property(m => m.CustomerID)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(m => m.ExportDate)
                .IsRequired();

            builder.Property(m => m.TotalCost)
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}