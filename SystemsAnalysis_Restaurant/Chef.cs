using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsAnalysis_Restaurant
{
    public class Chef : Staff
    {

        public static void PrepareFood(Order order)
        {
            order.SetStatus(Order.OrderStatus.Preparing);
        }
        public static void UpdateOrderStatus(Order order)
        {
            order.SetStatus(Order.OrderStatus.Ready);
        }
        public static new void ViewOrders(List<Order> orders)
        {

            while (true)
            {
                Console.Clear();
                int count = 0;
                foreach (Order order in orders)
                {
                    Console.WriteLine(count++ + ". " + order);
                }
                if (count == 0)
                {
                    Console.WriteLine("No Orders");
                    return;
                }
                Console.Write("Select order to Prepare (-1 to return): ");

                if (int.TryParse(Console.ReadLine(), out int choice) && choice < orders.Count)
                {
                    if (choice < 0)
                    {
                        return;
                    }
                    if (orders[choice].GetStatus() == Order.OrderStatus.Ready)
                    {
                        Console.Write("The food is already ready\nContinue? (y\\n): ");
                        if (char.TryParse(Console.ReadLine().ToLower(), out char ch) && ch == 'y')
                            continue;
                        else
                            return;
                    }
                    if (orders[choice].GetStatus() == Order.OrderStatus.Preparing)
                    {
                        UpdateOrderStatus(orders[choice]);
                    }
                    else
                        PrepareFood(orders[choice]);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter an order ID.");
                }
            }
        }
    }
}
