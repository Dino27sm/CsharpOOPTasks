namespace T04.WildFarm.Factories
{
    using Foods;

    public class FoodFactory
    {
        public Food ProduceFood(string foodData)
        {
            string[] dataParts = foodData.Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
            string foodType = dataParts[0];
            int foodAmount = int.Parse(dataParts[1]);
            string type = foodType.ToLower();
            Food foodObject = null;
            if (type == "vegetable") foodObject = new Vegetable(foodAmount);
            else if (type == "fruit") foodObject = new Fruit(foodAmount);
            else if (type == "meat") foodObject = new Meat(foodAmount);
            else if (type == "seeds") foodObject = new Seeds(foodAmount);
            return foodObject;
        }
    }
}
