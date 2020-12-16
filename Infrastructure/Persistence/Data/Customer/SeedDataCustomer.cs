using System.Linq;
using ApplicationCore.Entities;

namespace Infrastructure.Persistence
{
    public class SeedDataCustomer
    {
        public static void Initialize(CustomerContext context)
        {
            context.Database.EnsureCreated();
            if (context.Customers.Any()) return;
            context.AddRange(
                new Customer
                {
                    Name = "Nguyen Van Long",
                    Gender = "Male",
                    Address = "46/18 Tran Van On",
                    Phone = "0567480711"
                },
                new Customer
                {
                    Name = "Ha Diep Phi",
                    Gender = "Female",
                    Address = "1 Truong Chinh, Tan Phu, TPHCM",
                    Phone = "0527982588"
                },
                new Customer
                {
                    Name = "Hoang Van Hau",
                    Gender = "Male",
                    Address = "15 Nguyen Trai, P3, P5, TPHCM",
                    Phone = "0365489611"
                },
                new Customer
                {
                    Name = "Doan Du",
                    Gender = "Male",
                    Address = "27 Nguyen Kim, P5, Q9, TPHCM",
                    Phone = "0487523695"
                },
                new Customer
                {
                    Name = "Vo Thi Xuan",
                    Gender = "Female",
                    Address = "23 Cong Quynh, P1, Q1, TPHCM",
                    Phone = "0667852148"
                },
                new Customer
                {
                    Name = "Quinlan Di",
                    Gender = "Male",
                    Address = "27 Bui Huu Nghia, P3, Q5, TPHCM",
                    Phone = "0567480711"
                },
                new Customer
                {
                    Name = "Dang Thi Hao",
                    Gender = "Female",
                    Address = "46/18 Tran Van On",
                    Phone = "0167859315"
                },
                new Customer
                {
                    Name = "Nguyen Thi Vi",
                    Gender = "Female",
                    Address = "15 Ha Tay, Nghe An",
                    Phone = "0567960711"
                }
            );
            context.SaveChanges();
        }
    }
}