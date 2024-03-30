using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systems_Analysis
{
    public class EquipmentItem
    {
        //properties for JSON 
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public string Note { get; private set; }

        public EquipmentItem(string name, int quantity, string note)
        {
            SetName(name);
            SetQuantity(quantity);
            SetNote(note);
        }
        public EquipmentItem(EquipmentItem other)
        {
            SetName(other.GetName());
            SetQuantity(other.GetQuantity());
            SetNote(other.GetNote());
        }
        public string GetName()
        {
            return Name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public int GetQuantity()
        {
            return Quantity;
        }

        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }

        public string GetNote()
        {
            return Note;
        }

        public void SetNote(string note)
        {
            Note = note;
        }
        public override string ToString()
        {
            return $"Name: {Name} ({Quantity})";
        }
    }
}
