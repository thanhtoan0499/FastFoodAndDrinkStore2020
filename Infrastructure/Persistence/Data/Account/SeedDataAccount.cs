using System;
using System.Linq;
using ApplicationCore.Entities;

namespace Infrastructure.Persistence
{
    public class SeedDataAccount
    {
        public static void Initialize(AccountContext context)
        {
            context.Database.EnsureCreated();
            if (context.Accounts.Any()) return;
            context.AddRange(
                new Account
                {
                    username="admin",
                    password="admin",
                    permission=0
                }
            );
            context.SaveChanges();
        }
    }
}