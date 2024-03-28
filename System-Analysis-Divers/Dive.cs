namespace Systems_Analysis
{
    public class Dive
    {
        //properties for JSON file
        public DiveSite DiveSite { get; private set; }
        public DateOnly Date { get; private set; }
        public TimeOnly EntryTime { get; private set; }
        public TimeOnly ExitTime { get; private set; }
        public double WaterTemperature { get; private set; }
        public string WaterCondition { get; private set; }
        public List<Diver> Participants { get; private set; }
        public DivingInstructor Instructor { get; private set; }
        public Signature ClubSignature { get; private set; }
        public List<Signature> Signatures { get; private set; }

        //builder recieving all except participants(creating new empty list) and signatures(creating new empty list)
        public Dive(DiveSite diveSite, DateOnly date, TimeOnly entryTime, TimeOnly exitTime, double waterTemperature, string waterCondition, DivingInstructor instructor, Signature clubSignature)
        {
            DiveSite = diveSite;
            Date = date;
            EntryTime = entryTime;
            ExitTime = exitTime;
            WaterTemperature = waterTemperature;
            WaterCondition = waterCondition;
            Instructor = instructor;
            ClubSignature = clubSignature;
            Participants = new List<Diver>();
            Signatures = new List<Signature>();
        }
        //builder recieving all except signatures(creating new empty list)
        public Dive(DiveSite diveSite, DateOnly date, TimeOnly entryTime, TimeOnly exitTime, double waterTemperature, string waterCondition, List<Diver> divers, DivingInstructor instructor, Signature clubSignature)
        {
            DiveSite = diveSite;
            Date = date;
            EntryTime = entryTime;
            ExitTime = exitTime;
            WaterTemperature = waterTemperature;
            WaterCondition = waterCondition;
            Instructor = instructor;
            ClubSignature = clubSignature;
            Participants = divers;
            Signatures = new List<Signature>();
        }


        public void AddParticipant(Diver diver)
        {
            Participants.Add(diver);
        }
        public void AddSignature(Signature signature)
        {
            Signatures.Add(signature);
        }
    }
}