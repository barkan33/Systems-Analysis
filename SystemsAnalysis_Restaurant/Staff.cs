using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsAnalysis_Restaurant
{
    public class Staff
    {
        public static void ViewOrders(List<Order> orders)
        {
            int count = 0;
            foreach (Order order in orders)
            {
                if (order.GetStatus() != Order.OrderStatus.Ready)
                {
                    Console.WriteLine(order);
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("No new Orders");
            }
        }
        public static void ManageOrders(List<Order> orders)
        {
            int count = 0;
            foreach (Order order in orders)
            {
                Console.WriteLine(count++ + ". " + order);
            }
            if (count == 0)
            {
                Console.WriteLine("No Orders");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                return;
            }
            int choice;

            while (true)
            {
                Console.Write("Select order to delete (-1 to return): ");

                if (int.TryParse(Console.ReadLine(), out choice) && choice < orders.Count)
                {
                    if (choice < 0)
                        return;
                    orders.Remove(orders[choice]);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter an order ID.");
                }
            }
        }
    }
}
