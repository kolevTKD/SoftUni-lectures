using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class DarkKnight : Knight
    {
        public DarkKnight(string username, int level)
            : base(username, level)
        {
            Username = username;
            Level = level;
        }

        public override string Username { get; set; }
        public override int Level { get; set; }
    }
}
