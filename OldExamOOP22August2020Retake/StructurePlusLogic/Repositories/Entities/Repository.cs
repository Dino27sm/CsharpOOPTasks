namespace EasterRaces.Repositories.Entities
{
    using EasterRaces.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class Repository<T> : IRepository<T>
    {
        private readonly List<T> models;

        public Repository()
        {
            this.models = new List<T>();
        }

        public T GetByName(string name) 
            => this.models.FirstOrDefault(x => x.GetType().Name == name);

        public IReadOnlyCollection<T> GetAll() => this.models.AsReadOnly();

        public void Add(T model) => this.models.Add(model);

        public bool Remove(T model) => this.models.Remove(model);
    }
}
