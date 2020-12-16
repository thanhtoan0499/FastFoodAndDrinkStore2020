using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ReceiptContext : DbContext
    {
        public ReceiptContext(DbContextOptions<ReceiptContext> options) : base(options)
        {

        }
        public DbSet<Receipt> Receipts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReceiptContext).Assembly);
        }
    }
}