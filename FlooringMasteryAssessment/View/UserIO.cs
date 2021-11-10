using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public class UserIO
    {
        public string ReadString(string prompt, bool emptyStringAcceptable)
        {
            string userInput = "";
            bool isValid = false;

            do 
            {
                Console.WriteLine(prompt);
                userInput = Console.ReadLine();
                char[] array = userInput.ToCharArray();
                isValid = true;

                for (int x = 0; x < array.Length; x++)
                {
                    if (!Char.IsLetterOrDigit(array[x]) && array[x].ToString() != "," && array[x].ToString() != "." && array[x].ToString() != " ")
                    {
                        isValid = false;
                    }
                    
                }
                if (userInput == ""  && emptyStringAcceptable != true)
                {
                    isValid = false;
                }
                if(isValid == false)
                {
                    Console.WriteLine("Not a valid input. Please try again.");
                }
            } while (isValid == false);
            return userInput;
        }

        public int ReadInt(string prompt, int min, int max)
        {
            int output;

            while (true)
            {
                Console.WriteLine(prompt);
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out output))
                {
                    if (output >= min && output <= max)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"That number was not between {min} and {max}. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("That was not a valid input. Please try again.");
                }
            }
            return output;
        }

        public bool ReadYesNo(string prompt)
        {
            bool yesNo = false;
            bool isValid = false;
            do
            {
                Console.WriteLine(prompt);
                string userInput = Console.ReadLine().ToLower();
                if (userInput == "yes")
                {
                    isValid = true;
                    yesNo = true;
                }
                if (userInput == "no")
                {
                    isValid = true;
                    yesNo = false;
                }
            } while (isValid == false);
            return yesNo;
        }

        public DateTime ReadDateTime(string prompt, bool futureYesNo)
        {
            DateTime date;
            string userInput;
            DateTime minDate = DateTime.Parse("1/1/0001");
            if(futureYesNo)
            {
                minDate = DateTime.Today;
            }
            while(true)
            {
                Console.Clear();
                Console.WriteLine(prompt);
                userInput = Console.ReadLine();
               
                if (DateTime.TryParse(userInput, out date))
                {
                    if (date > minDate && userInput.Length >7)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Date must be after {minDate} and formatted as MM/DD/YYYY. Please try again.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Not a valid date. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                }
            }
            return date;
        }
    }
}
