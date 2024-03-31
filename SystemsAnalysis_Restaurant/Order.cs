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
        private int table;
        private OrderStatus status;

        public enum OrderStatus
        {
            Placed, // Order placed by customer
            Preparing, // Order being prepared by chef
            Ready // Order ready for serving
        }

        public Order(List<Dish> dishes, int table, OrderStatus status)
        {
            this.dishes = dishes;
            this.table = table;
            this.status = status;
        }

        public void SetDishes(List<Dish> dishes)
        {
            this.dishes = dishes;
        }

        public void SetTable(int table)
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

        public int GetTable()
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
        public double GetTotalPrice()
        {
            double price = 0;
            foreach (Dish dish in dishes)
                price += dish.GetDishPrice();

            return price;
        }

        public override string ToString()
        {
            string str = "Table: " + table + "\nDishes: \n";
            foreach (Dish dish in dishes)
                str += dish.GetDishName() + "\n";
            str += "Status: " + status;
            return str;
        }
    }
}
