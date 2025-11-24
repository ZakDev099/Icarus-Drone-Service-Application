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
            string result;
            if (string.IsNullOrEmpty(input))
            {
                result = input;
            }
            else
            {
                result = Char.ToUpper(input[0]) + input[1..].ToLower();
            }

            return result;
        }
    }
}
