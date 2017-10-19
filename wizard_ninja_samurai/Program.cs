using System;

namespace wizard_ninja_samurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Samurai bob = new Samurai("Dole");
            Ninja rita = new Ninja("Frida");
            Wizard sam = new Wizard("uel");
            bob.attack(rita);
            System.Console.WriteLine(rita.health);
            int numb = bob.how_many();
            System.Console.WriteLine(numb);
        }
    }
}
