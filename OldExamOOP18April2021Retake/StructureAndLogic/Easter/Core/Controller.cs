using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;

        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;
            if (bunnyType == "HappyBunny") bunny = new HappyBunny(bunnyName);
            else if (bunnyType == "SleepyBunny") bunny = new SleepyBunny(bunnyName);
            else throw new InvalidOperationException("Invalid bunny type.");

            this.bunnies.Add(bunny);
            return $"Successfully added {bunnyType} named {bunnyName}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IDye dye = new Dye(power);
            IBunny bunnyObj = this.bunnies.FindByName(bunnyName);

            if (bunnyObj == null) 
                throw new InvalidOperationException("The bunny you want to add a dye to doesn't exist!");

            bunnyObj.AddDye(dye);
            return $"Successfully added dye with power {power} to bunny {bunnyName}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg eggObj = new Egg(eggName, energyRequired);
            this.eggs.Add(eggObj);
            return $"Successfully added egg: {eggName}!";
        }

        public string ColorEgg(string eggName)
        {
            List < IBunny > bunnyReady = this.bunnies.Models.Where(x => x.Energy >= 50)
                .OrderByDescending(y => y.Energy)
                .ToList();

            if (bunnyReady.Count == 0)
                throw new InvalidOperationException("There is no bunny ready to start coloring!");

            IEgg eggToColorise = this.eggs.FindByName(eggName);
            IWorkshop workObj = new Workshop();

            while (bunnyReady.Count > 0 && !eggToColorise.IsDone())
            {
                IBunny currentBunny = bunnyReady[0];
                
                workObj.Color(eggToColorise, currentBunny);

                if(currentBunny.Energy == 0 || currentBunny.Dyes.All(x => x.IsFinished()))
                    bunnyReady.RemoveAt(0);
            }
            if (eggToColorise.IsDone())
                return $"Egg {eggName} is done.";

            return $"Egg {eggName} is not done.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            List<IEgg> coloredEggs = this.eggs.Models.Where(x => x.IsDone()).ToList();
            List<IBunny> remainedBunnies = this.bunnies.Models.Where(x => x.Energy > 0).ToList();

            sb.AppendLine($"{coloredEggs.Count} eggs are done!");
            sb.AppendLine("Bunnies info:");

            for (int i = 0; i < remainedBunnies.Count; i++)
            {
                sb.AppendLine($"Name: {remainedBunnies[i].Name}");
                sb.AppendLine($"Energy: {remainedBunnies[i].Energy}");
                sb.AppendLine($"Dyes: {remainedBunnies[i].Dyes.Count(x => !x.IsFinished())} not finished");
            }

            return sb.ToString().Trim();
        }
    }
}
