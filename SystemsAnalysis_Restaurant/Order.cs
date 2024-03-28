using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsAnalysis_Restaurant
{
    public class Order
    {
        private List<Dish> dishes;
        private Table table;
        private OrderStatus status;

        public enum OrderStatus
        {
            Placed, // Order placed by customer
            Preparing, // Order being prepared by chef
            Ready // Order ready for serving
        }

        public Order(List<Dish> dishes, Table table, OrderStatus status)
        {
            this.dishes = dishes;
            this.table = table;
            this.status = status;
        }

        public void SetDishes(List<Dish> dishes)
        {
            this.dishes = dishes;
        }

        public void SetTable(Table table)
        {
            this.table = table;
        }

        public void SetStatus(OrderStatus status)
        {
            this.status = status;
        }

        public List<Dish> GetDishes()
        {
            return dishes;
        }

        public Table GetTable()
        {
            return table;
        }

        public OrderStatus GetStatus()
        {
            return status;
        }

        public void RemoveDish(Dish dish)
        {
            dishes.Remove(dish);
        }

        public void UpdateStatus(OrderStatus status)
        {
            SetStatus(status);
        }

        public void AddDish(Dish dish)
        {
            dishes.Add(dish);
        }



    }
}
