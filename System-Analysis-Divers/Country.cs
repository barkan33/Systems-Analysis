using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systems_Analysis
{
    public class Country
    {
        private string name;
        private string divingRegulation;
        public Country(string name, string divingRegulation)
        {
            SetName(name);
            SetDivingRegulation(divingRegulation);
        }
        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetDivingRegulation()
        {
            return divingRegulation;
        }

        public void SetDivingRegulation(string divingRegulation)
        {
            this.divingRegulation = divingRegulation;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("Country Information");
            sb.Append("Country: ");
            sb.AppendLine(name);
            sb.Append("Diving Regulation: ");
            sb.AppendLine(divingRegulation);
            sb.Append('*', 20);
            return sb.ToString();
        }
    }
}
