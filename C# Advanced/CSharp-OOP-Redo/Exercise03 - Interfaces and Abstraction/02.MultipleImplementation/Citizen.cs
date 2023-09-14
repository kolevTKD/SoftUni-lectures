namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        public Citizen (string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name { get; protected set; }
        public int Age { get; protected set; }
        public string Id { get; protected set; }
        public string Birthdate { get; protected set; }
    }
}
