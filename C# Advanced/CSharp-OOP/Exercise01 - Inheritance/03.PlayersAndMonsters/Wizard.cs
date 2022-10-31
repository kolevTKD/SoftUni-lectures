using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Wizard : Hero
    {
        public Wizard(string username, int level)
            : base(username, level)
        {
            Username = username;
            Level = level;
        }

        public override string Username { get => base.Username; set => base.Username = value; }
        public override int Level { get => base.Level; set => base.Level = value; }
    }
}
