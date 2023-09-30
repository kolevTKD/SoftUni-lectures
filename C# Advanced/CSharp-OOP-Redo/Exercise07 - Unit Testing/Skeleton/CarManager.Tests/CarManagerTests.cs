namespace CarManager.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [TestCase(" ")]
        [TestCase("ASD")]
        [TestCase("!asd@")]
        public void TestIfCtorSetsMakeCorrectly(string make)
        {
            car = new Car(make, "model", 10, 100);

            Assert.AreEqual(make, car.Make);
        }

        [TestCase("")]
        [TestCase(null)]
        public void TestIfThrowsIfMakeIsNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(make, "model", 10, 100);

            }, "Make cannot be null or empty!");
        }

        [TestCase(" ")]
        [TestCase("ASD")]
        [TestCase("!asd@")]
        public void TestIfCtorSetsModelCorrectly(string model)
        {
            car = new Car("make", model, 10, 100);

            Assert.AreEqual(model, car.Model);
        }

        [TestCase("")]
        [TestCase(null)]
        public void TestIfThrowsIfModelIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("make", model, 10, 100);

            }, "Model cannot be null or empty!");
        }

        [TestCase(0.0001)]
        [TestCase(15.449)]
        [TestCase(double.MaxValue)]
        public void TestIfCtorSetsFuelConsumptionCorrectly(double fuelConsumption)
        {
            car = new Car("make", "model", fuelConsumption, 100);

            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(double.MinValue)]
        public void TestIfThrowsIfFuelConsumptionIsLessOrEqualTo0(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("make", "model", fuelConsumption, 100);

            }, "Fuel consumption cannot be zero or negative!");
        }

        [TestCase(0.0001)]
        [TestCase(1000.4523)]
        [TestCase(double.MaxValue)]
        public void TestIfCtorSetsFuelCapacityCorrectly(double fuelCapacity)
        {
            car = new Car("make", "model", 10, fuelCapacity);

            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(double.MinValue)]
        public void TestIfThrowsIfFuelCapacityIsLessOrEqualTo0(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("make", "model", 10, fuelCapacity);

            }, "Fuel capacity cannot be zero or negative!");
        }

        [TestCase(0)]
        public void TestIfCtorSetsBaseFuelAmountCorrectly(double fuelAmount)
        {
            car = new Car("make", "model", 10, 100);

            Assert.AreEqual(fuelAmount, car.FuelAmount);
        }

        [TestCase(0.0056698)]
        [TestCase(56.658972)]
        [TestCase(100)]
        public void TestIfRefuelMethodSetsFuelAmountCorrectly(double fuelAmount)
        {
            car = new Car("make", "model", 10, 100);
            car.Refuel(fuelAmount);

            Assert.AreEqual(fuelAmount, car.FuelAmount);
        }

        [TestCase(-1)]
        [TestCase(-85662.254568)]
        [TestCase(double.MinValue)]
        public void TestIfThrowsIfFuelAmountIsLessThan0(double fuelAmount)
        {
            car = new Car("make", "model", 10, 100);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuelAmount);

            }, "Fuel amount cannot be negative!");
        }

        [TestCase(100.0001)]
        [TestCase(2155672)]
        [TestCase(double.MaxValue)]
        public void TestIfFuelAmountEqualsFuelCapacityIfRefuelMoreThanFuelCapcity(double fuelAmount)
        {
            car = new Car("make", "model", 10, 100);
            car.Refuel(fuelAmount);

            Assert.AreEqual(car.FuelAmount, car.FuelCapacity);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(double.MinValue)]
        public void TestIfThrowsIfRefuelFuelAmountIsLessOrEqualTo0(double fuelAmount)
        {
            car = new Car("make", "model", 10, 100);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuelAmount);

            }, "Fuel amount cannot be zero or negative!");
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(8.8564)]
        [TestCase(10)]
        public void TestIfDriveMethodUpdateFuelAmountCorrectly(double distance)
        {
            car = new Car("make", "model", 10, 100);
            double fuelNeeded = (distance / 100) * car.FuelConsumption;

            car.Refuel(100);
            double expectedFuelAmount = car.FuelAmount - fuelNeeded;

            car.Drive(distance);

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [TestCase(1000.0001)]
        [TestCase(55264.23598)]
        [TestCase(double.MaxValue)]
        public void TestIfThrowsIfDriveFuelNeededIsGreaterThanFuelAmount(double distance)
        {
            car = new Car("make", "model", 10, 100);

            car.Refuel(100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(distance);

            }, "You don't have enough fuel to drive!");
        }
    }
}