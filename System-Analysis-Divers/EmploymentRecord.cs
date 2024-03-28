using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systems_Analysis
{
    public class EmploymentRecord
    {
        private DivingClub club;
        private DateTime startDate;
        private DateTime endDate;
        public EmploymentRecord(DivingClub club, DateTime startDate, DateTime endDate)
        {
            SetClub(club);
            SetStartDate(startDate);
            SetEndDate(endDate);
        }
        public DivingClub GetClub()
        {
            return club;
        }

        public void SetClub(DivingClub club)
        {
            this.club = club;
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
