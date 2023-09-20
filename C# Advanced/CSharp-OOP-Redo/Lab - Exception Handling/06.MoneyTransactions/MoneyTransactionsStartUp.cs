namespace MoneyTransactions
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] bankAccountsRaw = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);
            Dictionary<int, double> bankAccounts = new Dictionary<int, double>();

            foreach (string bankAccountRaw in bankAccountsRaw)
            {
                string[] bankAccount = bankAccountRaw.Split('-', StringSplitOptions.RemoveEmptyEntries);

                bankAccounts.Add(int.Parse(bankAccount[0]), double.Parse(bankAccount[1]));
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string message = string.Empty;

                string[] cmdArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string cmd = cmdArgs[0];
                int accountNo = int.Parse(cmdArgs[1]);
                double transactionSum = double.Parse(cmdArgs[2]);

                try
                {
                    if (!(cmd == "Deposit" || cmd == "Withdraw"))
                    {
                        message = "Invalid command!";
                        throw new ArgumentException();
                    }
                    else
                    {
                        if (!bankAccounts.ContainsKey(accountNo))
                        {
                            message = "Invalid account!";
                            throw new ArgumentException();
                        }
                        else
                        {
                            if (cmd == "Deposit")
                            {
                                bankAccounts[accountNo] += transactionSum;
                            }
                            else if (cmd == "Withdraw")
                            {
                                if (bankAccounts[accountNo] < transactionSum)
                                {
                                    message = "Insufficient balance!";
                                    throw new ArgumentException();
                                }

                                bankAccounts[accountNo] -= transactionSum;
                            }
                        }
                    }

                    Console.WriteLine($"Account {accountNo} has new balance: {bankAccounts[accountNo]:F2}");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine(message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }
    }
}
