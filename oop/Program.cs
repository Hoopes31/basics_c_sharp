using System;

namespace oop
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Cai = new Human("Cai");
            Human Irvine = new Human("Irvine");
            Cai.Attack(Irvine);
            Console.WriteLine(Irvine.health);
        }
    }
}
