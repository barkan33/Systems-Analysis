using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            Console.Clear();
            menu = new Menu();
            menu.GenerateDishes();
            Console.WriteLine(menu.PrintMenu());

        }


        public static List<Dish> DishSelection()
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
            return orderedDishes;
        }


        public static void OrderConfirmation(Table selectedTable, List<Dish> orderedDishes)
        {
            // Order confirmation
            //Display order details
            Console.Clear();
            Console.WriteLine("Order summary:");
            double price = 0;
            foreach (Dish dish in orderedDishes)
            {
                Console.WriteLine(dish.GetDetails() + "\n");
                price += dish.GetDishPrice();
            }
            Console.WriteLine($"Total: ${price:F2}");
            if (price == 0)
            {
                Console.WriteLine("Order canceled.");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                return;
            }
            Console.Write("Confirm order? (y/n): ");
            string confirm = Console.ReadLine().ToLower();
            if (confirm == "y")
            {
                Order newOrder = new Order(orderedDishes, selectedTable.GetTableNumber(), Order.OrderStatus.Placed);
                selectedTable.SetOrder(newOrder);
                orders.Add(newOrder);
                Console.WriteLine("Order placed successfully!");

            }
            else
            {
                Console.WriteLine("Order canceled.");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Program.Main();
            }
        }


        public static void CardPay()
        {
            Console.WriteLine("****** Payment Section ******");
            Console.WriteLine("Full Name: ");
            string name;
            while (true)
            {
                name = Console.ReadLine();
                if (string.IsNullOrEmpty(name) || Regex.IsMatch(name, @"[0-9!@#$%^&*()_+]"))
                {
                    Console.WriteLine("Name cannot be empty or contain numbers.");
                    continue;
                }
                break;
            }
            Console.WriteLine("Enter your ID:");
            string id;
            while (true)
            {
                id = Console.ReadLine();
                if (id.Length == 9 && int.TryParse(id, out _))
                {
                    break;
                }
                Console.WriteLine("Invalid ID. Please enter a 9-digit number.");
            }
            Console.WriteLine("Enter your Card:");

            string card;
            while (true)
            {
                card = Console.ReadLine();
                if ((card.Length == 16 || card.Length == 19) && Regex.IsMatch(card, "^[0-9 ]{16,19}$"))
                {
                    break;
                }
                Console.WriteLine("Invalid Card. Please enter a 16-digit number.");

            }
            Console.WriteLine("You have successfully paid");
        }

    }
}
