using System;
using System.Linq;

namespace TheLift
{
    class Program
    {
        static void Main(string[] args)
        {
            int countPeople = int.Parse(Console.ReadLine());

            int[] wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int LiftFreeCapacity = wagons.Length * 4 - wagons.Sum();

            for (int i = 0; i < wagons.Length; i++)
            {                
                int currWagonBusy = wagons[i];
                int currWagonFree = 4 - currWagonBusy;               

                if (countPeople <= 0)
                {
                    break;
                }

                if (currWagonFree <= 0)
                {
                    continue;
                }

                if (countPeople < currWagonFree)
                {
                    wagons[i] += countPeople;
                    currWagonFree -= countPeople;
                    LiftFreeCapacity -= countPeople;
                    countPeople -= countPeople;                   
                    break;
                }
                else if (countPeople > currWagonFree)
                {
                    countPeople -= currWagonFree;
                    wagons[i] += currWagonFree;
                    LiftFreeCapacity -= currWagonFree;
                    // currWagonFree -= currWagonFree;

                    continue;
                }
                else  //countPeople == currWagonFree
                {
                    countPeople -= countPeople;
                    wagons[i] += currWagonFree;
                    LiftFreeCapacity -= currWagonFree;
                    //currWagonFree -= currWagonFree;
                }
            }

            if (countPeople == 0 && LiftFreeCapacity > 0)
            {
                Console.WriteLine($"The lift has empty spots!");
                Console.WriteLine(string.Join(' ', wagons));
            }
            else if (countPeople > LiftFreeCapacity && LiftFreeCapacity == 0)
            {
                Console.WriteLine($"There isn't enough space! " +
                    $"{countPeople - LiftFreeCapacity} people in a queue!");
                Console.WriteLine(string.Join(' ', wagons));
            }
            else if (LiftFreeCapacity == 0 && countPeople == 0)
            {
                Console.WriteLine(string.Join(' ', wagons));
            }
        }
    }
}
