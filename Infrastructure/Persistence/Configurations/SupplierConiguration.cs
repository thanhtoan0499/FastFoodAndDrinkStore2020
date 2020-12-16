using System.ComponentModel.DataAnnotations;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(m => m.Name)
                .HasMaxLength(60)
                .HasAnnotation("MinLength", 3)
                .IsRequired();
            
            builder.Property(m => m.Address)
                .HasMaxLength(60)
                .HasAnnotation("MinLength", 3)
                .IsRequired();
        }
    }
}