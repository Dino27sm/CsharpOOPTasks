namespace ValidationAttributes
{
    using System;

    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            int parameterValue;
            if (obj is int)
                parameterValue = (int)obj;
            else
                throw new ArgumentException("Invalid argument type!");

            if (parameterValue >= this.minValue && parameterValue <= maxValue)
                return true;
            else
                return false;
        }
    }
}
