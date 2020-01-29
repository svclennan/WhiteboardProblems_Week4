using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace WhiteboardProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine( "IndexSum Testing" ); 
            int[] input = new int[] { 5, 17, 77, 50 };
            int[] outputArr = IndexSums(input, 55);
            string outputString = PrintArray(outputArr);
            Console.WriteLine(outputString);
            Console.WriteLine();

            Console.WriteLine("Palindrome Testing"); 
            Console.WriteLine(Palindrome("nurses run"));
            Console.WriteLine();

            Console.WriteLine("Reciprocal Testing"); 
            Console.WriteLine(ReverseReciprocal(17));
            Console.WriteLine();

            Console.WriteLine("Combination Lock Test");
            Console.WriteLine(CombinationLock(3893,5296));
            Console.WriteLine();

            Console.WriteLine("Incrementing Test"); 
            int[] arr = new int[] { 6,2,8,10 };
            Console.WriteLine(Incrementing(arr));
            Console.WriteLine();

            Console.WriteLine("PositiveAndNegative Test"); 
            input = new int[] { 7, 9, -3, -32, 107, -1, 36, 95, -14, -99, 21 };
            outputArr = PositiveAndNegative(input);
            outputString = PrintArray(outputArr);
            Console.WriteLine(outputString);
            Console.WriteLine();

            Console.WriteLine("MaxMin Test"); 
            Console.WriteLine( MaxAndMin("3 9 0 1 4 8 10 2") );
            Console.WriteLine();

            Console.WriteLine("HappyNumbers Test");
            Console.WriteLine(HappyNumbers(19));
            Console.WriteLine();

            Console.WriteLine("Valid Email Test");
            //Console.WriteLine(validEmail("name@org.org"));//True
            //Console.WriteLine(validEmail("na.me@net.net"));//True
            //Console.WriteLine(validEmail("@org.org"));//False
            //Console.WriteLine(validEmail("name@org"));//False
            //Console.WriteLine(validEmail("name@.org"));//False
            //Console.WriteLine(validEmail("name@org.com"));//True
            //Console.WriteLine(validEmail("name@org.edu"));//True
            //Console.WriteLine(validEmail("name@org.mil"));//True
            //Console.WriteLine(validEmail("name@org.gov"));//True
            Console.WriteLine(validEmailUsingEmailClass("name@org.org"));
            Console.WriteLine(validEmailUsingEmailClass("na.me@net.net"));
            Console.WriteLine(validEmailUsingEmailClass("@org.org"));
            Console.WriteLine(validEmailUsingEmailClass("name@gov"));
            Console.WriteLine(validEmailUsingEmailClass("name@.org"));
            Console.WriteLine(validEmailUsingEmailClass("name@org.com"));
            Console.WriteLine(validEmailUsingEmailClass("name@org.edu"));
            Console.WriteLine(validEmailUsingEmailClass("name@org.mil"));
            Console.WriteLine(validEmailUsingEmailClass("name@org.gov"));
            Console.WriteLine();

            Console.WriteLine("Letter Position Test");
            Console.WriteLine(LetterPosition("coding is fun!"));
            Console.WriteLine();

            Console.ReadLine();
        }
        public static int[] IndexSums(int[] array,  int sum)
        {
            int index1 = -1;
            int index2 = -1;
            int[] output;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 1; j < array.Length; j++)
                {
                    if (i != j)
                    {
                        if (array[i] + array[j] == sum)
                        {
                            index1 = i;
                            index2 = j;
                        }
                    }
                }
            }
            output = new int[2] { index1, index2 };
            return output;
        }

        public static bool Palindrome(string input)
        {
            string reverseString = ReverseString(input);
            switch (string.Compare(input.Replace(" ", ""), reverseString.Replace(" ", "")))
            {
                case 0:
                    return true;
                default:
                    return false;
            }
        }

        public static double ReverseReciprocal(int input)
        {
            string inputString = input.ToString();
            inputString = ReverseString(inputString);
            int reverse = Convert.ToInt32(inputString);
            double output = 1 / Convert.ToDouble(reverse);
            return output;
        }

        public static string ReverseString(string input)
        {
            string reverseString = "";
            for (int i = input.Length; i > 0; i--)
            {
                reverseString += input[i - 1];
            }
            return reverseString;
        }

        public static int CombinationLock(int starting, int finishing)
        {
            string start = starting.ToString();
            string finish = finishing.ToString();
            int totalTurns = 0;
            int turns;
            for (int i = 0; i < start.Length; i++)
            {
                turns = 0;
                int first = start[i] - 48;
                int second = finish[i] - 48;
                turns = Math.Abs(second - first);
                while (turns >= 6)
                {
                    second += 10;
                    turns = Math.Abs(second - first);
                }
                totalTurns += turns;
            }
            return totalTurns;
        }

        public static bool Incrementing(int[] input)
        {
            Array.Sort(input);
            int increment = input[1] - input[0];
            for(int i = 1; i < input.Length; i++)
            {
                if (!(input[i - 1]  == input[i] - increment))
                {
                    return false;
                }
            }
            return true;
        }

        public static int[] PositiveAndNegative(int[] input)
        {
            int sum = 0;
            int numOfValues = 0;
            foreach (int value in input)
            {
                if (value < 0)
                {
                    sum += value;
                }
                if (value > 0)
                {
                    numOfValues++;
                }
            }
            int[] output = new int[] { sum, numOfValues };
            return output;
        }

        public static string MaxAndMin(string input)
        {
            string[] array = input.Split(' ');
            string max = array[0];
            string min = array[0];
            foreach (string value in array)
            {
                if (Convert.ToInt32(value) < Convert.ToInt32(min))
                {
                    min = value;
                }
                if (Convert.ToInt32(value) > Convert.ToInt32(max))
                {
                    max = value;
                }
            }
            return $"Maximum:{max} Minimum:{min}";
        }

        public static bool HappyNumbers(double number)
        {
            List<double> pastNumbers = new List<double>();
            while ((number > 1) && !(pastNumbers.Contains(number)))
            {
                pastNumbers.Add(number);
                number = CheckHappy(number);
            }
            return (number == 1);
        }

        public static double CheckHappy(double number)
        {
            double total = 0;
            while (number > 0)
            {
                total = total + Math.Pow(number % 10, 2);
                number = Math.Floor(number / 10);
            }
            return total;
        }

        public static bool validEmail(string input)
        {
            if (input.Contains('@') && input.Contains('.'))
            {
                if (input[0] == '@')
                {
                    return false;
                }
                string[] secondHalf = input.Split('@');
                string[] domain = secondHalf[1].Split('.');
                if (domain[0] == "")
                {
                    return false;
                }
                string[] TLD = new string[] { "com", "edu", "gov", "net", "mil", "org" };
                for (int i = 0; i < TLD.Length; i++)
                {
                    if (domain[1] == TLD[i])
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public static bool validEmailUsingEmailClass(string input)
        {
            try
            {
                MailAddress adress = new MailAddress(input);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string LetterPosition(string input)
        {
            input = input.ToLower();
            string output = "";
            foreach (char value in input)
            {
                if (value < 123 && value > 96)
                {
                    output += (value - 96) + " ";
                }
            }
            return output;
        }

        public static string PrintArray(int[] array)
        {
            string outputString = "{ ";
            foreach (int value in array)
            {
                outputString += value + ", ";
            }
            outputString += "}";
            return outputString;
        }
    }
}
