using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systems_Analysis
{
    public class DiveSite
    {
        private int code;
        private string description;
        private double perimeter;
        private double depth;
        private string waterType;
        //properties for JSON file

        public int Code { get => code; private set => code = value; }
        public string Description { get => description; private set => description = value; }
        public double Perimeter { get => perimeter; private set => perimeter = value; }
        public double Depth { get => depth; private set => depth = value; }
        public string WaterType { get => waterType; private set => waterType = value; }

        public DiveSite(int code, string description, double perimeter, double depth, string waterType)
        {
            SetName(code);
            SetDescription(description);
            SetPerimeter(perimeter);
            SetDepth(depth);
            SetWaterType(waterType);
        }

        public int GetName() { return code; }

        public void SetName(int code) { this.code = code; }



        public string GetDescription() { return description; }

        public void SetDescription(string description) { this.description = description; }

        public double GetPerimeter() { return perimeter; }

        public void SetPerimeter(double perimeter) { this.perimeter = perimeter; }

        public double GetDepth() { return depth; }

        public void SetDepth(double depth) { this.depth = depth; }

        public string GetWaterType() { return waterType; }

        public void SetWaterType(string waterType) { this.waterType = waterType; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Dive Site Information");
            sb.Append("Code: ");
            sb.AppendLine(code.ToString());
            sb.Append("Description: ");
            sb.AppendLine(description);
            sb.Append("Perimeter: ");
            sb.AppendLine($"{perimeter:F2}");
            sb.Append("Depth: ");
            sb.AppendLine($"{depth:F2}");
            sb.Append("Water Type: ");
            sb.AppendLine(waterType);
            sb.Append('*', 20);
            return sb.ToString();
        }
    }
}
