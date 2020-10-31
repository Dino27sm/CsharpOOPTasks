using System;

namespace T01.ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double boxL, double boxW, double boxH)
        {
            this.Length = boxL;
            this.Width = boxW;
            this.Height = boxH;
        }

        public double Length 
        { 
            get => length;
            private set 
            {
                if (value <= 0)
                    throw new ArgumentException("Length cannot be zero or negative.");
                length = value;
            }
        }
        public double Width 
        { 
            get => width;
            private set 
            { 
                if(value <= 0)
                    throw new ArgumentException("Width cannot be zero or negative.");
                width = value;
            }
        }
        public double Height 
        { 
            get => height;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Height cannot be zero or negative.");
                height = value;
            }
        }

        public double BoxLateralSurface() => (2 * (length + width) * height);

        public double BoxSurface() => (BoxLateralSurface() + 2 * length * width);

        public double BoxVolume() => (length * width * height);
    }
}
