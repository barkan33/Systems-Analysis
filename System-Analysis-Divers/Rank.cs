namespace Systems_Analysis
{
    public class Rank
    {
        //properties for JSON file
        public int Description { get; set; }
        //public int RequiredDives { get; private set; }
        public DateTime DateReceived { get; set; }

        public string DivingClub { get; set; }
        public string CertificateImage { get; set; }

        public string GetDescription()
        {
            switch (Description)
            {
                case 0:
                    return "One Star";
                case 1:
                    return "Two Stars";
                case 2:
                    return "InstructorAssistant";
                case 3:
                    return "Instructor";
                default:
                    return "";
            }
        }
        public Rank()
        {

        }

        public Rank(int description, string clubName)
        {
            while (description < 0 || description > 3)
            {
                do
                {
                    Console.WriteLine("Invalid Rank (0-3)");
                } while (!int.TryParse(Console.ReadLine(), out description));
            }
            SetDescription(description);
            SetDateReceived(DateTime.Now);
            SetIssuingClub(clubName);
        }
        public void SetDescription(int description)
        {
            Description = description;
        }

        //public int GetRequiredDives()
        //{
        //    return RequiredDives;
        //}

        //public void SetRequiredDives(int requiredDives)
        //{
        //    RequiredDives = requiredDives;
        //}

        public DateTime GetDateReceived()
        {
            return DateReceived;
        }

        public void SetDateReceived(DateTime dateReceived)
        {
            DateReceived = dateReceived;
        }

        public string GetIssuingClub()
        {
            return DivingClub;
        }

        public void SetIssuingClub(string clubName)
        {
            DivingClub = clubName;
        }

        public string GetCertificateImage()
        {
            return CertificateImage;
        }

        public void SetCertificateImage(string certificateImage)
        {
            CertificateImage = certificateImage;
        }
        public override string ToString()
        {
            return $"DivingClub: {DivingClub} - {Description}";
        }
    }
}
