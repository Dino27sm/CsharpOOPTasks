using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System.Linq;
using System.Collections.Generic;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private readonly List<IEgg> models;

        public EggRepository()
        {
            this.models = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models => this.models.AsReadOnly();

        public void Add(IEgg model)
        {
            if (!(model == null || this.models.Any(x => x.Name == model.Name)))
            {
                this.models.Add(model);
            }
        }

        public IEgg FindByName(string name) => this.models.FirstOrDefault(x => x.Name == name);

        public bool Remove(IEgg model) => this.models.Remove(model);
    }
}
