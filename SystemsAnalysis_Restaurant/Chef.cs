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

    }
}
