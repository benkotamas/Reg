using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reg
{
    internal class Program
    {
        static List<KeyValuePair<string, int>> usersData = new List<KeyValuePair<string, int>>();
        
        static string ReadPassword()
        {
            string result = string.Empty;
            ConsoleKeyInfo keyInfo;

            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Enter)
            {
                Console.Write("*");
                result += keyInfo.KeyChar.ToString();
            }
            Console.WriteLine();

            return result;
        }

        static KeyValuePair<string, int> GetUserCredentials(string userName, string password)
        {
            return new KeyValuePair<string, int>(userName, password.GetHashCode());
        }
        static bool ValidateUser(string userName)
        {
            foreach (KeyValuePair<string, int> item in usersData)
            {
                if (item.Key == userName)
                {
                return true;
                }
            }
            return false;
        }
        static bool CheckPassword(int givenHash, int storedHash)
        {
            return givenHash == storedHash;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("*** Welcome to wonderland. ***");
            Console.WriteLine("*** Please register! ***");
            Console.Write("Name:");
            string name = Console.ReadLine();
            Console.Write("Password:");
            string password = ReadPassword();

            usersData.Add(GetUserCredentials(name, password));

            Console.Clear();

            Console.WriteLine("*** Registration completed. *** ");
            Console.WriteLine("*** Please sign in with you password! ***");

            bool signedln = false;

            while (!signedln)
            {
                Console.Write("Name:");
                string temp_userName = Console.ReadLine();
                Console.Write("Password:");
                string temp_password = ReadPassword();

                if (ValidateUser(temp_userName))
                {
                    int userPasswordHash = 0;

                    foreach  (KeyValuePair<string, int> item in usersData)
                    {
                        if (item.Key == temp_userName)
                        {
                            userPasswordHash = item.Value;
                        }
                    }
                    if (CheckPassword(temp_password.GetHashCode(), userPasswordHash))
                    {
                        signedln = true;
                        Console.Clear();
                        Console.WriteLine("Welcome to wonderland");
                        break;
                    }
                }
                Console.WriteLine("Incorrect name or password");
            }
            Console.ReadLine();
        }
    }
}
