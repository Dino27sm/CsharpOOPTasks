using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System.Linq;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {

        }
        public void Color(IEgg egg, IBunny bunny)
        {
            Dye gotDye = (Dye)bunny.Dyes.FirstOrDefault(x => !x.IsFinished());
            while (bunny.Energy > 0 && !egg.IsDone() && gotDye != null)
            {
                bunny.Work();
                egg.GetColored();
                gotDye.Use();
                if (gotDye.IsFinished())
                {
                    gotDye = (Dye)bunny.Dyes.FirstOrDefault(x => !x.IsFinished());
                }
            }
        }
    }
}
