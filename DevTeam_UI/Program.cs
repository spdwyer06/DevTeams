using DevTeam_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeam_UI
{
    class Program
    {
        private static DeveloperRepo _devRepo = new DeveloperRepo();
        private static DevTeamRepo _devTeamRepo = new DevTeamRepo();

        static void Main(string[] args)
        {
            SeedData();
            MainMenu();
        }

        static void MainMenu()
        {
            Console.Clear();

            Console.WriteLine("Please select a number from the given options: \n" +
                "1) Add A Developer \n" +
                "2) View All Developers \n" +
                "3) View All Developers Needing Pluralsight Access \n" +
                "4) Update A Developer \n" +
                "5) Remove A Developer \n" +
                "6) Create A Team \n" +
                "7) View All Teams \n" +
                "8) View All Developers In A Team \n" +
                "9) Add A Developer To A Team \n" +
                "10) Remove A Developer From A Team \n" +
                "11) Update A Team Name \n" +
                "12) Remove A Team \n" +
                "13) Exit Application");

            var mainMenuSelection = int.Parse(Console.ReadLine());
            MainMenuSelection(mainMenuSelection);
        }

        static void MainMenuSelection(int menuSelection)
        {
            switch (menuSelection)
            {
                case 1:
                    Console.Clear();
                    AddDeveloper();
                    MainMenu();
                    break;
                case 2:
                    Console.Clear();
                    ViewAllDevs();
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 3:
                    Console.Clear();
                    ViewDevsNeedingPluralsight();
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 4:
                    Console.Clear();
                    UpdateDev();
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 5:
                    Console.Clear();
                    DeleteDev();
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 6:
                    Console.Clear();
                    CreateDevTeam();
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 7:
                    Console.Clear();
                    ViewAllDevTeams();
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 8:
                    Console.Clear();
                    ViewDevTeamMembers();
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 9:
                    Console.Clear();
                    AddDevToTeam();
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 10:
                    Console.Clear();
                    RemoveDevFromTeam();
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 11:
                    Console.Clear();
                    UpdateDevTeamName();
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 12:
                    Console.Clear();
                    DeleteDevTeam();
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 13:
                    Console.WriteLine("Goodbye! Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Please enter a valid menu option. Press any key to continue...");
                    Console.ReadKey();
                    MainMenu();
                    break;
            }
        }

        static void AddDeveloper()
        {
            var newDev = new Developer();

            Console.Write("Enter The Developer Id Number: ");
            newDev.Id = int.Parse(Console.ReadLine());

            Console.Write("Enter The Developer's First Name: ");
            newDev.FirstName = Console.ReadLine();

            Console.Write("Enter The Developer's Last Name: ");
            newDev.LastName = Console.ReadLine();

            bool getAccess = true;
            while (getAccess)
            {
                Console.Write("Does The Developer Have Pluralsight Access (y/n)?: ");
                var hasAccess = Console.ReadLine().ToLower();
                if (hasAccess == "y")
                {
                    newDev.HasPluralsightAccess = true;
                    getAccess = false;
                }
                else if (hasAccess == "n")
                {
                    newDev.HasPluralsightAccess = false;
                    getAccess = false;
                }
                else
                    Console.Write("Please enter a valid option (y/n)...");
            }

            _devRepo.CreateDeveloper(newDev);

        }

        static void ViewAllDevs()
        {
            List<Developer> devs = _devRepo.GetAllDevepors();

            foreach (var dev in devs)
            {
                Console.WriteLine($"Id: {dev.Id}     First Name: {dev.FirstName}     Last Name: {dev.LastName}");
            }
        }

        static void ViewDevsNeedingPluralsight()
        {
            var devs = _devRepo.GetAllDevepors();

            foreach (var dev in devs)
            {
                if (dev.HasPluralsightAccess == false)
                {
                    Console.WriteLine($"Id: {dev.Id} First Name: {dev.FirstName} Last Name: {dev.LastName}");
                }
            }
        }

        static void UpdateDev()
        {
            ViewAllDevs();

            Console.Write("Enter The Id Number Of The Developer You Would Like To Update: ");
            var devId = int.Parse(Console.ReadLine());

            var updatedDev = new Developer();

            Console.Write("Enter The Developer's First Name: ");
            updatedDev.FirstName = Console.ReadLine();

            Console.Write("Enter The Developer's Last Name: ");
            updatedDev.LastName = Console.ReadLine();

            bool getAccess = true;
            while (getAccess)
            {
                Console.Write("Does The Developer Have Pluralsight Access (y/n)?: ");
                var hasAccess = Console.ReadLine().ToLower();
                if (hasAccess == "y")
                {
                    updatedDev.HasPluralsightAccess = true;
                    getAccess = false;
                }
                else if (hasAccess == "n")
                {
                    updatedDev.HasPluralsightAccess = false;
                    getAccess = false;
                }
                else
                    Console.Write("Please enter a valid option (y/n)...");
            }

            var wasUpdated = _devRepo.UpdateDeveloperById(devId, updatedDev);

            if (wasUpdated)
            {
                Console.WriteLine("Developer Successfully Updated! \n" +
                    "Press any key to continue...");
                Console.ReadKey();
                //Console.Clear();
                //Main();
            }
            else
            {
                Console.WriteLine("Oops, something went wrong! \n" +
                    "Press any key to continue...");
                Console.ReadKey();
                //Console.Clear();
                //Main();
            }
        }

        static void DeleteDev()
        {
            ViewAllDevs();

            Console.Write("Enter The Id Number Of The Developer You Would Like To Remove: ");
            var devId = int.Parse(Console.ReadLine());

            var wasDeleted = _devRepo.DeleteDeveloperById(devId);

            if (wasDeleted)
            {
                Console.WriteLine("Developer Successfully Deleted! \n" +
                    "Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                MainMenu();
            }
            else
            {
                Console.WriteLine("Oops, something went wrong! \n" +
                    "Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                MainMenu();
            }
        }

        static void CreateDevTeam()
        {
            var newDevTeam = new DevTeam();
            var emptyList = new List<Developer>();

            Console.Write("Enter A Team Id Number: ");
            newDevTeam.TeamId = int.Parse(Console.ReadLine());

            Console.Write("Enter A Team Name: ");
            newDevTeam.TeamName = Console.ReadLine();

            newDevTeam.Devs = emptyList;

            _devTeamRepo.CreateDevTeam(newDevTeam);
        }

        static void ViewAllDevTeams()
        {
            var devTeams = _devTeamRepo.GetAllDevTeams();

            foreach (var devTeam in devTeams)
            {
                Console.WriteLine($"Team Id: {devTeam.TeamId}     Team Name: {devTeam.TeamName}     Team Members: {devTeam.Devs.Count}");
            }
        }

        static void ViewDevTeamMembers()
        {
            ViewAllDevTeams();

            Console.Write("Enter The Team Id Number For The Team You Want To View: ");
            var devTeamId = int.Parse(Console.ReadLine());

            var devTeam = _devTeamRepo.GetDevTeamById(devTeamId);

            foreach (var dev in devTeam.Devs)
            {
                Console.WriteLine($"Id: {dev.Id}     First Name: {dev.FirstName}     Last Name: {dev.LastName}");
            }
        }

        static void AddDevToTeam()
        {
            ViewAllDevTeams();
            Console.Write("Enter The Team Id Number You Want To Add A Developer To: ");
            int devTeamId = int.Parse(Console.ReadLine());

            var devTeam = _devTeamRepo.GetDevTeamById(devTeamId);
            var originalMemberCount = devTeam.Devs.Count;

            Console.Clear();

            ViewAllDevs();
            Console.Write($"Enter The Developer Id Number You Wish To Add To {devTeam.TeamName}: ");
            int devId = int.Parse(Console.ReadLine());

            var dev = _devRepo.GetDeveloperById(devId);
            devTeam.Devs.Add(dev);

            if (devTeam.Devs.Count > originalMemberCount)
            {
                Console.WriteLine($"{dev.FirstName} was successfully added to {devTeam.TeamName}! \n" +
                    $"Press any key to continue...");
            }
            else
            {
                Console.WriteLine($"Oops, {dev.FirstName} could not be added to {devTeam.TeamName}! \n" +
                    $"Press any key to continue...");
            }
        }

        static void RemoveDevFromTeam()
        {
            ViewAllDevTeams();
            Console.Write("Enter The Team Id Number You Want To Remove A Developer From: ");
            int devTeamId = int.Parse(Console.ReadLine());

            var devTeam = _devTeamRepo.GetDevTeamById(devTeamId);
            var originalMemberCount = devTeam.Devs.Count;

            Console.Clear();

            foreach (var devInTeam in devTeam.Devs)
            {
                Console.WriteLine($"Id: {devInTeam.Id}     First Name: {devInTeam.FirstName}     Last Name: {devInTeam.LastName}");
            }

            Console.Write($"Enter The Developer Id Number You Wish To Remove From {devTeam.TeamName}: ");
            int devId = int.Parse(Console.ReadLine());

            var dev = _devRepo.GetDeveloperById(devId);
            devTeam.Devs.Remove(dev);

            if (devTeam.Devs.Count < originalMemberCount)
            {
                Console.WriteLine($"{dev.FirstName} was successfully removed from {devTeam.TeamName}! \n" +
                    $"Press any key to continue...");
            }
            else
            {
                Console.WriteLine($"Oops, {dev.FirstName} could not be removed from {devTeam.TeamName}! \n" +
                    $"Press any key to continue...");
            }
        }

        static void UpdateDevTeamName()
        {
            ViewAllDevTeams();

            Console.Write("Enter The Team Id Number For The Team You Want To Update: ");
            var devTeamId = int.Parse(Console.ReadLine());

            var updatedDevTem = new DevTeam();

            Console.Write("Enter A Team Name: ");
            updatedDevTem.TeamName = Console.ReadLine();

            var wasUpdated = _devTeamRepo.UpdateDevTeamById(devTeamId, updatedDevTem);

            if (wasUpdated)
            {
                Console.WriteLine("Team Successfully Updated! \n" +
                    "Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Oops, something went wrong! \n" +
                    "Press any key to continue...");
                Console.ReadKey();
            }
        }

        static void DeleteDevTeam()
        {
            ViewAllDevTeams();

            Console.Write("Enter The Team Id Number For The Team You Want To Remove: ");
            var devTeamId = int.Parse(Console.ReadLine());

            var wasDeleted = _devTeamRepo.DeleteDevTeamById(devTeamId);

            if (wasDeleted)
            {
                Console.WriteLine("Team Successfully Removed! \n" +
                    "Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Oops, something went wrong! \n" +
                    "Press any key to continue...");
                Console.ReadKey();
            }
        }

        static void SeedData()
        {
            var devOne = new Developer(0, "Sean", "Dwyer", true);
            var devTwo = new Developer(1, "Maria", "Fey", true);
            var devThree = new Developer(2, "Bill", "Tester", false);
            var devFour = new Developer(3, "Karen", "Tester", false);
            var devFive = new Developer(4, "James", "Blake", true);
            var devSix = new Developer(5, "Harry", "Potter", false);
            var devSeven = new Developer(6, "Ron", "Weasley", false);
            var devEight = new Developer(7, "Hermione", "Granger", true);
            var devNine = new Developer(8, "Corey", "Taylor", true);
            var devTen = new Developer(9, "Joey", "Jordison", false);

            var listOne = new List<Developer> { devOne, devTwo, devNine, devTen };
            var listTwo = new List<Developer> { devSix, devSeven, devEight };

            var teamOne = new DevTeam(0, "His Royal Blargness", listOne);
            var teamTwo = new DevTeam(1, "Wizarding Fools", listTwo);

            _devRepo.CreateDeveloper(devOne);
            _devRepo.CreateDeveloper(devTwo);
            _devRepo.CreateDeveloper(devThree);
            _devRepo.CreateDeveloper(devFour);
            _devRepo.CreateDeveloper(devFive);
            _devRepo.CreateDeveloper(devSix);
            _devRepo.CreateDeveloper(devSeven);
            _devRepo.CreateDeveloper(devEight);
            _devRepo.CreateDeveloper(devNine);
            _devRepo.CreateDeveloper(devTen);

            _devTeamRepo.CreateDevTeam(teamOne);
            _devTeamRepo.CreateDevTeam(teamTwo);
        }
    }
}
