namespace PersonInfo
{
    public class Citizen : IPerson, IBirthable, IIdentifiable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }
        public string Name { get; protected set; }
        public int Age { get; protected set; }
        public string Id { get; protected set; }
        public string Birthdate { get; protected set; }
    }
}
