using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARRAY_18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] passwords = new string[5];

            Console.WriteLine("Enter 5 passwords");

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Password {i + 1}: ");
                passwords[i] = Console.ReadLine();
            }

            Console.WriteLine("\nPassword Strength Results:");
            Console.WriteLine(" --------------------------------------------------");
            Console.WriteLine("| Password          | Strength Classification      |");
            Console.WriteLine(" --------------------------------------------------");

            foreach (string password in passwords)
            {
                string classification = ClassifyPassword(password);
                Console.WriteLine($"| {password,-17} | {classification,-28} |");
            }

            Console.WriteLine("---------------------------------------------------");
        }

        static string ClassifyPassword(string password)
        {
            if (password.Length < 8)
            {
                return "Invalid";
            }

            bool hasUppercase = false;
            bool hasDigit = false;
            bool hasSpecialChar = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUppercase = true;
                if (char.IsDigit(c)) hasDigit = true;
                if (IsSpecialCharacter(c)) hasSpecialChar = true;
            }

            if (hasUppercase && hasDigit && hasSpecialChar)
            {
                return "Strong";
            }
            else if (hasUppercase || hasDigit || hasSpecialChar)
            {
                return "Weak";
            }
            else
            {
                return "Invalid";
            }
        }

        static bool IsSpecialCharacter(char c)
        {
            char[] specialCharacters =
            {
                '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+',
                '{', '}', '[', ']', ':', ';', '"', '\'', '<', '>', ',', '.', '?', '/'
            };
            return Array.Exists(specialCharacters, element => element == c);
        }
    }
}
