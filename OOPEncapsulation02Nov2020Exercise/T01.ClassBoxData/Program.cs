using System;

namespace T01.ClassBoxData
{
    class Program
    {
        static void Main(string[] args)
        {
            double boxLength = double.Parse(Console.ReadLine());
            double boxWidth = double.Parse(Console.ReadLine());
            double boxHeight = double.Parse(Console.ReadLine());

            Box boxObject = null;
            try
            {
                boxObject = new Box(boxLength, boxWidth, boxHeight);

            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
                return;
            }

            Console.WriteLine($"Surface Area - {boxObject.BoxSurface():F2}");
            Console.WriteLine($"Lateral Surface Area - {boxObject.BoxLateralSurface():F2}");
            Console.WriteLine($"Volume - {boxObject.BoxVolume():F2}");
        }
    }
}
