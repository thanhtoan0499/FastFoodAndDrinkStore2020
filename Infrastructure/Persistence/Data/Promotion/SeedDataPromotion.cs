using System;
using System.Linq;
using ApplicationCore.Entities;

namespace Infrastructure.Persistence
{
    public class SeedDataPromotion
    {
        public static void Initialize(PromotionContext context)
        {
            context.Database.EnsureCreated();
            if (context.Promotions.Any()) return;
            context.AddRange(
                new Promotion
                {
                    Name = "PRO01",
                    Discount = 10,
                    Start = DateTime.Now,
                    End = DateTime.Parse("12/12/2019"),
                },
                new Promotion
                {
                    Name = "PRO02",
                    Discount = 20,
                    Start = DateTime.Now,
                    End = DateTime.Parse("12/12/2019"),
                },
                new Promotion
                {
                    Name = "HALOWEEN",
                    Discount = 15,
                    Start = DateTime.Now,
                    End = DateTime.Parse("12/12/2019"),
                },
                new Promotion
                {
                    Name = "NEWYEAR",
                    Discount = 16,
                    Start = DateTime.Now,
                    End = DateTime.Parse("12/12/2019"),
                },
                new Promotion
                {
                    Name = "BLACKFRIDAY",
                    Discount = 40,
                    Start = DateTime.Now,
                    End = DateTime.Parse("12/12/2019"),
                },
                new Promotion
                {
                    Name = "NOVEMBER_N",
                    Discount = 12,
                    Start = DateTime.Now,
                    End = DateTime.Parse("12/12/2019"),
                },
                new Promotion
                {
                    Name = "OPEN_PRO",
                    Discount = 20,
                    Start = DateTime.Now,
                    End = DateTime.Parse("12/12/2019"),
                },
                new Promotion
                {
                    Name = "SALE_WEEKLY",
                    Discount = 5,
                    Start = DateTime.Now,
                    End = DateTime.Parse("12/12/2019"),
                },
                new Promotion
                {
                    Name = "FREE_DAY",
                    Discount = 80,
                    Start = DateTime.Now,
                    End = DateTime.Parse("12/12/2019"),
                }
            );
            context.SaveChanges();
        }
    }
}