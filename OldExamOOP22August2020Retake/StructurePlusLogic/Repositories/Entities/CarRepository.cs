namespace EasterRaces.Repositories.Entities
{
    using EasterRaces.Models.Cars.Contracts;
    using System.Collections.Generic;

    public class CarRepository : Repository<ICar>
    {
        private readonly List<ICar> cars;

        public CarRepository()
        {
            this.cars = new List<ICar>();
        }
    }
}
