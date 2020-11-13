namespace T04.WildFarm.Factories
{
    using Animals;
    public class AnimalFactory
    {
        public Animal CreateAimal(string animalData)
        {
            string[] dataParts = animalData.Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
            string type = dataParts[0].ToLower();
            string animalName = dataParts[1];
            double animalWeight = double.Parse(dataParts[2]);
            Animal animalObject = null;
            if(type == "cat" || type == "tiger")
            {
                string livingRegion = dataParts[3];
                string breed = dataParts[4];
                if (type == "cat") 
                    animalObject = new Cat(animalName, animalWeight, livingRegion, breed);
                else if (type == "tiger")
                    animalObject = new Tiger(animalName, animalWeight, livingRegion, breed);
            }
            else if (type == "dog" || type == "mouse")
            {
                string livingRegion = dataParts[3];
                if (type == "dog")
                    animalObject = new Dog(animalName, animalWeight, livingRegion);
                else if (type == "mouse")
                    animalObject = new Mouse(animalName, animalWeight, livingRegion);
            }
            else if (type == "hen" || type == "owl")
            {
                double wingSize = double.Parse(dataParts[3]);
                if (type == "hen")
                    animalObject = new Hen(animalName, animalWeight, wingSize);
                else if (type == "owl")
                    animalObject = new Owl(animalName, animalWeight, wingSize);
            }
            return animalObject;
        } 
    }
}
