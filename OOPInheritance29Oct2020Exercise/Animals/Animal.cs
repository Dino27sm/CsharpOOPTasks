namespace Animals
{
    using System;
    using System.Text;

    public class Animal
    {
        private string animalName;
        private int animalAge;
        private string animaGender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        
        public virtual string ProduceSound() => string.Empty;
    }
}
