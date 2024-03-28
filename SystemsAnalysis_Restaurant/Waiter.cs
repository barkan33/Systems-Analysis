using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsAnalysis_Restaurant
{
    public class Waiter : Staff
    {
        public Waiter(string _username, string _password) : base(_username, _password) { }

        public void ReceiveNotifications() { }
    }
}
