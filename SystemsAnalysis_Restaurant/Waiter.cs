using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsAnalysis_Restaurant
{
    public class Waiter : Staff
    {
        public static void CleanTable(List<Table> tables)
        {
            //Print tables and order status
            int count = 0;
            foreach (Table table in tables)
            {
                if (table.GetOrder() != null)
                    if (table.GetOrder().GetStatus() == Order.OrderStatus.Ready)
                    {
                        Console.WriteLine($"Num: {table.GetTableNumber()} - {table.GetOrder().GetStatus()}");
                        count++;
                    }
            }
            if (count == 0)
            {
                Console.WriteLine("No Ready Tables");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                return;
            }
            int choice;
            //choice table
            do
            {
                Console.Write("Select Table To Clean (-1 to return): ");
            }
            while (!int.TryParse(Console.ReadLine(), out choice));
            if (choice < 0)
            {
                return;
            }
            Table selectedTable = tables.Find(table => table.GetTableNumber() == choice);
            selectedTable.SetIsOccupied(false);

        }
    }
}
