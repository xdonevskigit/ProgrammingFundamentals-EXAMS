using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            long length = long.Parse(Console.ReadLine());
            long[] land = new long[length];
            long[] ladyBugsIndexes = Console.ReadLine().Split(new char[] { ' ' }
            , StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

            for (int i = 0; i < land.Length; i++)
            {
                for (int j = 0; j < ladyBugsIndexes.Length; j++)
                {
                    if (i == ladyBugsIndexes[j])
                    {
                        land[i] = 1;
                    }
                }
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Trim().Split(new char[] { ' ' }
            , StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (commands[0] == "end")
                {
                    PrintTheResult(land);
                    return;
                }
                int cmdIndex = int.Parse(commands[0]);
                string cmdDirection = commands[1];
                int cmdFlyingSteps = int.Parse(commands[2]);
                if (cmdIndex < 0 || cmdIndex > land.Length - 1)
                {
                    continue;
                }
                if (cmdDirection == "left")
                {
                    int currentIndex = cmdIndex - cmdFlyingSteps;
                    for (int i = 0; i < land.Length; i++)
                    {
                        if (land[cmdIndex] == 0 && i == 0)
                        {
                            break;
                        }
                        else
                        {
                            land[cmdIndex] = 0;
                            
                            if (currentIndex < 0 || currentIndex > land.Length - 1)
                            {
                                break;
                            }
                            else if (land[currentIndex] == 1)
                            {
                                currentIndex = currentIndex - cmdFlyingSteps;
                            }
                            else
                            {
                                land[currentIndex]++;
                                break;
                            }
                        }
                    }
                }
                else if (cmdDirection == "right")
                {
                    int currentIndex = cmdIndex + cmdFlyingSteps;
                    for (int i = 0; i < land.Length; i++)
                    {
                        if (land[cmdIndex] == 0 && i == 0)
                        {
                            break;
                        }
                        else
                        {
                            land[cmdIndex] = 0;
                            
                            if (currentIndex < 0 || currentIndex > land.Length - 1)
                            {
                                break;
                            }
                            else if (land[currentIndex] == 1)
                            {
                                currentIndex = currentIndex + cmdFlyingSteps;
                            }
                            else
                            {
                                land[currentIndex]++;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void PrintTheResult(long[] land)
        {
            Console.WriteLine(String.Join(" ", land));
        }
    }
}
