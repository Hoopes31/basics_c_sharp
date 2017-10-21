using System;
using DbConnection;
namespace simpleCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("These are the users in our system.");
            GetAllUsers();
            do {
                while (! Console.KeyAvailable) {
                    System.Console.WriteLine("If you would like to enter a user into our system press any key other than esc.");
                    System.Console.WriteLine("Otherwise press esc.");
                    System.Console.ReadLine();
                    runProgram();
                }
            } while(Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        public static void GetAllUsers()
        {
            string getAll  = "SELECT * FROM Users";
            var users = DbConnector.Query(getAll);
            foreach (var user in users)
            {
                System.Console.WriteLine($"{user["id"]} {user["FirstName"]} {user["LastName"]} {user["FavoriteNumber"]}");
            }
        }
        public static void Create(string firstName, string lastName, string num)
        {
            string insertItems = $"INSERT INTO users(FirstName, LastName, FavoriteNumber) VALUES('{firstName}', '{lastName}', '{num}')";
            DbConnector.Execute(insertItems);
            GetAllUsers();
        }
        public static void Update(string firstName, string lastName, string num, string id)
        {
            string updateItems = $"UPDATE users SET FirstName='{firstName}' LastName='{lastName}' FavoriteNumber='{num}' WHERE id = '{id}'";
        }
        public static void Delete(string id)
        {
            string updateItems = $"DELETE FROM users WHERE id = '{id}'";            
        }
        public static void runProgram()
        {
            System.Console.WriteLine("First Name:");
            string firstName = System.Console.ReadLine();
            System.Console.WriteLine("Last Name:");
            string lastName = System.Console.ReadLine();
            System.Console.WriteLine("Favorite Number:");
            string num = System.Console.ReadLine();
            Create(firstName, lastName, num);
        }
    }
}
