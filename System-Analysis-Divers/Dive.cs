using System.Text;

namespace Systems_Analysis
{
    public class Dive
    {
        //properties for JSON file
        public DiveSite DiveSite { get; private set; }
        public string DivingClubName { get; private set; }
        public DateOnly Date { get; private set; }
        public TimeOnly EntryTime { get; private set; }
        public TimeOnly ExitTime { get; private set; }
        public double WaterTemperature { get; private set; }
        public string WaterCondition { get; private set; }
        public Dictionary<string, List<EquipmentItem>> ParticipantsAndEquipment { get; private set; }
        public string Instructor { get; private set; }
        public Signature ClubSignature { get; private set; }
        public List<Signature> Signatures { get; private set; }

        //builder recieving all except participants(creating new empty list) and signatures(creating new empty list)
        public Dive(DiveSite diveSite, DivingClub divingClub, DateOnly date, TimeOnly entryTime, TimeOnly exitTime, double waterTemperature, string waterCondition, DivingInstructor instructor, Signature clubSignature)
        {
            DiveSite = diveSite;
            DivingClubName = divingClub.GetName();
            Date = date;
            EntryTime = entryTime;
            ExitTime = exitTime;
            WaterTemperature = waterTemperature;
            WaterCondition = waterCondition;
            Instructor = instructor.GetFirstName() + " " + instructor.GetLastName();
            ClubSignature = clubSignature;
            ParticipantsAndEquipment = new Dictionary<string, List<EquipmentItem>>();
            Signatures = new List<Signature>();
        }
        //builder recieving all except signatures(creating new empty list)
        public Dive(DiveSite diveSite, DivingClub divingClub, DateOnly date, TimeOnly entryTime, TimeOnly exitTime, double waterTemperature, string waterCondition, List<Diver> divers, DivingInstructor instructor)
        {
            DiveSite = diveSite;
            DivingClubName = divingClub.GetName();
            Date = date;
            EntryTime = entryTime;
            ExitTime = exitTime;
            WaterTemperature = waterTemperature;
            WaterCondition = waterCondition;
            Instructor = instructor.GetFirstName() + " " + instructor.GetLastName();
            ParticipantsAndEquipment = new Dictionary<string, List<EquipmentItem>>();
            foreach (Diver diver in divers)
            {
                ParticipantsAndEquipment.Add(diver.GetFirstName() + " " + diver.GetLastName(), diver.GetEquipment());
            }
            Signatures = new List<Signature>();
        }

        public new Dictionary<string, List<EquipmentItem>> GetParticipants() { return ParticipantsAndEquipment; }
        public DiveSite GetDiveSite() { return DiveSite; }
        public string GetDivingClub() { return DivingClubName; }
        public string GetInstructor() { return Instructor; }
        public void AddParticipant(Diver diver)
        {
            ParticipantsAndEquipment.Add(diver.GetFirstName() + " " + diver.GetLastName(), diver.GetEquipment());

        }
        public void AddSignature(Signature signature)
        {
            Signatures.Add(signature);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Dive Information");
            sb.Append("Dive Site: ");
            sb.AppendLine(DiveSite.GetDescription());
            sb.Append("Date: ");
            sb.AppendLine(Date.ToString());
            sb.Append("Entry Time: ");
            sb.AppendLine(EntryTime.ToString());
            sb.Append("Exit Time: ");
            sb.AppendLine(ExitTime.ToString());
            sb.Append("Water Temperature: ");
            sb.AppendLine(WaterTemperature.ToString());//TODO maybe ${WaterTemperature:F2}
            sb.Append("Water Condition: ");
            sb.AppendLine(WaterCondition);
            sb.Append("Instructor: ");
            sb.AppendLine(Instructor);
            sb.Append("Club Signature: ");
            sb.AppendLine(ClubSignature.ToString());
            sb.Append("Participants: ");
            foreach (var item in ParticipantsAndEquipment)
            {
                sb.AppendLine(item.Key);
            }
            sb.Append("Signatures: ");
            foreach (Signature signature in Signatures)
            {
                sb.AppendLine(signature.ToString());
            }
            sb.Append('*', 20);
            return sb.ToString();
        }
    }
}