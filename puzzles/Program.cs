using System;
using System.Collections.Generic;
namespace puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            // int[] array = RandomArray();
            // int max = FindMax(array);
            // int min = FindMin(array);
            // int sum = FindSum(array);
            // System.Console.WriteLine($"Max: {max} Min: {min} Sum: {sum}");
            // System.Console.WriteLine(TossCoin());
            // System.Console.WriteLine(TossMultipleCoins(10));
            string[] arrNames = {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            // System.Console.WriteLine(NamesShuffle(arrNames));
            NamesMustBe(arrNames);

        }
        static int[] RandomArray()
        {
            int[] array = new int[10];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                int valueToAdd = rand.Next(5,25);
                array[i] = valueToAdd;
            }
            return array;
        }
        static int FindMax(int[] array)
        {
            int max = array[0];
            for (int idx = 0; idx < array.Length; idx++)
            {
                if (array[idx] > max)
                {
                    max = array[idx];
                }
            }
            return max;
        }
        static int FindMin(int[] array)
        {
            int min = array[0];
            for (int idx = 0; idx < array.Length; idx++)
            {
                if (array[idx] < min)
                {
                    min = array[idx];
                }
            }
            return min;
        }
        static int FindSum(int[] array)
        {
            int sum = 0;
            for (int idx = 0; idx < array.Length; idx++)
            {
                sum = sum + array[idx];
            }
            return sum;
        }
        static string TossCoin()
        {
            Random rand = new Random();
            System.Console.WriteLine("Tossing Coin!");
            if (rand.Next(2) == 1)
            {
                return "Heads";
            }
            else
            {
                return "Tails";
            }
        }
        static double TossMultipleCoins(int num)
        {
            int count = 1;
            float tails = 0;
            float heads = 0;
            Random rand = new Random();
            while (count <= num)
            {
                if (rand.Next(2) == 1)
                {
                    ++ tails;
                }
                else
                {
                    ++ heads;
                }
                count = count + 1;
            }
            float headsRatio = heads/(float)num;
            return headsRatio;
        }
        static string[] NamesShuffle(string[] array)
        {
            Random rand = new Random();
            for (int t = 0; t < array.Length; t++ )
            {
                string tmp = array[t];
                int r = rand.Next(t, array.Length);
                array[t] = array[r];
                array[r] = tmp;
            }
            return array;
        }
        static string[] NamesMustBe(string[] array)
        {
            List<string> matchedArr = new List<string>();
            for (int idx = 0; idx < array.Length; idx++)
            {
                if (array[idx].Length > 5)
                {
                    matchedArr.Add(array[idx]);
                }
            }
            return matchedArr.ToArray();
        }
    }
}
