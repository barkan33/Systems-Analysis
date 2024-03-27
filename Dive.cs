namespace Systems_Analysis
{
    public class Dive
    {
        private DiveSite diveSite;
        private DateOnly date;
        private TimeOnly entryTime;
        private TimeOnly exitTime;
        private double waterTemperature;
        private string waterCondition;
        private List<Diver> participants;
        private DivingInstructor instructor;
        private Signature clubSignature;
        private List<Signature> signatures;

        public Dive(DiveSite diveSite, DateOnly date, TimeOnly entryTime, TimeOnly exitTime, double waterTemperature, string waterCondition, DivingInstructor instructor, Signature clubSignature)
        {
            this.diveSite = diveSite;
            this.date = date;
            this.entryTime = entryTime;
            this.exitTime = exitTime;
            this.waterTemperature = waterTemperature;
            this.waterCondition = waterCondition;
            this.instructor = instructor;
            this.clubSignature = clubSignature;
            participants = new List<Diver>();
            signatures = new List<Signature>();
        }
        public Dive(DiveSite diveSite, DateOnly date, TimeOnly entryTime, TimeOnly exitTime, double waterTemperature, string waterCondition, List<Diver> divers, DivingInstructor instructor, Signature clubSignature)
        {
            this.diveSite = diveSite;
            this.date = date;
            this.entryTime = entryTime;
            this.exitTime = exitTime;
            this.waterTemperature = waterTemperature;
            this.waterCondition = waterCondition;
            this.instructor = instructor;
            this.clubSignature = clubSignature;
            participants = divers;
            signatures = new List<Signature>();
        }
        public void addParticipant(Diver diver)
        {
            participants.Add(diver);
        }
        public void addSignature(Signature signature)
        {
            signatures.Add(signature);
        }
    }
}