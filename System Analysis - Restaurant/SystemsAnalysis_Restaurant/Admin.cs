using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsAnalysis_Restaurant
{
    internal class Admin : User
    {
        public Admin(string _username, string _password) : base(_username, _password) { }
        public void ConfigureSystem() { }
        public void ManageUsers() { }
        public void GenerateReports() { }
    }
}
