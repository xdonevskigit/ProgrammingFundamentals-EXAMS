using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandInterpretter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputArray = Console.ReadLine()
                .Split(new char[] { ' ' } 
                ,StringSplitOptions.RemoveEmptyEntries).ToArray();
            while (true)
            {
                string[] commands = Console.ReadLine().Split(new char[] { ' ' }
                , StringSplitOptions.RemoveEmptyEntries).ToArray(); ;
                switch (commands[0])
                {
                    case "end":
                        PrintTheManipulatedArray(inputArray);
                    return;
                    case "reverse":
                        int startReverse = int.Parse(commands[2]);
                        int countReverse = int.Parse(commands[4]);
                        ReverseTheArray(inputArray,startReverse,countReverse);
                        break;
                    case "sort":
                        int startSorting = int.Parse(commands[2]);
                        int countSorting = int.Parse(commands[4]);
                        SortTheArray(inputArray, startSorting, countSorting);
                        break;
                    case "rollLeft":
                        int countLeftRoll = int.Parse(commands[1]);
                        RollLeftTheArray(inputArray, countLeftRoll);
                        break;
                    case "rollRight":
                        int countRightRoll = int.Parse(commands[1]);
                        RollRightTheArray(inputArray, countRightRoll);
                        break;

                    default:break;
                }
                
               
            }
        }

        private static void RollRightTheArray(string[] inputArray, int countRightRoll)
        {
            if (countRightRoll < 0)
            {
                Console.WriteLine("Invalid input parameters.");
            }
            for (int i = 0; i < countRightRoll % inputArray.Length; i++)
            {
                string temp = inputArray[inputArray.Length - 1];
                for (int j = inputArray.Length - 1; j > 0; j--)
                {
                    inputArray[j] = inputArray[j - 1];
                }
                inputArray[0] = temp;
            }
        }

        private static void RollLeftTheArray(string[] inputArray, int countLeftRoll)
        {
            if (countLeftRoll < 0)
            {
                Console.WriteLine("Invalid input parameters.");
            }
            for (int i = 0; i < countLeftRoll % inputArray.Length; i++)
            {
                string temp = inputArray[0];
                for (int j = 0; j < inputArray.Length - 1; j++)
                {
                    inputArray[j] = inputArray[j + 1];
                }
                inputArray[inputArray.Length - 1] = temp;
            }
        }

        private static void SortTheArray(string[] inputArray, int startSorting, int countSorting)
        {
            if (startSorting < 0 || startSorting >= inputArray.Length
                || countSorting < 0 || countSorting + startSorting > inputArray.Length)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }
            string[] reversedPart = new string[countSorting];
            reversedPart = inputArray.Skip(startSorting).Take(countSorting).ToArray();
            Array.Sort(reversedPart);
            int myCount = 0;
            for (int i = startSorting; i < countSorting + startSorting; i++)
            {
                inputArray[i] = reversedPart[myCount];
                myCount++;
            }
        }

        private static void ReverseTheArray(string[] inputArray, int start, int count)
        {
            if (start < 0 || start >= inputArray.Length 
                || count < 0 || count + start > inputArray.Length)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }
            string[] reversedPart = new string[count];
            reversedPart = inputArray.Skip(start).Take(count).Reverse().ToArray();
            int myCount = 0;
            for (int i = start; i < count + start; i++)
            {
                inputArray[i] = reversedPart[myCount]; 
                myCount++;
            }
        }

        private static void PrintTheManipulatedArray(string[] inputArray)
        {
            Console.WriteLine("[" + String.Join(", ",inputArray) + "]");
        }
    }
}
