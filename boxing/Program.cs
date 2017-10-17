using System;
using System.Collections.Generic;
namespace boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            List<object> myList = new List<object>();
            myList.Add(7);
            myList.Add(28);
            myList.Add(-1);
            myList.Add("chair");
            myList.Insert(3, true);
            for (int idx = 0; idx < myList.Count; idx++)
            {
                System.Console.WriteLine(myList[idx]);
                if (myList[idx] is int)
                {
                    sum = sum + (int)myList[idx];
                }
            }
            System.Console.WriteLine(sum);
        }
    }
}
