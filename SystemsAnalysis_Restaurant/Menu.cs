﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsAnalysis_Restaurant
{
    public class Menu
    {
        private static List<Dish> dishes;
        private static string[] dishNames = { "Spaghetti Carbonara", "Chicken Tikka Masala", "Margherita Pizza", "Caesar Salad", "Sushi Rolls", "Cheeseburger", "Pad Thai", "Fish and Chips", "Mushroom Risotto", "Tiramisu" };
        private static string[] dishDescriptions = { "Classic Italian pasta dish with bacon and eggs", "Creamy Indian chicken curry with rice",
                                                     "Traditional Italian pizza with tomato, mozzarella, and basil", "Fresh salad with romaine lettuce," +
                                                     " and Caesar dressing", "Japanese rice rolls filled with fish,vegetables, and avocado", "Juicy beef patty with cheese," +
                                                     " lettuce, and tomato in a bun", "Stir-fried rice noodles with shrimp, tofu, and peanuts",
                                                     "Deep-fried battered fish served with fries", "Creamy rice dish cooked with mushrooms and parmesan cheese",
                                                     "Layers of coffee-soaked ladyfingers and mascarpone cheese" };
        public Menu()
        {
            dishes = new List<Dish>();
        }

        public List<Dish> GenerateDishes()
        {
            Random rand = new Random();
            dishes = new List<Dish>();

            for (int i = 0; i < dishNames.Length; i++)
            {
                int dishID = i + 1;
                string dishName = dishNames[i];
                string dishDescription = dishDescriptions[i];
                double dishPrice = rand.Next(10, 50) + rand.NextDouble();

                Dish newDish = new Dish(dishID, dishName, dishDescription, dishPrice);
                dishes.Add(newDish);
            }
            for (int i = 0; i < dishes.Count; i++)
            {
                int randomIndex = rand.Next(i, dishes.Count);
                Dish temp = dishes[i];
                dishes[i] = dishes[randomIndex];
                dishes[randomIndex] = temp;
            }
            return dishes;
        }

        public Dish GetDishById(int id)
        {
            return dishes[id];
        }
        public string PrintMenu()
        {
            string tableFormat = "|{0,-5}|{1,-29}|{2,-64}|{3,-15}|\n";
            StringBuilder sb = new StringBuilder();
            sb.Append("+-----------------------------------+----------------------------------------------------------------+---------------+\n");
            sb.Append("|              Dish                 |                      Description                               |     Price     |\n");
            sb.Append("+-----------------------------------+----------------------------------------------------------------+---------------+\n");

            for (int i = 0; i < dishes.Count; i++)
            {

                string price = dishes[i].GetDishPrice().ToString("C");

                sb.AppendFormat(tableFormat, dishes[i].GetDishID(), dishes[i].GetDishName(), dishes[i].GetDishDescription(), price);
                sb.AppendLine();
            }

            sb.Append("+-----------------------------------+----------------------------------------------------------------+---------------+\n");
            return sb.ToString();
        }

    }
}
