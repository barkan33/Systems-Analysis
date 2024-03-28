using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsAnalysis_Restaurant
{
    public class Order
    {
        private Customer customer;
        private List<Dish> dishes;
        private Table table;
        private int status;

        public Order(Customer customer, List<Dish> dishes, Table table, int status)
        {
            this.customer = customer;
            this.dishes = dishes;
            this.table = table;
            this.status = status;
        }

        public void SetCustomer(Customer customer)
        {
            this.customer = customer;
        }
        public void SetDishes(List<Dish> dishes)
        {
            this.dishes = dishes;
        }

        public void SetTable(Table table)
        {
            this.table = table;
        }

        public void SetStatus(int status)
        {
            if (status == 1 || status == 2 || status == 3)
            {
                this.status = status;
            }
            else
            {
                Console.WriteLine("Invalid status");
            }
        }

        public Customer GetCustomer()
        {
            return customer;
        }

        public List<Dish> GetDishes()
        {
            return dishes;
        }

        public Table GetTable()
        {
            return table;
        }

        public int GetStatus()
        {
            return status;
        }

        public void RemoveDish(Dish dish)
        {
            dishes.Remove(dish);
        }

        public void UpdateStatus(int status)
        {
            SetStatus(status);
        }

        public void AddDish(Dish dish)
        {
            dishes.Add(dish);
        }



    }
}
