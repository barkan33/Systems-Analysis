﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsAnalysis_Restaurant
{
    public class Table
    {
        private int tableNumber;
        private int numberOfSeats;
        private bool isOccupied;
        Order order;

        public Table(int tableNumber, int numberOfSeats)
        {
            SetTableNumber(tableNumber);
            SetNumberOfSeats(numberOfSeats);
            isOccupied = false;
        }
        public void SetOrder(Order order) { this.order = order; }
        public Order GetOrder() { return order; }
        public int GetTableNumber()
        {
            return tableNumber;
        }

        public int GetNumberOfSeats()
        {
            return numberOfSeats;
        }

        public bool IsOccupied()
        {
            return isOccupied;
        }

        public void SetTableNumber(int tableNumber)
        {
            if (int.TryParse(tableNumber.ToString(), out tableNumber))
            {
                this.tableNumber = tableNumber;
            }
            else
            {
                Console.WriteLine("Invalid table number.");
            }
        }

        public void SetNumberOfSeats(int numberOfSeats)
        {
            if (int.TryParse(numberOfSeats.ToString(), out numberOfSeats))
            {
                this.numberOfSeats = numberOfSeats;
            }
            else
            {
                Console.WriteLine("Invalid number of seats.");
            }
        }

        public void SetIsOccupied(bool isOccupied)
        {
            this.isOccupied = isOccupied;
        }
        public override string ToString()
        {
            return $"Table Number: {tableNumber} - {numberOfSeats} Seats";
        }
    }
}
