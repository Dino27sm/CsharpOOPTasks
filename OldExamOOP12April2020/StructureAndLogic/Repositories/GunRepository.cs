using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;
using System.Collections.Generic;
using System;
using System.Linq;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> models;

        public GunRepository()
        {
            this.models = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => this.models.AsReadOnly();

        public void Add(IGun model)
        {
            if (model == null)
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);

            this.models.Add(model);
        }

        public IGun FindByName(string name)
        {
            return this.models.FirstOrDefault(model => model.Name == name);
        }

        public bool Remove(IGun model)
        {
            return this.models.Remove(model);
        }
    }
}
