using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsAnalysis_Restaurant
{
    abstract public class User
    {
        protected string username;
        protected string password;

        public User(string _username, string _password)
        {
            SetUsername(username);
            SetPassword(password);
        }

        protected void SetUsername(string _username) { username = _username; }
        protected void SetPassword(string _password) { password = _password; }
    }
}
