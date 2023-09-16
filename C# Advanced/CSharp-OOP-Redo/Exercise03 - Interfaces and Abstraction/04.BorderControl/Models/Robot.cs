﻿namespace BorderControl.Models
{
    using Contracts;
    public class Robot : IRobot
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Id { get; private set; }
        public string Model { get; private set; }
    }
}
