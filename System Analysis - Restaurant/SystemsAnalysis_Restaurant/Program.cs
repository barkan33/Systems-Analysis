using System;
using System.Collections.Generic;

namespace SystemsAnalysis_Restaurant
{
    internal class Program
    {
        public static List<Dish> dishes;
        public List<Staff> staff;
        public List<Customer> customers;
        public List<Table> tables;
        public List<Order> orders;
        public List<Waiter> waiters;
        public List<Chef> chefs;
        public Admin admin;

        public static Menu menu;

        /*
        public static List<Dish> GenerateDishes()
        {
            Random rand = new Random();
            dishes = new List<Dish>();

            string[] dishNames = { "Spaghetti Carbonara", "Chicken Tikka Masala", "Margherita Pizza", "Caesar Salad", "Sushi Rolls", "Cheeseburger", "Pad Thai", "Fish and Chips", "Mushroom Risotto", "Tiramisu" };
            string[] dishDescriptions = { "Classic Italian pasta dish with bacon and eggs", "Creamy Indian chicken curry with rice",
                "Traditional Italian pizza with tomato, mozzarella, and basil", "Fresh salad with romaine lettuce, croutons," +
                " and Caesar dressing", "Japanese rice rolls filled with fish, vegetables, and avocado", "Juicy beef patty with cheese," +
                " lettuce, and tomato in a bun", "Stir-fried rice noodles with shrimp, tofu, and peanuts", 
                "Deep-fried battered fish served with fries", "Creamy rice dish cooked with mushrooms and parmesan cheese",
                "Classic Italian dessert with layers of coffee-soaked ladyfingers and mascarpone cheese" };

            for (int i = 0; i < dishNames.Length; i++)
            {
                int dishID = i + 1;   
                string dishName = dishNames[i];
                string dishDescription = dishDescriptions[i];
                double dishPrice = rand.Next(10, 50) + rand.NextDouble(); 

                Dish newDish = new Dish(dishID, dishName, dishDescription, dishPrice);
                dishes.Add(newDish);
            }
            dishes =RandomiseDishes(dishes);
            return dishes;
        }*/

        public static List<Table> GenerateTables()
        {
            List<Table> tables = new List<Table>();

            for (int i = 0; i < 10; i++)
            {
                int tableID = i + 1;
                int tableCapacity = new Random().Next(2, 6);
                Table newTable = new Table(tableID, tableCapacity);
                tables.Add(newTable);
            }
            return tables;
        }

        /*
        public static List<Dish> RandomiseDishes(List<Dish> dishes)
        {
            Random rand = new Random();
            for (int i = 0; i < dishes.Count; i++)
            {
                int randomIndex = rand.Next(i, dishes.Count);
                Dish temp = dishes[i];
                dishes[i] = dishes[randomIndex];
                dishes[randomIndex] = temp;
            }
            return dishes;
        }*/


        static void Main(string[] args)
        {
            menu = new Menu();
            menu.GenerateDishes();
            Console.WriteLine(menu.PrintMenu());
            Console.ReadKey();

        }
    }
}
