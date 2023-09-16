﻿namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;

    using Contracts;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly ICollection<IPrivate> privates;
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, ICollection<IPrivate> privates) 
            : base(id, firstName, lastName, salary)
        {
            this.privates = privates;
        }

        public IReadOnlyCollection<IPrivate> Privates
        {
            get => (IReadOnlyCollection<IPrivate>)privates;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{base.ToString()}")
              .AppendLine("Privates:");

            foreach (IPrivate currPrivate in privates)
            {
                sb.AppendLine($"  {currPrivate}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
