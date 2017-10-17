namespace oop
{
    public class Human
    {
        public string name;
        int strength = 3;
        int intelligence = 3;
        int dexterity = 3;
        public int health = 100;
        
        public Human(string enteredName)
        {
            name = enteredName;
        }

        public Human(int enteredStrength, int enteredIntelligence, int enteredDexterity, int enteredHealth)
        {
            strength = enteredStrength;
            intelligence = enteredIntelligence;
            dexterity = enteredDexterity;
            health = enteredHealth;
        }

        public int Attack(object person)
        {
            if (person is Human)
            {
                int damage = 5 * strength;
                Human personHuman = person as Human;
                personHuman.health -= damage;
                return damage;
            }
            else
            {
                return 0;
            }
        }
    }

}