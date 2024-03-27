using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systems_Analysis
{
    public class EquipmentItem
    {
        private string name;
        private int quantity;
        private string note;
        public EquipmentItem(string name, int quantity, string note)
        {
            SetName(name);
            SetQuantity(quantity);
            SetNote(note);
        }
        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public int GetQuantity()
        {
            return quantity;
        }

        public void SetQuantity(int quantity)
        {
            this.quantity = quantity;
        }

        public string GetNote()
        {
            return note;
        }

        public void SetNote(string note)
        {
            this.note = note;
        }
    }
}
