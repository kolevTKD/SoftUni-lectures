using System;
using System.Linq;

namespace _08.Threeuple
{
    public class ThreeupleStartUp
    {
        static void Main(string[] args)
        {
            string[] nameAddressTownArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] nameBeerDrunkArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] nameBalanceBankArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Threeuple<string, string, string> nameAddressTown = new Threeuple<string, string, string>
            {
                Item1 = $"{nameAddressTownArgs[0]} {nameAddressTownArgs[1]}",
                Item2 = $"{nameAddressTownArgs[2]}",
                Item3 = nameAddressTownArgs.Length > 4 ? $"{nameAddressTownArgs[3]} {nameAddressTownArgs[4]}" : $"{nameAddressTownArgs[3]}"
            };

            Threeuple<string, int, bool> nameBeerDrunk = new Threeuple<string, int, bool>
            {
                Item1 = $"{nameBeerDrunkArgs[0]}",
                Item2 = int.Parse(nameBeerDrunkArgs[1]),
                Item3 = nameBeerDrunkArgs[2] == "drunk"
            };

            Threeuple<string, double, string> nameBalanceBank = new Threeuple<string, double, string>
            {
                Item1 = $"{nameBalanceBankArgs[0]}",
                Item2 = double.Parse(nameBalanceBankArgs[1]),
                Item3 = $"{nameBalanceBankArgs[2]}"
            };

            Console.WriteLine(nameAddressTown);
            Console.WriteLine(nameBeerDrunk);
            Console.WriteLine(nameBalanceBank);
        }
    }
}
