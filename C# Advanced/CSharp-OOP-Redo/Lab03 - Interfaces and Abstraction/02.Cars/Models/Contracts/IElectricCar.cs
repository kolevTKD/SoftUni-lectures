namespace Cars.Models.Contracts
{
    public interface IElectricCar : ICar
    {
        int Battery { get; }
    }
}
