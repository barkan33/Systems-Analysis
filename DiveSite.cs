using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systems_Analysis
{
    public class DiveSite
    {
        private string name;
        private string address;
        private string description;
        private double perimeter;
        private double depth;
        private string waterType;

        public DiveSite(string name, string address, string description, double perimeter, double depth, string waterType)
        {
            SetName(name);
            SetAddress(address);
            SetDescription(description);
            SetPerimeter(perimeter);
            SetDepth(depth);
            SetWaterType(waterType);
        }
        public string GetName() { return name; }

        public void SetName(string name) { this.name = name; }

        public string GetAddress() { return address; }

        public void SetAddress(string address) { this.address = address; }

        public string GetDescription() { return description; }

        public void SetDescription(string description) { this.description = description; }

        public double GetPerimeter() { return perimeter; }

        public void SetPerimeter(double perimeter) { this.perimeter = perimeter; }

        public double GetDepth() { return depth; }

        public void SetDepth(double depth) { this.depth = depth; }

        public string GetWaterType() { return waterType; }

        public void SetWaterType(string waterType) { this.waterType = waterType; }
    }
}
