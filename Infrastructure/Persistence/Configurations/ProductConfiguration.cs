using System.ComponentModel.DataAnnotations;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(m => m.Type)
                .HasMaxLength(60)
                .HasAnnotation("MinLength", 3)
                .IsRequired();

            builder.Property(m => m.Name)
                .HasMaxLength(60)
                .HasAnnotation("MinLength", 3)
                .IsRequired();

            builder.Property(m => m.Price)
                .HasAnnotation("RegularExpression","([1-9][0-9]*)")
                .IsRequired();

            builder.Property(m => m.Quantity)
                .HasAnnotation("RegularExpression","([0-9]*)")
                .IsRequired();

            builder.Property(m => m.Note);
                
        }
    }
}