using System;

namespace Stealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Spy spyObject = new Spy();
            Console.WriteLine(spyObject.CollectGettersAndSetters("Stealer.Hacker"));
        }
    }
}
