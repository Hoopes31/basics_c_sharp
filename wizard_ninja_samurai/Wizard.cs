using System;
public class Wizard : Human
{
    public string name;
    //new keyword is purposefully hides the inherited property in the base class.
    new public int intelligence { get; set; }
    new public int health { get; set; }

    public Wizard(string name): base(name)
    {
        intelligence = 25;
        health = 50;
    }
    public void fireball(object obj)
    {
        Random rand = new Random();
        //Type variable = is object a human?
        //If no return null else set object to human 
        //do things to human
        Human enemy = obj as Human;
        if(enemy == null)
        {
            System.Console.WriteLine("Failed Attack");
        }
        else
        {
            enemy.health -= rand.Next(20,50);
        }
    }
    public void heal(object obj)
    {
        health += intelligence * 10;
    }
}
