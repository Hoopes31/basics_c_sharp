public class Ninja: Human
{
    new public string name;
    new public int dexterity { get; set; }
    public Ninja(string name):base(name)
    {
        dexterity = 175;
    }
    public void steal(object obj)
    {
        //If object is a human
        if (obj is Human)
        {
            //Set Object as Human
            Human enemy = obj as Human;
            enemy.health -= 0;
            health += 10;
        }
        else
        {
            System.Console.WriteLine("Failed Steal Attempt");
        }
    }
    public void get_away()
    {
        health -= 15;
    }
}