using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new char[]
            { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            while (true)
            {
                string[] commands = Console.ReadLine().Split().ToArray();
                switch (commands[0])
                {
                    case "end":
                        PrintTheArray(input);
                        return;
                    case "exchange":
                        //WTF
                        input = ExchengingTheArray(input, commands);
                        break;
                    case "max":
                        ReturnIndexOfMaxEvenOrOddElement(input, commands);
                        break;
                    case "min":
                        ReturnIndexOfMinEvenOrOddElement(input, commands);
                        break;
                    case "first":
                        ReturnTheFistEvenOrOddElements(input, commands);
                        break;
                    case "last":
                        ReturnTheLastEvenOrOddElements(input, commands);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void ReturnTheLastEvenOrOddElements(int[] input, string[] commands)
        {
            string oddOrEven = commands[2];
            int numOfElements = int.Parse(commands[1]);
            if (numOfElements > input.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            List<int> resultList = new List<int>();
            if (oddOrEven == "even")
            {
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    if (input[i] % 2 == 0 && numOfElements > 0)
                    {
                        resultList.Add(input[i]);
                        numOfElements--;
                    }
                }
                resultList.Reverse();
                Console.WriteLine($"[{String.Join(", ", resultList)}]");
            }
            else if (oddOrEven == "odd")
            {
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    if (input[i] % 2 != 0 && numOfElements > 0)
                    {
                        resultList.Add(input[i]);
                        numOfElements--;
                    }
                }
                resultList.Reverse();
                Console.WriteLine($"[{String.Join(", ", resultList)}]");
            }
        }
       
        private static void ReturnTheFistEvenOrOddElements(int[] input, string[] commands)
        {
            string oddOrEven = commands[2];
            int numOfElements = int.Parse(commands[1]);
            if (numOfElements > input.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            List<int> resultList = new List<int>();
            if (oddOrEven == "even")
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] % 2 == 0 && numOfElements > 0)
                    {
                        resultList.Add(input[i]);
                        numOfElements--;
                    }
                } 
                Console.WriteLine($"[{String.Join(", ", resultList)}]");
            }
            else if (oddOrEven == "odd")
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] % 2 != 0 && numOfElements > 0)
                    {
                        resultList.Add(input[i]);
                        numOfElements--;
                    }
                }
                Console.WriteLine($"[{String.Join(", ", resultList)}]");
            }
       
        }
       
        private static void ReturnIndexOfMinEvenOrOddElement(int[] input, string[] commands)
        {
            string oddOrEven = commands[1];
            int result = int.MaxValue;
            int index = -1;
            if (oddOrEven == "even")
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] % 2 == 0 && result >= input[i])
                    {
                        result = input[i];
                        index = i;
                    }
                }
                if (index != -1)
                {
                    Console.WriteLine(index);
                }
                else
                {
                    Console.WriteLine("No matches");
                }
            }
            else if (oddOrEven == "odd")
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] % 2 != 0 && result >= input[i])
                    {
                        result = input[i];
                        index = i;
                    }
                }
                if (index != -1)
                {
                    Console.WriteLine(index);
                }
                else
                {
                    Console.WriteLine("No matches");
                }
            }
        }

        private static void ReturnIndexOfMaxEvenOrOddElement(int[] input, string[] commands)
        {
            string oddOrEven = commands[1];
            int result = int.MinValue;
            int index = -1;
            if (oddOrEven == "even")
            {                          
                 for (int i = 0; i < input.Length; i++)
                 {
                     if (input[i] % 2 == 0 && result <= input[i])
                     {
                         result = input[i];
                         index = i;
                     }
                 }
                 if (index != -1)
                 {
                     Console.WriteLine(index);
                 }
                 else
                 {
                     Console.WriteLine("No matches");
                 }
            }
            else if (oddOrEven == "odd")
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] % 2 != 0 && result <= input[i])
                    {
                        result = input[i];
                        index = i;
                    }
                }
                if (index != -1)
                {
                    Console.WriteLine(index);
                }
                else
                {
                    Console.WriteLine("No matches");
                }
            }
        }

        private static int[] ExchengingTheArray(int[] input, string[] commands)
        {
            int index = int.Parse(commands[1]);
            if (index >= input.Length || index < 0)
            {
                Console.WriteLine("Invalid index");
                return input;
            }
            int[] tempOne = input.Take(index + 1).ToArray();
            int[] tempTwo = input.Skip(index + 1).ToArray();
            input = tempTwo.Concat(tempOne).ToArray();
            return input;
        }

        private static void PrintTheArray(int[] input)
        {
            Console.WriteLine("[" + String.Join(", ", input) + "]");
        }
    }
}