using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsAnalysis_Restaurant
{
    public class Chef : Staff
    {

        public void PrepareFood(Order order)
        {
            order.SetStatus(Order.OrderStatus.Preparing);
        }
        public void UpdateOrderStatus(Order order)
        {
            order.SetStatus(Order.OrderStatus.Ready);
        }

    }
}
