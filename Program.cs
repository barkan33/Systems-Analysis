using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Transactions;

namespace Systems_Analysis
{
    internal class Program
    {
        static DivingClub correntDivingClub;
        static Diver connectedUser;
        static List<Diver> divePartners = new List<Diver>();
        static Dictionary<string, Diver> users;
        static List<DivingClub> divingClub_DB;
        static Dictionary<string, Country> availableCountrys;
        static void CreateDivingClub_DB()
        {
            divingClub_DB = new List<DivingClub>();
            foreach (DivingClub divingClub in divingClub_DB)
            {
                availableCountrys.Add(divingClub.GetCountry().GetName(), divingClub.GetCountry());
            }
            //TODO
        }
        static void Topic()
        {
            string fName = "";
            string lName = "";
            string diveClub = "";
            if (connectedUser != null)
            {
                fName = connectedUser.GetFirstName();
                lName = connectedUser.GetLastName();
            }
            if (correntDivingClub != null)
            {
                diveClub = correntDivingClub.ToString();
            }

            Console.WriteLine($"User: {fName} {lName}            Dive Club: {diveClub}            Dive-Partners: {divePartners.Count}");
        }
        static void MainMenu()
        {
            Topic();
            Console.WriteLine("Welcome To ProDrive 3000\n========================");
            Console.WriteLine("Select:\n1.Login\n2.Register\n0.Exit");
        }
        static void SecondScreen()
        {
            Console.Clear();
            Topic();
            Console.WriteLine($"Welcome {connectedUser.GetFirstName()},\n\nChoose:\n1) Add Dive\n2) Enter DiveClub\n3) Add Diving Partner/s\n4) Display Diving regulations By Country\n5) Login menu");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid Input");
            }
            bool flag = true;
            while (flag)
            {
                switch (choice)
                {
                    case 1:
                        AddDive();
                        SecondScreen();
                        break;
                    case 2:
                        EnterClub();
                        SecondScreen();
                        break;
                    case 3:
                        AddDivingPartner();
                        SecondScreen();
                        break;
                    case 4:
                        DivingRegulations();
                        SecondScreen();
                        break;
                    case 5:
                        Main();
                        connectedUser = null;
                        return;
                    default:
                        Console.WriteLine("Invalid Input, Try Again");
                        break;

                }
            }
        }

        private static void DivingRegulations()
        {
            if (correntDivingClub != null)
            {
                Console.WriteLine("The country's diving regulation of the club you have chosen: ");
                Console.WriteLine(correntDivingClub.GetCountry());
            }
            else
            {
                while (true)
                {
                    Console.Write("Enter Country:");
                    string countryName = Console.ReadLine();
                    if (availableCountrys.TryGetValue(countryName, out Country country))
                    {
                        Console.WriteLine("Regulation: \n" + country);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("This country is not in the lists");
                        Console.Write("If you want to see the list, enter \"list\" \nOr ");
                    }
                }
            }
        }

        private static void AddDivingPartner()
        {
            bool addMoreParticipants = true;
            while (addMoreParticipants)
            {

                Console.Write("Enter Participant's ID: ");
                string participantId = Console.ReadLine();


                if (users.TryGetValue(participantId, out Diver newParticipant))
                {
                    divePartners.Add(newParticipant);
                }
                else
                {
                    Console.WriteLine("Participant Not Found!");
                }

                Console.Write("Do you want to add another participant? (y/n): ");
                string addMore = Console.ReadLine();
                addMoreParticipants = addMore.ToLower() == "y";
            }
            Console.Write("Do you want to register another participant? (y/n): ");
            string reg = Console.ReadLine();
            addMoreParticipants = reg.ToLower() == "y";
            if (addMoreParticipants)
            {
                divePartners.Add(RegisterTest());
            }
        }

        private static void EnterClub()
        {
            Console.WriteLine("DivingClubs: ");
            DivingClub[] divingClubArr = divingClub_DB.ToArray();
            PrintArray(divingClubArr);
            int index;
            Console.Write("DivingClub index: ");
            while (!int.TryParse(Console.ReadLine(), out index) || index >= divingClubArr.Length)
            {
                Console.WriteLine("Invalid Input for DivingClub index!");
                Console.Write("DivingClub index: ");
            }
            correntDivingClub = divingClubArr[index];
        }
        //TODO Add Equipment to AddDive()
        static void AddDive()
        {
            if (correntDivingClub == null)
            {
                Console.WriteLine("First choose a club! Press any key");
                Console.ReadKey();
                return;
            }
            while (divePartners.Count == 0)
            {
                Console.WriteLine("You need to choose a partner first");
                AddDivingPartner();
            }
            Console.WriteLine("Enter Dive Details:");
            Console.WriteLine("Dive Sites: ");
            DiveSite[] diveSitesArr = correntDivingClub.GetDiveSites().ToArray();
            PrintArray(diveSitesArr);
            int index;
            Console.Write("Site index: ");
            while (!int.TryParse(Console.ReadLine(), out index) || index >= diveSitesArr.Length)
            {
                Console.WriteLine("Invalid Input for Site index!");
                Console.Write("Site index: ");
            }
            DiveSite diveSite = diveSitesArr[index];

            DateOnly date;
            Console.Write("Date (YYYY-MM-DD): ");
            while (!DateOnly.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Invalid Date Format!");
                Console.Write("Date (YYYY-MM-DD): ");
            }

            TimeOnly entryTime;
            Console.Write("Entry Time (HH:MM): ");
            while (!TimeOnly.TryParse(Console.ReadLine(), out entryTime))
            {
                Console.WriteLine("Invalid Time Format!");
                Console.Write("Entry Time (HH:MM): ");
            }

            TimeOnly exitTime;
            Console.Write("Exit Time (HH:MM): ");
            while (!TimeOnly.TryParse(Console.ReadLine(), out exitTime))
            {
                Console.WriteLine("Invalid Time Format!");
                Console.Write("Exit Time (HH:MM): ");
            }

            double waterTemperature;
            Console.Write("Water Temperature: ");
            while (!double.TryParse(Console.ReadLine(), out waterTemperature))
            {
                Console.WriteLine("Invalid Input for Water Temperature!");
                Console.Write("Water Temperature: ");
            }

            double input;
            Console.Write("Enter Tide : 0 = low, 1 = high ");
            while (!double.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Invalid Input for Water Tide!");
                Console.Write("Enter Tide : 0 = low, 1 = high ");
            }
            string waterTide = input == 0 ? "Low Tide" : "High Tide";


            DivingInstructor[] instructors = correntDivingClub.GetDivingInstructors().ToArray();
            Console.WriteLine("Dive Instructors: ");
            PrintArray(instructors);
            Console.Write("Instructor index: ");
            while (!int.TryParse(Console.ReadLine(), out index) || index >= instructors.Length)
            {
                Console.WriteLine("Invalid Input for Site index!");
                Console.Write("Instructor index: ");
            }
            DivingInstructor instructor = instructors[index];


            List<Diver> tempDiverList = divePartners.GetRange(0, divePartners.Count);
            tempDiverList.Add(connectedUser);

            Dive dive = new Dive(diveSite, date, entryTime, exitTime, waterTemperature, waterTide, tempDiverList, instructor, correntDivingClub.GetSignature());
            ///////////////////////            ///////////////////////            ///////////////////////TODO Add Equipment
            correntDivingClub.AddDive(dive);
            connectedUser.AddDiveToLog(dive);
            foreach (Diver diver in divePartners)
            {
                diver.AddDiveToLog(dive);
            }

            Console.WriteLine("Dive added successfully!");
        }


        static void Main()
        {

            //while (true)
            //{
            users = LoadUsers();
            Console.Clear();
            MainMenu();
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid Input");
            }
            bool flag = true;
            while (flag)
            {
                switch (choice)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        flag = !LogIn();
                        break;
                    case 2:
                        RegisterTest();
                        flag = !LogIn();
                        break;
                    default:
                        Console.WriteLine("Invalid Input, Try Again");
                        break;

                }
            }
            SecondScreen();
            //}

        }
        static public bool LogIn()
        {
            int tryCount = 0;
            while (true)
            {
                Console.WriteLine("Enter your ID:");
                string id = Console.ReadLine();

                Console.WriteLine("Enter your password:");
                string password = Console.ReadLine();

                if (users.TryGetValue(id, out Diver user) && user.GetPassword() == password)
                {
                    connectedUser = user;
                    Topic();
                    Console.Clear();
                    Console.WriteLine("Login successful!");
                    return true;
                }
                else
                {
                    Console.WriteLine("The ID or password you entered is incorrect. Please try again.");
                    tryCount++;
                }
                if (tryCount >= 3)
                {
                    return false;
                }
            }
        }
        static Diver RegisterTest()
        {
            Random rand = new Random();
            int num = rand.Next(100000, 1000000);
            string firstName, lastName, id, password, email, dateInput;
            DateTime dateOfBirth;

            firstName = "test";
            lastName = "test";
            password = "test";
            id = num.ToString();
            email = "test@";
            dateInput = "2000-01-01";



            Console.WriteLine("Enter your first name:" + firstName);
            Console.WriteLine("Enter your last name:" + lastName);
            Console.WriteLine("Enter your password (at least 8 characters):" + password);
            Console.WriteLine("Enter your 6-digit ID:" + id);
            if (DateTime.TryParseExact(dateInput, "yyyy-MM-dd", null, DateTimeStyles.None, out dateOfBirth))
            {
                Console.WriteLine("Enter your date of birth (YYYY-MM-DD): " + dateOfBirth.Date.ToString());
            }
            Console.WriteLine("Enter your email:" + email);

            Diver newUser = new Diver(firstName, lastName, id, dateOfBirth, password, email);


            bool isUserExist = users.ContainsKey(id);

            users.Add(id, newUser);
            string jsonString = JsonSerializer.Serialize(newUser);
            File.AppendAllText(@".\users.json", jsonString + Environment.NewLine);

            // Console.Clear();
            // Topic();
            //Console.WriteLine();
            Console.WriteLine(isUserExist ? "A user with that ID already exists." : "Registration successful!");
            //LogIn();
            return newUser;
        }
        static Diver Register()
        {
            string firstName;
            while (true)
            {
                Console.WriteLine("Enter your first name:");
                firstName = Console.ReadLine();
                if (string.IsNullOrEmpty(firstName) || Regex.IsMatch(firstName, @"\d?[!@#$%^&*()_+]"))
                {
                    Console.WriteLine("First name cannot be empty or contain numbers.");
                    continue;
                }

                break;
            }

            string lastName;
            while (true)
            {
                Console.WriteLine("Enter your last name:");
                lastName = Console.ReadLine();
                if (string.IsNullOrEmpty(lastName) || Regex.IsMatch(lastName, @"\d?[!@#$%^&*()_+]"))
                {
                    Console.WriteLine("Last name cannot be empty or contain numbers.");
                    continue;
                }
                break;
            }
            string id;
            while (true)
            {
                Console.WriteLine("Enter your 6-digit ID:");
                id = Console.ReadLine();
                if (id.Length == 6 && int.TryParse(id, out _)) // Check length and numeric
                {
                    break;
                }
                Console.WriteLine("Invalid ID. Please enter a 6-digit number.");
            }

            DateTime dateOfBirth;
            while (true)
            {
                Console.WriteLine("Enter your date of birth (YYYY-MM-DD):");
                string dateInput = Console.ReadLine();

                if (DateTime.TryParseExact(dateInput, "yyyy-MM-dd", null, DateTimeStyles.None, out dateOfBirth))
                {
                    break;
                }
                Console.WriteLine("Invalid date format. Please use YYYY-MM-DD.");
            }

            string password;
            while (true)
            {
                Console.WriteLine("Enter your password (at least 8 characters):");
                password = Console.ReadLine();
                if (!(password.Length >= 8))
                {
                    Console.WriteLine("Password must be at least 8 characters.");
                    continue;
                }
                break;
            }

            string email;
            const string emailRegex = "^[a-zA-Z0-9][a-zA-Z0-9-\\._]+@([a-zA-Z0-9]){2,15}(\\.[a-zA-z]{1,6}){1,2}$";
            while (true)
            {
                Console.WriteLine("Enter your email:");
                email = Console.ReadLine();
                if (!Regex.IsMatch(email, emailRegex))
                {
                    Console.WriteLine("Invalid email format.");
                    continue;
                }
                break;
            }

            Diver newUser = new Diver(firstName, lastName, id, dateOfBirth, password, email);

            bool isUserExist = users.ContainsKey(id);

            users.Add(id, newUser);
            string jsonString = JsonSerializer.Serialize(newUser);
            File.AppendAllText(@".\users.json", jsonString + Environment.NewLine);

            Console.WriteLine(isUserExist ? "A user with that ID already exists." : "Registration successful!");
            return newUser;
        }
        static Dictionary<string, Diver> LoadUsers()
        {
            Dictionary<string, Diver> users = new Dictionary<string, Diver>();

            if (File.Exists("users.json"))
            {
                string[] lines = File.ReadAllLines("users.json");

                foreach (string line in lines)
                {
                    if (!string.IsNullOrEmpty(line) && line != "{}")
                    {
                        Diver user = JsonSerializer.Deserialize<Diver>(line);
                        users.Add(user.GetID(), user);
                    }
                }
            }

            return users;
        }
        static void PrintAllUsers(Dictionary<string, Diver> users)
        {
            if (users.Count == 0)
            {
                Console.WriteLine("No registered users found.");
                return;
            }

            Console.WriteLine("Registered Users:");
            foreach (var user in users.Values)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine($"First Name: {user.GetFirstName()}");
                Console.WriteLine($"Last Name: {user.GetLastName()}");
                Console.WriteLine($"ID: {user.GetID()}");
                Console.WriteLine($"Date of Birth: {user.GetDateOfBirth().ToString("yyyy-MM-dd")}");
                Console.WriteLine($"Email: {user.GetEmail()}");
                Console.WriteLine("--------------------");
            }
        }

        static void PrintArray<T>(T[] list)
        {
            int index = 0;
            foreach (T item in list)
            {
                Console.Write("(" + index + ") ");
                Console.WriteLine(item);
                index++;
            }
        }
    }
}
