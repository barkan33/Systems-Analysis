using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsAnalysis_Restaurant
{
    public class Customer
    {
        public static Menu menu;
        public static List<Order> orders;
        private static List<Dish> orderedDishes;

        public static void BrowseMenu()
        {

            //Client
            menu = new Menu();
            menu.GenerateDishes();
            Console.WriteLine(menu.PrintMenu());

        }


        public static void DishSelection()
        {

            orderedDishes = new List<Dish>();

            bool continueAddingDishes = true;
            while (continueAddingDishes)
            {
                Console.WriteLine($"Dish #{orderedDishes.Count + 1}:");
                Console.Write("Enter dish ID or 'done' to finish: ");
                string input = Console.ReadLine();
                if (input.ToLower() == "done")
                {
                    continueAddingDishes = false;
                }
                else
                {
                    int dishID;
                    while (!int.TryParse(input, out dishID))
                    {
                        Console.WriteLine("Invalid dish ID. Please try again.");
                        continue;
                    }

                    Dish selectedDish = menu.GetDishById(dishID);
                    if (selectedDish == null)
                    {
                        Console.WriteLine("That dish is not available. Please try again.");
                        continue;
                    }
                    else
                    {
                        orderedDishes.Add(selectedDish);
                    }
                }
            }
        }


        public static void OrderConfirmation(Table selectedTable)
        {
            // Order confirmation
            Console.WriteLine("Order summary:");
            //Display order details
            //TODO

            Console.Write("Confirm order? (y/n): ");
            string confirm = Console.ReadLine().ToLower();
            if (confirm == "y")
            {
                Order newOrder = new Order(orderedDishes, selectedTable, Order.OrderStatus.Placed);
                orders.Add(newOrder);
                Console.WriteLine("Order placed successfully!");
            }
            else
            {
                Console.WriteLine("Order canceled.");
                Program.Main();
            }
        }


        public static void Pay()
        {

        }
    }
}
