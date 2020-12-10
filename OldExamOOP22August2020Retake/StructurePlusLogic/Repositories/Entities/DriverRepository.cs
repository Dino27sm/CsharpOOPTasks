namespace EasterRaces.Repositories.Entities
{
    using EasterRaces.Models.Drivers.Contracts;
    using System.Collections.Generic;

    public class DriverRepository : Repository<IDriver>
    {
        private readonly List<IDriver> drivers;

        public DriverRepository()
        {
            this.drivers = new List<IDriver>();
        }
    }
}
