using System.Collections.Generic;
using T04.WildFarm.Foods;

namespace T04.WildFarm.Animals
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }
        public virtual double WeghtCorrection { get; set; }
        public virtual string[] MyFood { get; set; }

        public abstract string AnimalSound();

        public bool IsMyFood(Food givenFood)
        {
            bool isRightFood = false;
            string recevedFoodName = givenFood.GetType().Name;
            recevedFoodName = recevedFoodName.ToLower().ToString();
            int recevedFoodAmount = givenFood.Quantity;
            foreach (string foodName in this.MyFood)
            {
                if (recevedFoodName == foodName)
                {
                    isRightFood = true;
                    this.FoodEaten += recevedFoodAmount;
                    this.Weight += recevedFoodAmount * this.WeghtCorrection;
                    return isRightFood;
                }
            }
            return isRightFood;
        }

        public abstract override string ToString();
    }
}
