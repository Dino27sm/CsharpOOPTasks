using System;

namespace T03.Raiding
{
    public class FactoryHeroes
    {
        public BaseHero CreateHero(string heroName, string heroType)
        {
            BaseHero heroObject = null;
            if (heroType == "Druid") 
                heroObject = new Druid(heroName);
            else if (heroType == "Paladin") 
                heroObject = new Paladin(heroName);
            else if (heroType == "Rogue") 
                heroObject = new Rogue(heroName);
            else if (heroType == "Warrior") 
                heroObject = new Warrior(heroName);
            else 
                throw new ArgumentException("Invalid hero!");
            return heroObject;
        }
    }
}
