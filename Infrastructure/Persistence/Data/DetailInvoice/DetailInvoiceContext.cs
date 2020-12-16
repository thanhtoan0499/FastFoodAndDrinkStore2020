using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class DetailInvoiceContext : DbContext
    {
        public DetailInvoiceContext(DbContextOptions<DetailInvoiceContext> options) : base(options)
        {

        }
        public DbSet<DetailInvoice> DetailInvoices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DetailInvoiceContext).Assembly);
        }
    }
}