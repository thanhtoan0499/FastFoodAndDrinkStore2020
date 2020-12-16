using System;
using System.Linq;
using ApplicationCore.Entities;

namespace Infrastructure.Persistence
{
    public class SeedDataStaff
    {
        public static void Initialize(StaffContext context)
        {
            context.Database.EnsureCreated();
            if (context.Staffs.Any()) return;
            context.AddRange(
                new Staff
                {
                    LastName = "Ngo Thi",
                    FirstName = "Huyen",
                    Dob = DateTime.Parse("06/29/2000"),
                    Gender = "Female",
                    Address = "46/18 Tran Van On, Tan Phu, TPHCM",
                    Position = "Staff",
                    SalaryRate = 1.4M
                },
                new Staff
                {
                    LastName = "Luong Trieu",
                    FirstName = "Man",
                    Dob = DateTime.Parse("09/03/2000"),
                    Gender = "Female",
                    Address = "1 Truong Chinh, Tan Phu, TP HCM",
                    Position = "Staff",
                    SalaryRate = 1.4M
                },
                new Staff
                {
                    LastName = "John",
                    FirstName = "Smiths",
                    Dob = DateTime.Parse("03/08/1970"),
                    Gender = "Male",
                    Address = "273 An Duong Vuong, P3, Q5, TPHCM",
                    Position = "Manager",
                    SalaryRate = 2.8M
                },
                new Staff
                {
                    LastName = "Nguyen Van",
                    FirstName = "Long",
                    Dob = DateTime.Parse("03/01/1999"),
                    Gender = "Male",
                    Address = "46/14/8 Tran Van On, Tan Phu, TPHCM",
                    Position = "Staff",
                    SalaryRate = 1.4M
                },
                new Staff
                {
                    LastName = "Le Duong",
                    FirstName = "Lam",
                    Dob = DateTime.Parse("01/07/1989"),
                    Gender = "Male",
                    Address = "105 Ba Huyen Thanh Quan, P3, Q3, TPHCM",
                    Position = "Staff",
                    SalaryRate = 1.4M
                },
                new Staff
                {
                    LastName = "Anna",
                    FirstName = "Joshep",
                    Dob = DateTime.Parse("03/06/1991"),
                    Gender = "Female",
                    Address = "15 Nguyen Van Cu, P1, Q5, TPHCM",
                    Position = "Staff",
                    SalaryRate = 1.4M
                },
                new Staff
                {
                    LastName = "Le Tung",
                    FirstName = "Son",
                    Dob = DateTime.Parse("10/12/1996"),
                    Gender = "Male",
                    Address = "24 Sam Son, Thanh Hoa",
                    Position = "Staff",
                    SalaryRate = 1.4M
                },
                new Staff
                {
                    LastName = "Luc",
                    FirstName = "Bao",
                    Dob = DateTime.Parse("08/11/1994"),
                    Gender = "Male",
                    Address = "117 Nghia Thuc, P5, Q5, TPHCM",
                    Position = "Manager",
                    SalaryRate = 2.8M
                },
                new Staff
                {
                    LastName = "Vo Thi Kim",
                    FirstName = "Nguyet",
                    Dob = DateTime.Parse("03/20/1999"),
                    Gender = "Female",
                    Address = "46/18 Tran Van On, Tan Phu, TPHCM",
                    Position = "Staff",
                    SalaryRate = 1.4M
                },
                new Staff
                {
                    LastName = "Ho Duy",
                    FirstName = "Tu",
                    Dob = DateTime.Parse("12/12/1989"),
                    Gender = "Male",
                    Address = "5 An Binh, P3, Q3, TPHCM",
                    Position = "Staff",
                    SalaryRate = 1.4M
                }
            );
            context.SaveChanges();
        }
    }
}