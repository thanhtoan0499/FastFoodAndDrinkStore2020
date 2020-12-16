using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Store
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                var product = service.GetRequiredService<ProductContext>();
                var staff = service.GetRequiredService<StaffContext>();
                var customer = service.GetRequiredService<CustomerContext>();
                var supplier = service.GetRequiredService<SupplierContext>();
                var promotion = service.GetRequiredService<PromotionContext>();
                var invoice = service.GetRequiredService<InvoiceContext>();
                var detailInvoice = service.GetRequiredService<DetailInvoiceContext>();
                var receipt = service.GetRequiredService<ReceiptContext>();
                var detailreceipt = service.GetRequiredService<DetailReceiptContext>();
                var account = service.GetRequiredService<AccountContext>();
                try
                {
                    SeedDataProduct.Initialize(product);
                    SeedDataStaff.Initialize(staff);
                    SeedDataCustomer.Initialize(customer);
                    SeedDataSupplier.Initialize(supplier);
                    SeedDataPromotion.Initialize(promotion);
                    SeedDataInvoice.Initialize(invoice);
                    SeedDataDetailInvoice.Initialize(detailInvoice);
                    SeedDataReceipt.Initialize(receipt);
                    SeedDataDetailReceipt.Initialize(detailreceipt);
                    SeedDataAccount.Initialize(account);
                }
                catch (Exception ex)
                {
                    var logger = service.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured seeding database.");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
