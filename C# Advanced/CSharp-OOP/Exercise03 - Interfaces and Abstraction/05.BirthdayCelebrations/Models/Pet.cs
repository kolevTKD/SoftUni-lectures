namespace BirthdayCelebrations.Models
{
    public class Pet : Citizen
    {
        public Pet(string name, string birthdate)
            : base(name, default(int), default(string), birthdate)
        {
            base.Name = name;
            base.Birthdate = birthdate;
        }
    }
}
