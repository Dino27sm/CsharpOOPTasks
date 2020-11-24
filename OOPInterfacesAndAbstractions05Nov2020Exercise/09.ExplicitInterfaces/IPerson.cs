namespace _09.ExplicitInterfaces
{
    using System;
    using System.Collections;

    public interface IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public string GetName();
    }
}
