using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace SystemsAnalysis_Restaurant
{
    class Menu
    {
        private static List<Dish> dishes;
    
        public Menu()
        {
                dishes = new List<Dish>();
        }

        public List<Dish> GenerateDishes()
        {
            Random rand = new Random();
            dishes = new List<Dish>();

            string[] dishNames = { "Spaghetti Carbonara", "Chicken Tikka Masala", "Margherita Pizza", "Caesar Salad", "Sushi Rolls", "Cheeseburger", "Pad Thai", "Fish and Chips", "Mushroom Risotto", "Tiramisu" };
            string[] dishDescriptions = { "Classic Italian pasta dish with bacon and eggs", "Creamy Indian chicken curry with rice",
                           "Traditional Italian pizza with tomato, mozzarella, and basil", "Fresh salad with romaine lettuce," +
                                          " and Caesar dressing", "Japanese rice rolls filled with fish,vegetables, and avcado", "Juicy beef patty with cheese," +
                                                         " lettuce, and tomato in a bun", "Stir-fried rice noodles with shrimp, tofu, and peanuts", 
                           "Deep-fried battered fish served with fries", "Creamy rice dish cooked with mushrooms and parmesan cheese",
                           "Layers of coffee-soaked ladyfingers and mascarpone cheese" };

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

        public string PrintMenu()
        {
            string tableFormat = "|{0,-30}|{1,-60}|{2,-15}|\n";
            StringBuilder sb = new StringBuilder();
            sb.Append("+--------------------------------+------------------------------------------------------------+---------------+\n");
            sb.Append("|              Dish              |                      Description                               |     Price     |\n");
            sb.Append("+--------------------------------+------------------------------------------------------------+---------------+\n");

            for (int i = 0; i < dishes.Count; i++)
            {

                string price = dishes[i].GetDishPrice().ToString("C");

                sb.AppendFormat(tableFormat, dishes[i].GetDishName(), dishes[i].GetDishDescription(), price);
                sb.AppendLine();
            }

            sb.Append("+--------------------------------+------------------------------------------------------------+---------------+\n");
            return sb.ToString();
        }



    }
}
