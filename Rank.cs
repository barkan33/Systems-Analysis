using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systems_Analysis
{
    public class Rank
    {
        //properties for JSON file
        public string Description { get; private set; }
        public int RequiredDives { get; private set; }
        public DateTime DateReceived { get; private set; }
        public DivingClub IssuingClub { get; private set; }
        public string CertificateImage { get; private set; }

        public string GetDescription()
        {
            return Description;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public int GetRequiredDives()
        {
            return RequiredDives;
        }

        public void SetRequiredDives(int requiredDives)
        {
            RequiredDives = requiredDives;
        }

        public DateTime GetDateReceived()
        {
            return DateReceived;
        }

        public void SetDateReceived(DateTime dateReceived)
        {
            DateReceived = dateReceived;
        }

        public DivingClub GetIssuingClub()
        {
            return IssuingClub;
        }

        public void SetIssuingClub(DivingClub issuingClub)
        {
            IssuingClub = issuingClub;
        }

        public string GetCertificateImage()
        {
            return CertificateImage;
        }

        public void SetCertificateImage(string certificateImage)
        {
            CertificateImage = certificateImage;
        }
    }
}
