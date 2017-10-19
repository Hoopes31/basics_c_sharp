using System;
using System.Threading;
public class Samurai: Human
{
    public static int numberOfSamuria = 0;
    new public string name;
    new public int health;
    public Samurai(string name): base(name)
    {
        health = 200;
        Interlocked.Increment(ref numberOfSamuria);
    }
    public void death_blow(object obj)
    {
        if (obj is Human)
        {
            Human enemy = obj as Human;
            if (enemy.health < 50){
                enemy.health = 0;
            }
        }
        else
        {
            System.Console.WriteLine("Deathblow ineffective!");
        }
    }
    public void meditate()
    {
        health = 100;
    }
    public static int how_many()
    {
        return numberOfSamuria;
    }
}