using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Decoding_the_ID_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a South African ID number: ");
            string idNumber = Console.ReadLine();

            string dateOfBirth = idNumber.Substring(0,6);
            string genderNumber = idNumber.Substring(6,1);
            string citizenshipNumber = idNumber.Substring(10,1);
          
            string GenderValidaton;
            if (Convert.ToInt32(genderNumber) <= 4){ GenderValidaton = "Female";}
            else {GenderValidaton = "Male";}

            string citizenship;
            if (Convert.ToInt32(citizenshipNumber) <= 0) { citizenship = "SA Citizen"; }
            else { citizenship = "Permanent Resident"; }


            if (IsSouthAfricanIdValid(idNumber))
            {
                Console.WriteLine("Valid South African ID number.");
            }
            else
            {
                Console.WriteLine("Invalid South African ID number.");
            }

            Console.WriteLine("Birth Date: " + dateOfBirth);
            Console.WriteLine("Gender: " + GenderValidaton);
            Console.WriteLine("Citizenship Status: " + citizenship);
            Console.ReadLine();
        }

        static bool IsSouthAfricanIdValid(string idNumber)
        {
            if (idNumber.Length != 13)
            {
                return false; // The ID number must be exactly 13 digits long.
            }
            // Step 1: Double every second digit from the right.
            int sum = 0;
            bool doubleDigit = false;
            for (int i = idNumber.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(idNumber[i].ToString());

                if (doubleDigit)
                {
                    digit *= 2;
                    if (digit > 9)
                    {
                        digit -= 9;
                    }
                }

                sum += digit;
                doubleDigit = !doubleDigit;
            }

            // Step 4: Check if the sum is divisible by 10.
            return sum % 10 == 0;

        }
    }
}
