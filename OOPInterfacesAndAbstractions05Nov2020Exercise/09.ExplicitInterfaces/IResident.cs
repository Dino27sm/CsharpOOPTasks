namespace _09.ExplicitInterfaces
{
    using System;
    using System.Collections;

    public interface IResident
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public string GetName();
    }
}
