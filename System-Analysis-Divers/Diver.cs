using System.Text;

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
        public List<Dive> DiveLog { get; set; }
        //public List<EquipmentItem> Equipment { get; private set; }
        public List<Rank> Ranks { get; set; }

        public Diver(string firstName, string lastName, string id, DateTime dateOfBirth, string password, string email)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetID(id);
            SetDateOfBirth(dateOfBirth);
            SetPassword(password);
            SetEmail(email);
            DiveLog = new List<Dive>();
            //Equipment = new List<EquipmentItem>();
            Ranks = new List<Rank>();
        }
        public Diver CreateDiverCopy()
        {
            // Create a new Diver object with the same data
            Diver newDiver = new Diver(GetFirstName(), GetLastName(), GetID(), GetDateOfBirth(), GetPassword(), GetEmail());

            newDiver.DiveLog = DiveLog;
            newDiver.Ranks = Ranks;


            //foreach (EquipmentItem item in Equipment)
            //{
            //    newDiver.Equipment.Add(new EquipmentItem(item)); // Assuming EquipmentItem has a copy constructor
            //}

            return newDiver;
        }
        private void SetFirstName(string firstName) { FirstName = firstName; }
        public void SetLastName(string lastName) { LastName = lastName; }//Private
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
        public void SetDiveLog(List<Dive> diveLog) { DiveLog = diveLog; }
        public void AddDiveToLog(Dive dive) { DiveLog.Add(dive); }

        //public List<EquipmentItem> GetEquipment() { return Equipment; }
        //public void SetEquipment(List<EquipmentItem> equipment) { Equipment = equipment; }

        public List<Rank> GetRanks() { return Ranks; }
        public void SetRanks(List<Rank> ranks) { Ranks = ranks; }

        public Signature SignDive()
        {
            string fullName = $"{FirstName} {LastName}";
            return new Signature(fullName, DateTime.Now);
        }
        //public void AddEquipmentItem(EquipmentItem item) { Equipment.Add(item); }
        public void AddRank(Rank rank) { Ranks.Add(rank); }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("**************************************************");
            sb.AppendLine($"Diver: {FirstName} {LastName} *");
            sb.AppendLine("**************************************************");
            sb.AppendLine($"ID: {Id}");
            sb.AppendLine($"Date of Birth: {DateOfBirth.ToShortDateString()}");
            sb.AppendLine($"Email: {Email}");
            sb.AppendLine($"Rank: \n{RanksListToString(Ranks)}");
            sb.AppendLine("**************************************************");
            return sb.ToString();
        }
        private string RanksListToString(List<Rank> ranks)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Rank rank in ranks)
            {
                sb.AppendLine(rank.ToString());

            }
            return sb.ToString();
        }

        //public string GetEquipmentToString()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    foreach (EquipmentItem item in Equipment)
        //    {
        //        sb.Append(item.ToString() + ", ");
        //    }
        //    return sb.ToString();
        //}
    }
}
