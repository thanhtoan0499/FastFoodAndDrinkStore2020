using System.ComponentModel.DataAnnotations;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class DetailReceiptConfiguration : IEntityTypeConfiguration<DetailReceipt>
    {
        public void Configure(EntityTypeBuilder<DetailReceipt> builder)
        {
            builder.Property(m => m.ReceiptID)
                .IsRequired();

            builder.Property(m => m.ProductID)
                .IsRequired();

            builder.Property(m => m.Quantity)
                .IsRequired();

            builder.Property(m => m.Cost)
                .IsRequired();
        }
    }
}