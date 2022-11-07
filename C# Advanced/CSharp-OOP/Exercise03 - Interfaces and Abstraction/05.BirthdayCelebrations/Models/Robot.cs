namespace BirthdayCelebrations.Models
{
    using Contracts;
    public class Robot : Citizen, IRobot
    {
        public Robot(string model, string id)
            : base(model, default(int), id, default(string))
        {
            this.Model = model;
            base.Id = id;
        }

        public string Model { get; private set; }
    }
}
