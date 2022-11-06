namespace BorderControl.Models
{
    using BorderControl.Models.Contracts;
    public class Robot : IRobot
    {
        public Robot(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }
        public string Name { get; private set; }
        public string Id { get; private set; }
    }
}
