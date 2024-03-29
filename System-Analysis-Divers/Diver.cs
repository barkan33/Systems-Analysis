using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systems_Analysis
{

    public class Diver
    {
        //properties for JSON file
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Id { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public List<Dive> DiveLog { get; private set; }
        public List<EquipmentItem> Equipment { get; private set; }
        public List<Rank> Ranks { get; private set; }

        public Diver(string firstName, string lastName, string id, DateTime dateOfBirth, string password, string email)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetID(id);
            SetDateOfBirth(dateOfBirth);
            SetPassword(password);
            SetEmail(email);
            DiveLog = new List<Dive>();
            Equipment = new List<EquipmentItem>();
            Ranks = new List<Rank>();
        }

        private void SetFirstName(string firstName) { FirstName = firstName; }
        private void SetLastName(string lastName) { LastName = lastName; }
        private void SetID(string id) { Id = id; }
        private void SetDateOfBirth(DateTime dateOfBirth) { DateOfBirth = dateOfBirth; }
        private void SetPassword(string password) { Password = password; }
        private void SetEmail(string email) { Email = email; }
        public string GetLastName() { return LastName; }
        public string GetFirstName() { return FirstName; }
        public string GetID() { return Id; }
        public DateTime GetDateOfBirth() { return DateOfBirth; }
        public string GetPassword() { return Password; }
        public string GetEmail() { return Email; }


        public List<Dive> GetDiveLog() { return DiveLog; }
        public void AddDiveToLog(Dive dive) { DiveLog.Add(dive); }

        public List<EquipmentItem> GetEquipment() { return Equipment; }
        public void SetEquipment(List<EquipmentItem> equipment) { Equipment = equipment; }

        public List<Rank> GetRanks() { return Ranks; }
        public void SetRanks(List<Rank> ranks) { Ranks = ranks; }

        public void SignDive(string diverName) { /* Implementation */ }
        public void AddEquipmentItem(EquipmentItem item) { Equipment.Add(item); }
        public void AddRank(Rank rank) { Ranks.Add(rank); }
    }
}
