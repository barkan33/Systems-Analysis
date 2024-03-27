using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systems_Analysis
{
    public class Rank
    {
        private string description;
        private int requiredDives;
        private DateTime dateReceived;
        private DivingClub issuingClub;
        private string certificateImage;


        public string GetDescription()
        {
            return description;
        }

        public void SetDescription(string description)
        {
            this.description = description;
        }

        public int GetRequiredDives()
        {
            return requiredDives;
        }

        public void SetRequiredDives(int requiredDives)
        {
            this.requiredDives = requiredDives;
        }

        public DateTime GetDateReceived()
        {
            return dateReceived;
        }

        public void SetDateReceived(DateTime dateReceived)
        {
            this.dateReceived = dateReceived;
        }

        public DivingClub GetIssuingClub()
        {
            return issuingClub;
        }

        public void SetIssuingClub(DivingClub issuingClub)
        {
            this.issuingClub = issuingClub;
        }

        public string GetCertificateImage()
        {
            return certificateImage;
        }

        public void SetCertificateImage(string certificateImage)
        {
            this.certificateImage = certificateImage;
        }
    }
}
