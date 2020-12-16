using System.Linq;
using ApplicationCore.Entities;

namespace Infrastructure.Persistence
{
    public class SeedDataSupplier
    {
        public static void Initialize(SupplierContext context)
        {
            context.Database.EnsureCreated();
            if (context.Suppliers.Any()) return;
            context.AddRange(
                new Supplier
                {
                    Name = "Domino's Pizza",
            
                    Address = "1 Truong Chinh, Tan Phu, TPHCM"
                },
                new Supplier
                {
                    Name = "Big Basket",
            
                    Address = "35 Thanh Thai, Q1, TPHCM"
                },
                new Supplier
                {
                    Name = "Aquafina",
              
                    Address = "87 Dinh Tien Hoang, Q1, TPHCM"
                },
                new Supplier
                {
                    Name = "Highlands",
              
                    Address = "23 Nguyen Bieu, Q5, TPHCM"
                },
                new Supplier
                {
                    Name = "Isotonic Company",
           
                    Address = "1 Truong Chinh, Tan Phu, TPHCM"
                },
                new Supplier
                {
                    Name = "Nutri Foods",
           
                    Address = "57 Cong Hoa, Tan Phu, TPHCM"
                },
                new Supplier
                {
                    Name = "Quick Tea",
          
                    Address = "270 Nguyen Van Cu, Q5, TPHCM"
                },
                new Supplier
                {
                    Name = "Quick Tea",
            
                    Address = "270 Nguyen Van Cu, Q5, TPHCM"
                },
                new Supplier
                {
                    Name = "Lady Dutch",
      
                    Address = "5 Nghia Thuc, Q5 , TPHCM"
                }
            );
            context.SaveChanges();
        }
    }
}