namespace Animals
{
    public class Tomcat : Cat
    {
        private const string DEFAULT_TOMCAT_GENDER = "Male";
        public Tomcat (string name, int age)
            : base(name, age, DEFAULT_TOMCAT_GENDER)
        {

        }

        public override string Gender => DEFAULT_TOMCAT_GENDER;

        public override string ProduceSound() => "MEOW";
    }
}
