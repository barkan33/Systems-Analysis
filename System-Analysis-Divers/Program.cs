using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Transactions;

namespace Systems_Analysis
{
    internal class Program
    {
        //initialize all the variables
        static Dictionary<string, Diver> users;
        static DivingClub currentDivingClub;
        static Diver connectedUser;
        static List<Diver> divePartners = new List<Diver>();
        static List<DivingClub> divingClubs;
        static Dictionary<string, Country> availableCountrys;
        static List<Country> countries;
        static List<DiveSite> diveSites;
        static List<DivingInstructor> instructors;
        static Random random = new Random();
        static int mainMenuChoice, choice;
        static bool addMoreParticipants;

        //all countries and there regulations
        static Dictionary<string, string> regulations = new Dictionary<string, string>
            {
                { "Australia", "No solo diving allowed. All dives must be supervised by a certified diving instructor." },
                { "Brazil", "All dives must be logged in a dive logbook. Proof of dive experience required for deep dives and wreck dives." },
                { "Canada", "Divers must complete a medical questionnaire before each dive. No diving allowed without proper medical clearance." },
                { "France", "Divers must carry a surface marker buoy (SMB) during all dives. Night diving prohibited without prior authorization." },
                { "Italy", "Divers must complete a mandatory safety stop of at least 3 minutes at the end of each dive. Penalties for exceeding no-decompression limits." },
                { "South Africa", "Divers must carry a surface signaling device (e.g., whistle or inflatable tube) during all dives. Mandatory dive briefing before each dive." },
                { "United States", "All divers must wear a certified diving suit and carry a dive buddy at all times." }            };
        //Some strings for the menu
        const string TITLE = "\t \t \t \t \t******** ProDive 2.0 S&M ********";
        const string MENU = "\t \t \t \t \t Welcome To Our Diving Platform -\n" +
            "All You Need To Do Is Sign Up As A Diver, Choose Your Diving Club,\n" +
            "Choose Your Instructor And Grab Some Equipment And Enjoy The Experience!\n\n" +
            "1. Register As A New Diver.\n" +
            "2. Sign In As Existing Diver.\n" +
            "3. Show Me All Clubs Available.\n" +
            "4. Show Me All Available Countries And There Relative Regulations.\n" +
            "5. Exit Program.";


        //User indicator (Will be updated with the user's code, club and partners)
        static string Topic()
        {
            string userFirstName = connectedUser?.GetFirstName() ?? "";
            string diveClubName = currentDivingClub?.GetName() ?? "";
            int divePartnersCount = divePartners.Count;

            string formattedString = string.Format("\t \t \t User: {0}\t\tDive Club: {1}\t\tDive Partners: {2}", userFirstName, diveClubName, divePartnersCount);
            return formattedString;
        }


        //json handling for users and dives 
        static void LoadUsersFromJson()
        {
            try
            {
                string json = File.ReadAllText(@".\users.json");
                users = JsonSerializer.Deserialize<Dictionary<string, Diver>>(json);
            }
            catch (FileNotFoundException)
            {
                users = new Dictionary<string, Diver>();
            }
            catch (JsonException)
            {
                Console.WriteLine("Error loading user data from JSON file. Using an empty user dictionary.");
                users = new Dictionary<string, Diver>();
            }
        }
        static void SaveUsersToJson()
        {
            try
            {
                string json = JsonSerializer.Serialize(users);
                File.WriteAllText(@".\users.json", json);
                Console.WriteLine("User saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving user data to JSON file: {ex.Message}");
            }
        }

        //Create all countries with their regulations
        static void CreateCountries()
        {
            countries = new List<Country>();
            foreach (KeyValuePair<string, string> entry in regulations)
            {
                Country country = new Country(entry.Key, entry.Value);
                countries.Add(country);
            }
        }

        //create diving clubs
        static void CreateDivingClubs()
        {
            Random random = new Random();
            divingClubs = new List<DivingClub>();
            //some fake data to work with
            const int ARR_LEN = 10;
            string[] names = ["Deep Blue Divers" , "Coral Reef Diving", "Aqua Adventures", "Marine Explorers",
                              "Ocean Quest", "Oceanic Odyssey", "Dive Master Academy", "Seabed Seekers",
                              "Tidal Titans", "Sunken Treasure Divers"];
            string[] addresses = ["123 Ocean Drive", "456 Coral Lane", "789 Reef Road", "1011 Seabed Street",
                                  "1213 Dive Drive", "1415 Oceanic Avenue", "1617 Treasure Trail", "1819 Atlantis Avenue",
                                  "2021 Shipwreck Street", "2223 Dive Drive"];
            string[] contactPersons = ["John Doe", "Jane Doe", "Jack Black", "Jill White", "Jim Brown",
                                       "Jenny Green", "Joe Blue", "Jill Red", "Jack Yellow", "Jill Pink"];
            string[] phoneNumbers = ["+1234567890", "+2345678901", "+3456789012", "+4567890123", "+5678901234",
                                    "+6789012345", "+7890123456", "+8901234567", "+9012345678", "+0123456789" ];

            for (int i = 0; i < ARR_LEN; i++)
            {
                List<DiveSite> sites = new List<DiveSite>();
                sites.Add(diveSites[i + 1]);
                sites.Add(diveSites[i + 2]);
                divingClubs.Add(new DivingClub(names[i], random.Next(123456, 987654).ToString(), contactPersons[i], addresses[i], countries[random.Next(countries.Count)],
                    phoneNumbers[i], $"{names[i].Trim()}@nomail.com", $"{names[i].Trim()}.com", sites));
            }
        }

        //create dive sites
        static void CreateDiveSites()
        {
            diveSites = new List<DiveSite>();
            string[] descriptions =
                    [
                            "Beautiful coral reef", "Sunken shipwreck", "Underwater cave", "Colorful fish",
                         "Giant kelp forest", "Manta ray cleaning station", "Shark feeding site", "Whale migration route",
                            "Seagrass meadow", "Deep ocean trench", "Volcanic underwater vent", "Pristine sandy bottom",
                            "Underwater mountain", "Underwater canyon", "Underwater waterfall",
                            "Coral garden", "Lagoon dive", "Wall dive", "Night dive", "Drift dive"
                    ];

            string[] waterTypes = ["Saltwater", "Freshwater"];

            Random random = new Random();

            for (int i = 0; i < 20; i++)
            {
                string description = descriptions[i % descriptions.Length];
                string waterType = waterTypes[random.Next(2)];

                double perimeter = 100.0 + (random.NextDouble() * (420.23 - 100.0));
                double depth = 15.0 + (random.NextDouble() * (40.0 - 15.0));

                int code = random.Next(101, 987);

                diveSites.Add(new DiveSite(code, description, perimeter, depth, waterType));
            }
        }
        //create diving instructors
        static void CreateDivingInstructors()
        {
            instructors = new List<DivingInstructor>();
            string[] instructorNames = [
                        "John Smith",
                        "Emily Johnson",
                        "Michael Brown",
                        "Sarah Wilson",
                        "David Martinez",
                        "Jennifer Davis",
                        "Christopher Anderson",
                        "Jessica Thompson",
                        "Matthew Garcia",
                        "Amanda Harris"];
            for (int i = 0; i < 5; i++)
            {
                instructors.Add(new DivingInstructor(instructorNames[i], random.Next(18, 60), random.Next(123456, 987654).ToString(), DateTime.Now, "password", $"{instructorNames[i].Trim()}@nomail.com"));
            }

        }








        private static void DivingRegulations()
        {
            if (currentDivingClub != null)
            {
                Console.WriteLine("The country's diving regulation of the club you have chosen: ");
                Console.WriteLine(currentDivingClub.GetCountry());
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
            addMoreParticipants = true;
            while (addMoreParticipants)
            {
                Console.Write("Enter Participant's ID: ");
                PrintAllUsers(users);
                string participantId = Console.ReadLine();

                if (users.TryGetValue(participantId, out Diver newParticipant))
                {
                    if (connectedUser.GetID() == newParticipant.GetID())
                    {
                        Console.WriteLine("You can't select yourself");
                        continue;
                    }
                    divePartners.Add(newParticipant);
                }
                else
                {
                    Console.WriteLine("Participant Not Found!");
                }

                Console.Write("Do you want to add another participant? (y/n): ");
                char response;
                do
                {
                    response = Console.ReadLine().ToLower()[0];
                } while (response != 'y' && response != 'n');

                addMoreParticipants = response == 'y';
            }

            Console.Write("Do you want to register another participant? (y/n): ");
            string reg = Console.ReadLine();
            if (reg.ToLower() == "y")
            {
                divePartners.Add(Register());
            }
        }

        private static DivingInstructor ChooseInstructor()
        {
            Console.WriteLine("Choose an instructor:\n");
            for (int i = 0; i < instructors.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {instructors[i]}");
            }

            int instructorChoice;
            do
            {
                Console.Write("Enter your choice: ");
            } while (!int.TryParse(Console.ReadLine(), out instructorChoice) || instructorChoice < 1 || instructorChoice > instructors.Count);

            DivingInstructor chosenInstructor = new DivingInstructor(instructors[instructorChoice - 1]);
            return chosenInstructor;
        }

        private static DivingClub ChooseClub()
        {
            Console.WriteLine("Choose a country:\n");
            for (int i = 0; i < countries.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {countries[i].GetName()}");
            }

            int countryChoice;
            do
            {
                Console.Write("Enter your choice: ");
            } while (!int.TryParse(Console.ReadLine(), out countryChoice) || countryChoice < 1 || countryChoice > countries.Count);

            string selectedCountryName = countries[countryChoice - 1].GetName();

            Console.WriteLine($"Diving Clubs in {selectedCountryName}:");
            for (int i = 0; i < divingClubs.Count; i++)
            {
                if (divingClubs[i].GetCountry().GetName() == selectedCountryName)
                {
                    Console.WriteLine($"{i + 1}. {divingClubs[i]}");
                }
            }
            do
            {
                Console.Write("Enter Your Choice: ");
            } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > divingClubs.Count);
            return divingClubs[choice - 1];
        }
        private static DiveSite ChooseDiveSite()
        {
            Console.WriteLine($"Diving sites in {currentDivingClub.GetName()}:\n");

            Random random = new Random();

            List<DiveSite> diveList = currentDivingClub.GetDiveSites();

            for (int i = 0; i < diveList.Count; i++)
            {
                Console.WriteLine((i + 1) + ". \n" + diveList[i]);
            }

            int siteChoice;
            do
            {
                Console.Write("Enter your choice: ");
            } while (!int.TryParse(Console.ReadLine(), out siteChoice) || siteChoice < 1 || siteChoice > diveList.Count);

            DiveSite chosenSite = diveList[siteChoice - 1];

            if (chosenSite == null)
            {
                Console.WriteLine("Invalid site choice. Returning the first available site.");
                chosenSite = diveList.FirstOrDefault();
            }

            return chosenSite;
        }

        private static void EnterClub()
        {
            Console.WriteLine("DivingClubs: ");
            for (int i = 0; i < divingClubs.Count; i++)
            {
                Console.WriteLine(i + 1 + ".\n " + divingClubs[i]);
            }
            int index;
            Console.Write("Enter your choice: ");
            while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > divingClubs.Count)
            {
                Console.WriteLine("Invalid Input for DivingClub!");
                Console.Write("Enter your choice: ");
            }
            currentDivingClub = divingClubs[index - 1];
        }
        //TODO Add Equipment to DivePlanWindow()


        static void DivePlanWindow()
        {
            DateOnly date = GetDateInput("Date (YYYY-MM-DD): ");
            TimeOnly entryTime = GetTimeInput("Entry Time (HH:MM): ");
            TimeOnly exitTime = GetTimeInput("Exit Time (HH:MM): ");
            double waterTemperature = GetDoubleInput("Water Temperature: ");
            string waterTide = GetWaterTideInput("Enter Tide : 0 = low, 1 = high ");

            while (currentDivingClub == null)
            {
                Console.WriteLine("Please choose a diving club first.");
                currentDivingClub = ChooseClub();
            }
            DiveSite diveSite = ChooseDiveSite();
            DivingInstructor instructor = ChooseInstructor();

            List<Diver> participants = new List<Diver>(divePartners);
            participants.Add(connectedUser);

            Dive dive = new Dive(diveSite, date, entryTime, exitTime, waterTemperature, waterTide, participants, instructor);
            currentDivingClub.AddDive(dive);
            connectedUser.AddDiveToLog(dive);
            foreach (Diver diver in divePartners)
            {
                diver.AddDiveToLog(dive);
            }

            Console.WriteLine("Dive added successfully!");
        }

        static DateOnly GetDateInput(string prompt)
        {
            DateOnly date;
            do
            {
                Console.Write(prompt);
            } while (!DateOnly.TryParse(Console.ReadLine(), out date));
            return date;
        }

        static TimeOnly GetTimeInput(string prompt)
        {
            TimeOnly time;
            do
            {
                Console.Write(prompt);
            } while (!TimeOnly.TryParse(Console.ReadLine(), out time));
            return time;
        }

        static double GetDoubleInput(string prompt)
        {
            double value;
            do
            {
                Console.Write(prompt);
            } while (!double.TryParse(Console.ReadLine(), out value));
            return value;
        }

        static string GetWaterTideInput(string prompt)
        {
            double input;
            do
            {
                Console.Write(prompt);
            } while (!double.TryParse(Console.ReadLine(), out input) || (input != 0 && input != 1));
            return input == 0 ? "Low Tide" : "High Tide";
        }


        static public bool LogIn()
        {
            int tryCount = 0;
            string id, password;

            while (true)
            {
                Console.WriteLine("\n\t \t \t \t \t****** Registration Section ******");
                Console.WriteLine("Enter your ID:");
                id = Console.ReadLine();

                Console.WriteLine("Enter your password:");
                password = Console.ReadLine();

                if (users.TryGetValue(id, out Diver user) && user.GetPassword() == password)
                {
                    connectedUser = user;
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



            Console.WriteLine("Enter your first code:" + firstName);
            Console.WriteLine("Enter your last code:" + lastName);
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
            LoadUsersFromJson();
            string firstName, lastName, id, password, email;
            string emailRegex = "^[a-zA-Z0-9][a-zA-Z0-9-\\._]+@([a-zA-Z0-9]){2,15}(\\.[a-zA-z]{1,6}){1,2}$";
            DateTime dateOfBirth;
            Console.WriteLine("\n\t \t \t \t \t****** Registration Section ******");
            Console.WriteLine("Enter your first name:");
            while (true)
            {
                firstName = Console.ReadLine();
                if (string.IsNullOrEmpty(firstName) || Regex.IsMatch(firstName, @"[0-9!@#$%^&*()_+]"))
                {
                    Console.WriteLine("First name cannot be empty or contain numbers.");
                    continue;
                }
                break;
            }
            Console.WriteLine("Enter your last name:");
            while (true)
            {
                lastName = Console.ReadLine();
                if (string.IsNullOrEmpty(lastName) || Regex.IsMatch(lastName, @"[0-9!@#$%^&*()_+]"))
                {
                    Console.WriteLine("Last name cannot be empty or contain numbers.");
                    continue;
                }
                break;
            }
            Console.WriteLine("Enter your 6-digit ID:");
            while (true)
            {
                id = Console.ReadLine();
                if (id.Length == 6 && int.TryParse(id, out _))
                {
                    if (users.ContainsKey(id))
                    {
                        Console.WriteLine("User already exists");
                        return null;
                    }
                    break;
                }
                Console.WriteLine("Invalid ID. Please enter a 6-digit number.");
            }
            Console.WriteLine("Enter your date of birth (YYYY-MM-DD):");
            while (true)
            {
                string dateInput = Console.ReadLine();
                if (dateInput.ToLower() == "main") // Check if user wants to go back to Main
                    return null; // Return null to indicate returning to Main
                if (DateTime.TryParseExact(dateInput, "yyyy-MM-dd", null, DateTimeStyles.None, out dateOfBirth))
                {
                    break;
                }
                Console.WriteLine("Invalid date format. Please use YYYY-MM-DD.");
            }
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
            Console.WriteLine("Enter your email:");
            while (true)
            {
                email = Console.ReadLine();
                if (email.ToLower() == "main")
                    return null;
                if (!Regex.IsMatch(email, emailRegex))
                {
                    Console.WriteLine("Invalid email format.");
                    continue;
                }
                break;
            }

            Diver newUser = new Diver(firstName, lastName, id, dateOfBirth, password, email);
            users.Add(id, newUser);

            SaveUsersToJson();

            return newUser;
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
                if (connectedUser.GetID() == user.GetID())
                {
                    continue;
                }
                Console.WriteLine("--------------------");
                Console.WriteLine($"First Name: {user.GetFirstName()}");
                Console.WriteLine($"Last Name: {user.GetLastName()}");
                Console.WriteLine($"ID: {user.GetID()}");
                Console.WriteLine($"Date of Birth: {user.GetDateOfBirth().ToString("yyyy-MM-dd")}");
                Console.WriteLine($"Email: {user.GetEmail()}");
                Console.WriteLine("--------------------");
            }
        }

        static void SecondScreen()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(TITLE + "\n" + Topic());
                //top user indicator
                string secondMenu = $"Welcome {connectedUser.GetFirstName()},\n1. Plan Your Dive\n2. Enter DiveClub\n3. Add Diving Partner/s\n4. Display Diving regulations By Country\n5. Logout and return Main Menu";
                if (connectedUser.GetDiveLog().Count >= 1)
                {
                    secondMenu += "\n6. Show Dive History";
                }
                Console.WriteLine(secondMenu);

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid Input");
                }



                switch (choice)
                {
                    case 1:
                        DivePlanWindow();
                        break;
                    case 2:
                        EnterClub();
                        break;
                    case 3:
                        AddDivingPartner();
                        break;
                    case 4:
                        foreach (Country country in countries) { Console.WriteLine(country); }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case 5:
                        connectedUser = null;
                        return;
                    case 6:
                        //DIVE HISTORY 
                        break;
                    default:
                        Console.WriteLine("Invalid Input, Try Again");
                        break;
                }
            }
        }
        static void Main()
        {
            //Init
            users = new Dictionary<string, Diver>();
            LoadUsersFromJson();
            CreateCountries();
            CreateDiveSites();
            CreateDivingClubs();
            CreateDivingInstructors();

            //Main loop
            while (true)
            {
                //titles + menu
                Console.Clear();
                Console.WriteLine(TITLE + "\n" + Topic());

                Console.WriteLine(MENU);
                do
                {

                } while (!int.TryParse(Console.ReadLine(), out mainMenuChoice));
                switch (mainMenuChoice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine(TITLE + "\n" + Topic());
                        Register();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine(TITLE + "\n" + Topic());
                        if (LogIn())
                        {
                            SecondScreen();
                        }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();

                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine(TITLE + "\n" + Topic());
                        foreach (DivingClub club in divingClubs)
                        {
                            Console.WriteLine(club);
                        }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();

                        break;
                    case 4:
                        //Console.Clear();
                        //Console.WriteLine(TITLE + "\n" + Topic());
                        foreach (Country country in countries) { Console.WriteLine(country); }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();

                        break;
                    case 5:
                        return;
                    default:
                        //Console.Clear();
                        //Console.WriteLine(TITLE + "\n" + Topic());
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }

        }
    }
}
