using System;

namespace basics
{
    class Program
    {
        static void Main(string[] args) {
            // Interpolation
            Console.WriteLine($"The answer to 2 + 7 is {2+7}");
            // Loops
            for (int i = 1; i <= 5; i++) {
                Console.WriteLine(i);
            } 
            int j = 1;
            while (j<6){
                Console.WriteLine(j);
                j = j + 1;
            }
            //Generating Random Numbers
            Random rand = new Random();
            Console.WriteLine(rand.Next());
        }
    }
}
