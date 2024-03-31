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
        public Dictionary<string, Rank> Ranks { get; set; }

        public Diver(string firstName, string lastName, string id, DateTime dateOfBirth, string password, string email)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetID(id);
            SetDateOfBirth(dateOfBirth);
            SetPassword(password);
            SetEmail(email);
            DiveLog = new List<Dive>();
            Ranks = new Dictionary<string, Rank>();
        }
        public Diver CreateDiverCopy()
        {
            // Create a new Diver object with the same data
            Diver newDiver = new Diver(GetFirstName(), GetLastName(), GetID(), GetDateOfBirth(), GetPassword(), GetEmail());

            newDiver.DiveLog = DiveLog;
            newDiver.Ranks = Ranks;

            return newDiver;
        }
        private void SetFirstName(string firstName) { FirstName = firstName; }
        private void SetLastName(string lastName) { LastName = lastName; }
        private void SetID(string id) { Id = id; }
        private void SetDateOfBirth(DateTime dateOfBirth) { DateOfBirth = dateOfBirth; }
        private void SetPassword(string password) { Password = password; }
        private void SetEmail(string email) { Email = email; }
        public void SetDiveLog(List<Dive> diveLog) { DiveLog = diveLog; }
        public void SetRanks(Dictionary<string, Rank> ranks) { Ranks = ranks; }
        public string GetLastName() { return LastName; }
        public string GetFirstName() { return FirstName; }
        public string GetID() { return Id; }
        public DateTime GetDateOfBirth() { return DateOfBirth; }
        public string GetPassword() { return Password; }
        public string GetEmail() { return Email; }
        public List<Dive> GetDiveLog() { return DiveLog; }
        public Dictionary<string, Rank> GetRanks() { return Ranks; }

        public void AddDiveToLog(Dive dive) { DiveLog.Add(dive); }



        public Signature SignDive()
        {
            string fullName = $"{FirstName} {LastName}";
            return new Signature(fullName, DateTime.Now);
        }
        public void AddRank(Rank rank)
        {
            string club = rank.GetIssuingClub();
            if (Ranks.ContainsKey(club))
            {
                Ranks[club] = rank;
            }
            else
                Ranks.Add(rank.GetIssuingClub(), rank);

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("**************************************************");
            sb.AppendLine($"Diver: {FirstName} {LastName} *");
            sb.AppendLine("**************************************************");
            sb.AppendLine($"ID: {Id}");
            sb.AppendLine($"Date of Birth: {DateOfBirth.ToShortDateString()}");
            sb.AppendLine($"Email: {Email}");
            sb.AppendLine($"Rank: \n{RanksDictionaryToString(Ranks)}");
            sb.AppendLine("**************************************************");
            return sb.ToString();
        }
        private string RanksDictionaryToString(Dictionary<string, Rank> ranks)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var rank in ranks)
            {
                sb.AppendLine(rank.Key + " - " + rank.Value.GetDescription());
            }
            return sb.ToString();
        }
    }
}
