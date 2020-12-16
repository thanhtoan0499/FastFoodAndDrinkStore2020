using System.ComponentModel.DataAnnotations;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class DetailInvoiceConfiguration : IEntityTypeConfiguration<DetailInvoice>
    {
        public void Configure(EntityTypeBuilder<DetailInvoice> builder)
        {
            builder.Property(m => m.InvoiceId)
                .IsRequired();

            builder.Property(m => m.ProductId)
                .IsRequired();

            builder.Property(m => m.ProductName)
                .HasMaxLength(60)
                .HasAnnotation("MinLength", 3)
                .IsRequired();

            builder.Property(m => m.Price)
                .IsRequired();

            builder.Property(m => m.Quantity)
                .IsRequired();
            builder.Property(m => m.TotalCost)
                .IsRequired();
        }
    }
}