using System;

namespace fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            // for (int i = 1; i <= 255; i++){
            //     Console.WriteLine(i);
            // }
            // for (int i = 1; i <= 100; i++){
            //     if (i%3 == 0 && i%5 != 0){
            //         Console.WriteLine(i);
            //     }
            //     else if (i%3 != 0 && i%5 == 0){
            //         Console.WriteLine(i);
            //     }
            // }
            // for (int i = 1; i <= 100; i++){
            //     if (i%3 == 0 && i%5 != 0){
            //         Console.WriteLine($"Fizz {i}");
            //     }
            //     else if (i%3 != 0 && i%5 == 0){
            //         Console.WriteLine($"Buzz {i}");
            //     }
            //     else if (i%3 == 0 && i%5 == 0){
            //         Console.WriteLine($"FizzBuzz {i}");
            //     }
            // }
            Random rand = new Random();
            for (int i = 0; i < 10; i++){
                int value = rand.Next();
                if (value%3 == 0 && value%5 != 0){
                    Console.WriteLine($"Fizz {value}");
                }
                else if (value%3 != 0 && value%5 == 0){
                    Console.WriteLine($"Buzz {value}");
                }
                else if (value%3 == 0 && value%5 == 0){
                    Console.WriteLine($"FizzBuzz {value}");
                }
            }
        }
    }
}
