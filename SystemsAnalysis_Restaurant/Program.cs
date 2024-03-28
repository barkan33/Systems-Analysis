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

            for (int i = 0; i < tableAmount; i++)
            {
                int tableID = i + 1;
                int tableCapacity = new Random().Next(2, 6);
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
                Console.WriteLine("Available tables:");
                // Display available tables
                //TODO

                int selectedTableNumber = 1;
                Table selectedTable = null;


                while (selectedTable == null)
                {
                    Console.Write("Enter table number: ");

                    while (!int.TryParse(Console.ReadLine(), out selectedTableNumber))
                    {
                        Console.WriteLine("Invalid table selection. Please try again.");
                    }
                    if (selectedTableNumber == 0)
                    {
                        break;
                    }
                    selectedTable = tables.Find(table => table.GetTableNumber() == selectedTableNumber);
                    if (selectedTable == null || selectedTable.GetIsOccupied())
                    {
                        Console.WriteLine("Invalid table selection. Please try again.");
                    }
                }
                //Print Menu
                //TODO
                switch (selectedTableNumber)
                {
                    case 0:
                        break;
                        StuffFunction();
                    case 1:
                        selectedTable.SetIsOccupied(true);
                        Customer.BrowseMenu();
                        Customer.OrderConfirmation(selectedTable);
                        Customer.Pay();
                        Console.WriteLine("Thank you for your order!");

                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            }
        }


        public static void StuffFunction()
        {
            Console.WriteLine("Menu:\r\n1. Admin\r\n2. Chef\r\n3. Waiter\r\n4. Exit");
            //TODO
            int selectedProfession;
            while (!int.TryParse(Console.ReadLine(), out selectedProfession) || selectedProfession > 2)
            {
                Console.WriteLine("Invalid Profession selection. Please try again.");
            }
            int choise = 0;
            switch (selectedProfession)
            {
                case 0:
                    Console.Write("Enter Username: ");
                    string user = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    string pass = Console.ReadLine();
                    if (!Admin.Login(user, pass))
                        return;
                    Console.WriteLine("Admin Menu:\r\n1. Update Menu\r\n2. Exit");
                    while (!int.TryParse(Console.ReadLine(), out choise))
                    {
                        Console.WriteLine("Admin Menu:\r\n1. Update Menu\r\n2. Exit");
                    }
                    switch (choise)
                    {
                        case 1:

                            Admin.UpdateMenu(Customer.menu);
                            break;
                        default:
                            break;
                    }
                    break;
                case 1:
                    Console.WriteLine("Chef Menu:\r\n1. View Orders and Status\r\n2. Prepare Food and Update Status\r\n3. Exit");
                    break;
                case 2:
                    Console.WriteLine("Waiter Menu:\r\n1. View Orders and Status\r\n2. Serve Ready Orders\r\n3. Exit");

                    break;
                default:
                    Main();
                    break;
            }
        }
    }


    ////צד מלצר
    //{
    //    while ()
    //    {
    //        //1. צפיה בהזמנות + סטטוס הזמנה
    //        //2. הגשת האוכל המוכן
    //        //3. exit
    //    }
    //}
    //// צד טבח
    //{
    //    while ()
    //    {

    //        //1. צפיה בהזמנות + סטטוס הזמנה
    //        //2. הכנת האוכל + עדכון סטטוס
    //        //3. exit

    //    }
    //}
    ////צד מנהל
    //{
    //    while ()
    //    {
    //        //1. הוספת מלצר
    //        //2. הוספת טבח
    //        //3. עדכון תפריט
    //        //4. exit

    //    }
    //}

}






