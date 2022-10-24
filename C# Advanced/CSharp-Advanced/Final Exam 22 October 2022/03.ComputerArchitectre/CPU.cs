using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerArchitecture
{
    public class CPU
    {
        private string brand;
        private int cores;
        private double frequency;

        public CPU(string brand, int cores, double frequency)
        {
            Brand = brand;
            Cores = cores;
            Frequency = frequency;
        }

        public override string ToString()
        {
            string result =
                $"{Brand} CPU:{Environment.NewLine}" +
                $"Cores: {Cores}{Environment.NewLine}" +
                $"Frequency: {Frequency:F1} GHz";

            return result;
        }

        public string Brand { get { return this.brand; } set { this.brand = value; } }
        public int Cores { get { return this.cores; } set { this.cores = value; } }
        public double Frequency { get { return this.frequency; } set { this.frequency = value; } }
    }
}
