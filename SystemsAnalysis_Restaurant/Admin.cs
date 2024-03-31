using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SystemsAnalysis_Restaurant
{
    public class Admin
    {
        private static string username = "password";
        private static string password = "username";

        public static bool Login(string user, string pass)
        {
            return user == username && pass == password;
        }
        public static void UpdateSomethingInDB()
        {
            Console.WriteLine("DataBase Updated");
        }
    }
}
