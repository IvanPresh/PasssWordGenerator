using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System;
using System.Text;

namespace PasswordGenerator
{
    class Program
    {
        private const string Uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; //defining attributes of the class and also defining my custom set charaters.
        
        private const string Lowercase = "abcdefghijklmnopqrstuvwxyz";
        
        private const string Digits = "0123456789";
        
        private const string SpecialCharacters = "!@#$%^&*()_-=+|;:,.<>?";

        public static string GeneratePassword(int length) //passing password length as defining paramenters of the method
        {
            StringBuilder password = new StringBuilder(); // creating an empty string builder (a safe box)

            Random random = new Random();

            string charCombination = Uppercase + Lowercase + Digits + SpecialCharacters; // creating pool of characters

            while (password.Length < length)
            {
                char character = charCombination[random.Next(charCombination.Length)];
                
                password.Append(character);
            }

            return password.ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO PASSWORD GENERATOR!");


            Console.WriteLine("Please Input desired password length:");


        start:

            string input = Console.ReadLine();

            if (int.TryParse(input, out var passwordLength)) //using in.TryParse to convert input string to actual integer and looping through to check for condition and return a boolean 
            {
                string generatedPassword = GeneratePassword(passwordLength); //declaring string variable "generatedPassword" to invoke the method
               
                Console.WriteLine($"Generated Password: {generatedPassword}"); //using string interpolation otherwise we can also output using concatenation 
            }                                                                   //e.g Console.WriteLine("Generated Password: " + generatedPassword);
            else
            {
                Console.WriteLine("Invalid : Please Input a Valid Integer");
                
                goto start;
            }

            Console.ReadKey();
        }
    }
}
