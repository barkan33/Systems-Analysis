using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SystemsAnalysis_Restaurant
{
    public class Dish
    {
        private int dishID;
        private string dishName;
        private string dishDescription;
        private double dishPrice;

        public Dish(int dishID, string dishName, string dishDescription, double dishPrice)
        {
            SetDishID(dishID);
            SetDishName(dishName);
            SetDishDescription(dishDescription);
            SetDishPrice(dishPrice);
        }

        public void SetDishID(int dishID)
        {
            if (int.TryParse(dishID.ToString(), out int result))
            {
                this.dishID = result;
            }
            else
            {
                throw new Exception("Invalid dish ID");
            }
        }
        public int GetDishID() { return dishID; }
        public void SetDishName(string dishName) { this.dishName = dishName; }
        public string GetDishName() { return dishName; }
        public void SetDishDescription(string dishDescription) { this.dishDescription = dishDescription; }
        public string GetDishDescription() { return dishDescription; }
        public void SetDishPrice(double dishPrice)
        {
            if (double.TryParse(dishPrice.ToString(), out double result))
            {
                this.dishPrice = result;
            }
            else
            {
                throw new Exception("Invalid dish price");
            }
        }
        public double GetDishPrice() { return dishPrice; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(new string('*', 40));

            stringBuilder.AppendLine($"* Name: {dishName}");

            stringBuilder.AppendLine($"* Description: {dishDescription}");

            stringBuilder.AppendLine($"* Price: ${dishPrice:F2}");

            stringBuilder.Append(new string('*', 40));

            return stringBuilder.ToString();
        }
        public string GetDetails()
        {
            return $"{GetDishName()} - ${GetDishPrice():F2}";
        }

    }
}
