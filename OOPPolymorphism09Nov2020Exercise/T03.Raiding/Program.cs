using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.Raiding
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<BaseHero> raidMembers = new List<BaseHero>();
            List<string> allLines = new List<string>();
            int membersNum = int.Parse(Console.ReadLine());

            string inpLine = "";
            while (true)
            {
                inpLine = Console.ReadLine();
                allLines.Add(inpLine);
                if (char.IsDigit(inpLine[0]))
                    break;
            }

            for (int i = 1; i < allLines.Count - 1; i += 2)
            {
                string heroName = allLines[i - 1];
                string heroType = allLines[i];
                if (raidMembers.Count < membersNum)
                {
                    try
                    {
                        BaseHero heroObject = new FactoryHeroes().CreateHero(heroName, heroType);
                        raidMembers.Add(heroObject);
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                }
                else break;
            }

            int bossPower = int.Parse(allLines.Last());
            int sumPowerOfHeroes = 0;
            foreach (BaseHero hero in raidMembers)
            {
                Console.WriteLine(hero.CastAbility());
                sumPowerOfHeroes += hero.Power;
            }
            if (sumPowerOfHeroes >= bossPower)
                Console.WriteLine("Victory!");
            else
                Console.WriteLine("Defeat...");
        }
    }
}
