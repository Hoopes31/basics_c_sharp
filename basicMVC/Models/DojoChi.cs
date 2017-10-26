using System;

//define namespace
namespace creature
{
    //define class
    public class DojoChi
    {
        //set class variables
        public string name;
        public int happiness;
        public int fullness;
        public int energy;
        public int meals;
        private Random rand = new Random();

        //define constructor method
        public DojoChi()
        {
            name = "ChiChi";
            happiness = 20;
            fullness = 20;
            energy = 50;
            meals = 3;
        }
        public DojoChi(string chiName)
        {
            name = chiName;
            happiness = 20;
            fullness = 20;
            energy = 50;
            meals = 3;
        }
        //set additional methods
        public string Feed()
        {
            if (this.meals > 0)
            {
                this.meals -= 1;
                if(DojoLikes())
                {
                int addFullness = rand.Next(5,10);
                this.fullness += addFullness;
                return $"{this.name} gained {addFullness} fullness!";
                }
                return $"{this.name} didn't like that.";
            }
            return "You have no meals!";
        }
        public string Play()
        {
            if (this.energy > 4)
            {
                this.energy -=5;

                if(DojoLikes())
                {
                    int addHappiness = rand.Next(5,10);
                    this.happiness += addHappiness;
                    return $"{this.name} gained {addHappiness} fullness!";
                }
                return $"{this.name} didn't like that.";
            }
            return "You don't have enough energy for this!";
        }
        public string Work()
        {
            if (this.energy > 4)
            {
                this.energy -= 5;
                int addMeals = rand.Next(1,3);
                this.meals += addMeals;
                return $"{this.name} worked hard and earned {addMeals}!";
            }
            return $"{this.name} doesn't have enough energy to work!";

        }
        public string Sleep()
        {
            if (this.fullness > 4 && this.happiness > 4)
            {
                this.energy += 5;
                this.fullness -= 5;
                this.happiness -= 5;
                return $"{this.name} got some rest but is now hungry and unhappy!";
            }
            return $"{this.name} is too hungry and depressed to sleep!";
        }
        public bool DojoLikes()
        {
            int randomLike = rand.Next(1,4);
            if (randomLike == 1)
            {
                return false;
            }
            return true;
        }
        public bool Win()
        {
            if (this.energy == 100 && this.fullness == 100 && this.happiness == 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Death()
        {
            if (this.fullness == 0 || this.happiness == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}