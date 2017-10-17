using System;
using System.Collections.Generic;
namespace collections_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array9 = {0,1,2,3,4,5,6,7,8,9};
            string[] arrayNames = {"Tim", "Martin", "Nikki", "Sara"};
            bool[] arrayBool = {true, false, true, false, true, false, true, false, true, false};
            int[,] multiplicationTable = new int[10,10];
            
            for (int y = 0; y < multiplicationTable.GetLength(0); y++)
            {
                int yCount = y + 1;
                for (int x = 0; x < multiplicationTable.GetLength(1); x++)
                {
                    int xCount = x + 1;
                    multiplicationTable[y,x] = yCount * xCount;
                }
            }

            List<string> iceCream = new List<string>();
            iceCream.Add("Pink Goose");
            iceCream.Add("Rocky Sky");
            iceCream.Add("Standing Sitting");
            iceCream.Add("Lying to Truth");
            iceCream.Add("Cookies n Scream");
            // System.Console.WriteLine(iceCream.Count);
            // System.Console.WriteLine(iceCream[2]);
            iceCream.RemoveAt(2);
            // System.Console.WriteLine(iceCream.Count);

            Dictionary<string, string> creams = new Dictionary<string, string>();
            Random rand = new Random();

            for (int idx = 0; idx < iceCream.Count; idx++)
            {
                string name = arrayNames[idx];
                string stringCream = iceCream[rand.Next(4)];
                creams.Add(name, stringCream);
            }

            foreach (KeyValuePair<string,string> entry in creams)
            {
                Console.WriteLine(entry.Key + "-" + entry.Value);
            }
        }
    }
}
