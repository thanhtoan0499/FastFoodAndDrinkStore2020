using System.Linq;
using ApplicationCore.Entities;

namespace Infrastructure.Persistence
{
    public class SeedDataDetailReceipt
    {
        public static void Initialize(DetailReceiptContext context)
        {
            context.Database.EnsureCreated();
            if (context.DetailReceipts.Any()) return;
            context.AddRange(
                new DetailReceipt
                {
                    ReceiptID = 1,
                    ProductID = 1,
                    Quantity = 10,
                    Cost = 65000
                },
                new DetailReceipt
                {
                    ReceiptID = 1,
                    ProductID = 2,
                    Quantity = 10,
                    Cost = 65000
                },
                new DetailReceipt
                {
                    ReceiptID = 2,
                    ProductID =10,
                    Quantity = 10,
                    Cost = 65000
                },
                new DetailReceipt
                {
                    ReceiptID = 2,
                    ProductID = 5,
                    Quantity = 10,
                    Cost = 65000
                }
            );
            context.SaveChanges();
        }
    }
}