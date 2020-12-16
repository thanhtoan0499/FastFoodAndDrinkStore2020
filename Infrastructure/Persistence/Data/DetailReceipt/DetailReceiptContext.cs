using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class DetailReceiptContext : DbContext
    {
        public DetailReceiptContext(DbContextOptions<DetailReceiptContext> options) : base(options)
        {

        }
        public DbSet<DetailReceipt> DetailReceipts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DetailReceiptContext).Assembly);
        }
    }
}