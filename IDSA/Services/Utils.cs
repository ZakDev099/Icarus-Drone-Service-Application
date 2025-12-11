using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Icarus_Drone_Service_Application.Services
{
    public static class Utils
    {
        public static string ToTitleCase(string input)
        {
            string result = "";
            bool capitalCase = true;

            foreach (char c in input)
            {
                char newCharacter;
                if (Char.IsWhiteSpace(c) || c == '-')
                {
                    newCharacter = c;
                    capitalCase = true;
                }
                else if (capitalCase)
                {
                    newCharacter = Char.ToUpper(c);
                    capitalCase = false;
                }
                else
                {
                    newCharacter = Char.ToLower(c);
                }

                result = result + newCharacter;
            }

            return result;
        }

        public static string ToSentenceCase(string input)
        {
            string result = "";
            bool capitalCase = true;

            foreach (char c in input)
            {
                char newCharacter;
                if (c == '.')
                {
                    newCharacter = c;
                    capitalCase = true;
                }
                else if (char.IsWhiteSpace(c))
                {
                    newCharacter = c;
                }
                else if (capitalCase)
                {
                    newCharacter = Char.ToUpper(c);
                    capitalCase = false;
                }
                else
                {
                    newCharacter = c;
                }

                result = result + newCharacter;
            }

            return result;
        }

        // 6.10 :: "Create a custom method to ensure the Service Cost textbox can only accept a double value with two decimal point"
        public static bool IsDecimalWithinPlaceLimit(string input, int decimalLimit)
        {
            var splitInput = input.Split('.');

            // The string must contain only 1 instance of '.'
            if (splitInput.Length != 2)
            {
                return false;
            }

            // The string must be exactly the decimal place limit
            if (splitInput[1].Length != decimalLimit)
            {
                return false;
            }

            return true;
        }
    }
}
