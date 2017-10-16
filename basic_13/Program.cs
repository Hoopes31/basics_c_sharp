using System;
using System.Collections.Generic;

namespace basic_13
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArray = {1,0,3,-1,5,7};
            // Print1to255();
            // PrintOdd1to255();
            // PrintSum255();
            // IteratingAnArray(numArray);
            // FindMax(numArray);
            // GetAverage(numArray);
            // ArrayWithOddNumbers();
            // GreaterThanY(numArray, 2);
            // SquareTheValues(numArray);
            // EliminateNegatives(numArray);
            // MinMaxAverage(numArray);
            // ShiftingAnArray(numArray);
            // NumberToString(numArray);
        }
        static void Print1to255()
        {
            for (int i = 1; i <= 255; i++)
            {
                Console.WriteLine(i);
            }
        }
        static void PrintOdd1to255()
        {
            for (int i = 1; i <=255; i++)
            {
                if(i%2 != 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
        static void PrintSum255()
        {
            int count = 0;
            for (int i = 0; i <= 255; i++)
            {
                count = count + i;
                System.Console.WriteLine($"New Number: {i} Sum: {count}");
            }
        }
        static void IteratingAnArray(int[] array)
        {
            for(int idx = 0; idx < array.Length; idx++)
            {
                System.Console.WriteLine(array[idx]);
            }
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
            System.Console.WriteLine(max);
            return max;
        }
        static float GetAverage(int[] array)
        {
            int sum = 0;
            for (int idx = 0; idx < array.Length; idx++)
            {
                sum = sum + array[idx];
            }
            float avr = (float)sum/array.Length;
            System.Console.WriteLine(avr);
            return avr;
        }
        static void ArrayWithOddNumbers()
        {
            int[] array = new int[255];
            int addValue = 1;
            for (int idx = 0; idx < 255; idx++)
            {
                array[idx] = addValue;
                addValue = addValue + 1;
            }
            System.Console.WriteLine("[{0}]", string.Join(", ", array));
        }
        static void GreaterThanY(int[] array, int threshold)
        {
            int count = 0;
            for (int idx = 0; idx < array.Length; idx++)
            {
                if (array[idx] > threshold)
                {
                    count = count + 1;
                }
            }
            System.Console.WriteLine(count);
        }
        static void SquareTheValues(int[] array)
        {
            for (int idx = 0; idx < array.Length; idx++)
            {
                array[idx] = array[idx] * array[idx];
            }
            System.Console.WriteLine("[{0}]", string.Join(", ", array));
        }
        static void EliminateNegatives(int[] array)
        {
            for (int idx = 0; idx < array.Length; idx++)
            {
                if (array[idx] < 0)
                {
                    array[idx] = 0;
                }
            }
            System.Console.WriteLine("[{0}]", string.Join(", ", array));
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
            System.Console.WriteLine(min);
            return min;
        }
        static void MinMaxAverage(int[] array)
        {
            int max = FindMax(array);
            int min = FindMin(array);
            float avr = GetAverage(array);
            System.Console.WriteLine($"Max: {max} Min: {min} Average: {avr}");
        }
        static void ShiftingAnArray(int[] array)
        {
            for (int idx = 1; idx < array.Length; idx++)
            {
                array[idx - 1] = array[idx];
            }
            array[array.Length - 1] = 0;
            System.Console.WriteLine("[{0}]", string.Join(", ", array));
        }
        static void NumberToString(int[] array)
        {
            object[] boxedArray = new object[array.Length];
            for (int idx = 0; idx < array.Length; idx++)
            {
                if (array[idx] < 0)
                {
                    boxedArray[idx] = "Dojo";
                }
                else
                {
                    boxedArray[idx] = array[idx];
                }
            }
            System.Console.WriteLine("[{0}]", string.Join(", ", boxedArray));
        }
    }
}
