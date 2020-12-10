namespace EasterRaces.Repositories.Entities
{
    using EasterRaces.Models.Races.Contracts;
    using System.Collections.Generic;

    public class RaceRepository : Repository<IRace>
    {
        private readonly List<IRace> races;

        public RaceRepository() : base()
        {
            this.races = new List<IRace>();
        }
    }
}
