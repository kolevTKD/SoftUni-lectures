namespace BirthdayCelebrations.Models.Contracts
{
    using System;

    public interface IBirthable
    {
        string Name { get; }
        string BirthDate { get; }
    }
}
