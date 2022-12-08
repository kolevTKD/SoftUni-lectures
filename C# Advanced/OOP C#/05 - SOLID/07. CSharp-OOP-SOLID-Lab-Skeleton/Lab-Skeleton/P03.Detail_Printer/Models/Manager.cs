﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer.Models
{
    public class Manager : Employee
    {
        public Manager(string name, ICollection<string> documents) : base(name)
        {
            Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"{string.Join(Environment.NewLine, this.Documents)}";
        }
    }
}
