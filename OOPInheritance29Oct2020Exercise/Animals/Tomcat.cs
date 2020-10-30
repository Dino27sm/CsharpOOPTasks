namespace Animals
{
    class Tomcat : Cat
    {
        private const string tomcatGender = "Male";

        public Tomcat(string name, int age)
            : base(name, age, tomcatGender)
        {
        }
        public override string ProduceSound()
            => "MEOW";
    }
}
