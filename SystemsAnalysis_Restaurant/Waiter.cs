using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsAnalysis_Restaurant
{
    public class Waiter : Staff
    {
        public static void CleanTable(Table table)
        {
            table.SetIsOccupied(false);
        }
    }
}
