using System.ComponentModel.DataAnnotations;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(m => m.username)
                .IsRequired();

            builder.Property(m => m.password)
                .IsRequired();

            builder.Property(m => m.permission)
                .IsRequired();
        }
    }
}