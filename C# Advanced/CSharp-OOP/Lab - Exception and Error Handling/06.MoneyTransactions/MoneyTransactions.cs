namespace MoneyTransactions
{
    using System;
    using System.Collections.Generic;

    public class MoneyTransactions
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> accBalance = new Dictionary<int, double>();
            string[] accountsInfo = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);

            FillAccountBook(accountsInfo, accBalance);

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string cmd = cmdArgs[0];
                int accNumber = int.Parse(cmdArgs[1]);
                double sum = double.Parse(cmdArgs[2]);

                try
                {
                    if (!accBalance.ContainsKey(accNumber))
                    {
                        throw new ArgumentException("Invalid account!");
                    }

                    if (cmd == "Deposit")
                    {
                        accBalance[accNumber] += sum;
                    }

                    else if (cmd == "Withdraw")
                    {
                        if (accBalance[accNumber] < sum)
                        {
                            throw new ArgumentException("Insufficient balance!");
                        }

                        accBalance[accNumber] -= sum;
                    }

                    else
                    {
                        throw new ArgumentException("Invalid command!");
                    }

                    Console.WriteLine($"Account {accNumber} has new balance: {accBalance[accNumber]:F2}");
                    
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }

        public static void FillAccountBook(string[] accsInfo, Dictionary<int, double> accBalance)
        {
            for (int i = 0; i < accsInfo.Length; i++)
            {
                string[] currAcc = accsInfo[i].Split('-', StringSplitOptions.RemoveEmptyEntries);
                int currAccNum = int.Parse(currAcc[0]);
                double currAccSum = double.Parse(currAcc[1]);

                accBalance.Add(currAccNum, currAccSum);
            }
        }
    }
}
