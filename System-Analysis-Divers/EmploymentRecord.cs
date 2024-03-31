using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systems_Analysis
{
    public class EmploymentRecord
    {
        private string clubName;
        private DateTime startDate;
        private DateTime endDate;
        public EmploymentRecord(DivingClub club, DateTime startDate, DateTime endDate)
        {
            SetClub(club);
            SetStartDate(startDate);
            SetEndDate(endDate);
        }
        public string GetClub()
        {
            return clubName;
        }

        public void SetClub(DivingClub club)
        {
            clubName = club.GetName();
        }

        public DateTime GetStartDate()
        {
            return startDate;
        }

        public void SetStartDate(DateTime startDate)
        {
            this.startDate = startDate;
        }

        public DateTime GetEndDate()
        {
            return endDate;
        }

        public void SetEndDate(DateTime endDate)
        {
            this.endDate = endDate;
        }
    }
}
