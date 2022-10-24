using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        private string model;
        private int capacity;
        private List<CPU> multiprocessor;

        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }
        public string Model { get { return this.model; } set { this.model = value; } }
        public int Capacity { get { return this.capacity; } set { this.capacity = value; } }
        public List<CPU> Multiprocessor { get { return this.multiprocessor; } set { this.multiprocessor = value; } }
        public int Count { get { return this.multiprocessor.Count; } }

        public void Add(CPU cpu)
        {
            if (Multiprocessor.Count < capacity)
            {
                Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            bool contains = false;

            foreach (CPU cpu in Multiprocessor)
            {
                if (cpu.Brand == brand)
                {
                    Multiprocessor.Remove(cpu);
                    contains = true;

                    break;
                }
            }

            return contains;
        }

        public CPU MostPowerful()
        {
            CPU mostPowerful = Multiprocessor.First();

            foreach (CPU cpu in Multiprocessor)
            {
                if (cpu.Frequency > mostPowerful.Frequency)
                {
                    mostPowerful = cpu;
                }
            }

            return mostPowerful;

        }// possible error

        public CPU GetCPU(string brand)
        {
            CPU gottenCPU = Multiprocessor.FirstOrDefault(b => b.Brand == brand);

            return gottenCPU;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {Model}:");

            foreach (CPU cpu in Multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }

            return sb.ToString();
        }
    }
}
