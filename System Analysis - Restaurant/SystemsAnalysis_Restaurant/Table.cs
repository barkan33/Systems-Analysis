using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsAnalysis_Restaurant
{
    internal class Table
    {
        private int tableNumber;
        private int numberOfSeats;
        private bool isOccupied;

        public Table(int tableNumber, int numberOfSeats)
        {
            SetTableNumber(tableNumber);
            SetNumberOfSeats(numberOfSeats);
            isOccupied = false;
        }

        public int GetTableNumber()
        {
            return tableNumber;
        }

        public int GetNumberOfSeats()
        {
            return numberOfSeats;
        }

        public bool GetIsOccupied()
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
    }
}
