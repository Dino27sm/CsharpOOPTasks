using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System.Linq;
using System.Collections.Generic;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly List<IBunny> models;

        public BunnyRepository()
        {
            this.models = new List<IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models => this.models.AsReadOnly();

        public void Add(IBunny model)
        {
            if(!(model == null || this.models.Any(x => x.Name == model.Name)))
            {
                this.models.Add(model);
            }
        }

        public IBunny FindByName(string name) => this.models.FirstOrDefault(x => x.Name == name);

        public bool Remove(IBunny model) => this.models.Remove(model);
    }
}
