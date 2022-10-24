using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    public class Cargo
    {
        private int weigth;
        private string type;

        public int Weigth { get { return this.weigth; } set { this.weigth = value; } }
        public string Type { get { return this.type; } set { this.type = value; } }
    }
}
