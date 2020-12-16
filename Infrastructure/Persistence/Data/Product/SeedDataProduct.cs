using System.Linq;
using ApplicationCore.Entities;

namespace Infrastructure.Persistence
{
    public class SeedDataProduct
    {
        public static void Initialize(ProductContext context)
        {
            context.Database.EnsureCreated();
            if (context.Products.Any()) return;
            context.AddRange(
                new Product
                {
                    Type = "FastFood",
                    Name = "Pizza",
                    Price = 80000,
                    Quantity = 20,
                    Note = ""
                },
                new Product
                {
                    Type = "FastFood",
                    Name = "Hamburger",
                    Price = 45000,
                    Quantity = 55,
                    Note = ""
                },
                new Product
                {
                    Type = "FastFood",
                    Name = "Hot dog",
                    Price = 20000,
                    Quantity = 78,
                    Note = ""
                },
                new Product
                {
                    Type = "FastFood",
                    Name = "Noodles",
                    Price = 25000,
                    Quantity = 90,
                    Note = ""
                },
                new Product
                {
                    Type = "FastFood",
                    Name = "Pho",
                    Price = 45000,
                    Quantity = 30,
                    Note = ""
                },
                new Product
                {
                    Type = "Food",
                    Name = "Fried Rice",
                    Price = 30000,
                    Quantity = 50,
                    Note = ""
                },
                new Product
                {
                    Type = "Food",
                    Name = "Bread",
                    Price = 12000,
                    Quantity = 100,
                    Note = ""
                },
                new Product
                {
                    Type = "Food",
                    Name = "Banana",
                    Price = 60000,
                    Quantity = 200,
                    Note = ""
                },
                new Product
                {
                    Name = "Spring Rolls",
                    Type = "Food",
                    Price = 85000,
                    Quantity = 100,
                    Note = ""
                },
                new Product
                {
                    Name = "Sandwich",
                    Type = "Food",
                    Price = 85000,
                    Quantity = 100,
                    Note = ""
                },
                new Product
                {
                    Type = "Food",
                    Name = "Chao",
                    Price = 25000,
                    Quantity = 45,
                    Note = ""
                },
                new Product
                {
                    Name = "Stuffed Pancake",
                    Type = "Food",
                    Price = 80000,
                    Quantity = 46,
                    Note = ""
                },
                new Product
                {
                    Name = "Girdle-cake",
                    Type = "Food",
                    Price = 10000,
                    Quantity = 56,
                    Note = ""
                },
                new Product
                {
                    Name = "Shrimp in Batter",
                    Type = "FastFood",
                    Price = 32000,
                    Quantity = 300,
                    Note = ""
                },
                new Product
                {
                    Name = "Young Rice Cake",
                    Type = "Food",
                    Price = 20000,
                    Quantity = 75,
                    Note = ""
                },
                new Product
                {
                    Name = "Stuffed sticky rice balls",
                    Type = "Food",
                    Price = 80000,
                    Quantity = 46,
                    Note = ""
                },
                new Product
                {
                    Name = "Candy",
                    Type = "Food",
                    Price = 5000,
                    Quantity = 85,
                    Note = ""
                },
                new Product
                {
                    Name = "Coca Cola",
                    Type = "Drink",
                    Price = 12000,
                    Quantity = 540,
                    Note = ""
                },
                new Product
                {
                    Name = "Pepsi",
                    Type = "Drink",
                    Price = 15000,
                    Quantity = 530,
                    Note = ""
                },
                new Product
                {
                    Name = "Milk Tea",
                    Type = "Drink",
                    Price = 25000,
                    Quantity = 60,
                    Note = ""
                },
                new Product
                {
                    Name = "Orange Juice",
                    Type = "Drink",
                    Price = 15000,
                    Quantity = 70,
                    Note = ""
                },
                new Product
                {
                    Name = "Lemon Juice",
                    Type = "Drink",
                    Price = 12000,
                    Quantity = 600,
                    Note = ""
                },
                new Product
                {
                    Name = "Coffee",
                    Type = "Drink",
                    Price = 12000,
                    Quantity = 600,
                    Note = ""
                },
                new Product
                {
                    Name = "Pure Water",
                    Type = "Drink",
                    Price = 10000,
                    Quantity = 345,
                    Note = ""
                },
                new Product
                {
                    Name = "Milk",
                    Type = "Drink",
                    Price = 12000,
                    Quantity = 29,
                    Note = ""
                },
                new Product
                {
                    Name = "Soda",
                    Type = "Drink",
                    Price = 12000,
                    Quantity = 50,
                    Note = ""
                },
                new Product
                {
                    Name = "Beer",
                    Type = "Drink",
                    Price = 7500,
                    Quantity = 420,
                    Note = ""
                }
            );
            context.SaveChanges();
        }
    }
}