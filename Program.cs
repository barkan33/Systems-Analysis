namespace Systems_Analysis
{
    internal class Program
    {
        static string connectedUser, diveClub;
        static int divePartners;
        static void Main(string[] args)
        {
            Console.WriteLine($"User: {connectedUser}            Dive Club: {diveClub}            Dive-Partners: {divePartners}");
            Console.WriteLine("Welcome To ProDrive 3000\n========================");
            Console.WriteLine("Select:\n1.Login\n2.Register0.Exit");
            int choice;
            while (int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid Input");
            }
            switch (choice)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    LogIn();
                    break;
                case 2:
                    Register();
                    break;

            }
        }
        static public void LogIn()
        {

        }
        static public void Register()
        {

        }
    }
}
