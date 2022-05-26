using System;

namespace _03.DepositCalculator
{
    class DepositCalculator
    {
        static void Main(string[] args)
        {
            double depositSum = double.Parse(Console.ReadLine());                                                 
            int depositTerm = int.Parse(Console.ReadLine());                                                      
            double annualInterest = double.Parse(Console.ReadLine());
            int percentage = 100;
            int months = 12;
            double percentageCalculator = annualInterest / percentage;                                            
            double annualInterestOnDeposit = depositSum * percentageCalculator;
            double monthDepositTerm = annualInterestOnDeposit / months;
            double totalInterest = depositTerm * monthDepositTerm;
            double totalDepositSum = depositSum + totalInterest;

            Console.WriteLine(totalDepositSum);
        }
    }
}
