using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace SystemsAnalysis_Restaurant
{
    public class Program
    {
        private static List<Table> tables;

        public static List<Table> GenerateTables(int tableAmount)
        {
            List<Table> tables = new List<Table>();
            Random random = new Random();
            for (int i = 0; i < tableAmount; i++)
            {
                int tableID = i + 1;
                int tableCapacity = random.Next(2, 6);
                Table newTable = new Table(tableID, tableCapacity);
                tables.Add(newTable);
            }
            return tables;
        }

        public static void Main()
        {
            Customer.orders = new List<Order>();
            tables = GenerateTables(10);


            while (true)
            {

                //בחירת שולחן
                Console.Clear();
                Console.WriteLine("Available tables:");
                // Display available tables
                foreach (Table item in tables)
                {
                    if (!item.IsOccupied())
                    {
                        Console.WriteLine(item);
                    }
                }

                int selectedTableNumber = 0;
                Table selectedTable = null;


                while (selectedTable == null)
                {
                    Console.Write("Enter table number: ");

                    while (!int.TryParse(Console.ReadLine(), out selectedTableNumber) || selectedTableNumber < 0 || selectedTableNumber > tables.Count)
                    {
                        Console.WriteLine("Invalid table selection. Please try again.");
                    }
                    if (selectedTableNumber == 0)
                    {
                        break;
                    }
                    selectedTable = tables.Find(table => table.GetTableNumber() == selectedTableNumber);
                    if (selectedTable == null || selectedTable.IsOccupied())
                    {
                        Console.WriteLine("Invalid table selection. Please try again.");
                    }
                }


                if (selectedTableNumber == 0)
                {
                    StuffFunction();
                }
                else
                {
                    selectedTable.SetIsOccupied(true);
                    Customer.BrowseMenu();
                    List<Dish> orderedDishes = Customer.DishSelection();
                    Customer.OrderConfirmation(selectedTable, orderedDishes);
                    Console.WriteLine("How Do you want to pay?\n1. Card\n2. Cash");
                    int choice;
                    while (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Invalid selection. Please try again.");
                    }
                    if (choice == 1)
                    {
                        Customer.CardPay();
                    }
                    Console.WriteLine("Thank you for your order!");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
            }
        }


        public static void StuffFunction()
        {
            Console.WriteLine("Menu:\n1. Admin\n2. Chef\n3. Waiter\n4. Exit");
            int selectedProfession;
            while (!int.TryParse(Console.ReadLine(), out selectedProfession) || selectedProfession < 1 || selectedProfession > 4)
            {
                Console.WriteLine("Invalid Profession selection. Please try again.");
            }
            int choice = 0;
            switch (selectedProfession)
            {
                case 1:
                    Console.Write("Enter Username: ");
                    string user = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    string pass = Console.ReadLine();
                    if (!Admin.Login(user, pass))
                        break;
                    Console.WriteLine("Admin Menu:\n1. Update Menu\n2. Exit");
                    while (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Admin Menu:\n1. Update Menu\n2. Exit");
                    }
                    switch (choice)
                    {
                        case 1:
                            Admin.UpdateSomethingInDB();
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            break;
                        case 2:
                        default:
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("Chef Menu:\n1. View Orders and Prepare Food\n2. ManageOrders\n3. Exit");
                    while (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Chef Menu:\n1. View Orders and Prepare Food\n2. Exit");
                    }
                    switch (choice)
                    {
                        case 1:
                            Chef.ViewOrders(Customer.orders);
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            break;
                        case 2:
                            Chef.ManageOrders(Customer.orders);
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            break;
                        case 3:
                        default:
                            break;
                    }

                    break;
                case 3:
                    Console.WriteLine("Waiter Menu:\n1. View Orders and Status\n2. Serve Ready Orders\n3. ManageOrders\n4.Exit");
                    while (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Waiter Menu:\n1. View Orders and Status\n2. CleanTable\n3. Exit");
                    }
                    switch (choice)
                    {
                        case 1:
                            Waiter.ViewOrders(Customer.orders);
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            break;
                        case 2:
                            Waiter.CleanTable(tables);
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            break;
                        case 3:
                            Waiter.ManageOrders(Customer.orders);
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            break;
                        case 4:
                        default:
                            break;
                    }
                    break;
                case 4:
                default:
                    Main();
                    break;
            }
        }
    }
}






