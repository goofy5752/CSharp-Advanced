using System;
using System.Collections.Generic;

namespace BankAccount
{
    public class StartUp
    {
        static void Main()
        {
            var accounts = new Dictionary<int, BankAccount>();
            

            while (true)
            {
                string inp = Console.ReadLine();

                if (inp == "End")
                {
                    break;
                }
                string[] input = inp.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = input[0];

                switch (command)
                {
                    case "Create":
                        Create(input, accounts);
                        break;
                    case "Deposit":
                        Deposit(input, accounts);
                        break;
                    case "Withdraw":
                        Withdraw(input, accounts);
                        break;
                    case "Print":
                        Print(input, accounts);
                        break;
                }
        
            }
        }
        
        private static void Create(string[] cmdArgs,  Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(cmdArgs[1]);
            if (accounts.ContainsKey(id))
            {
                Console.WriteLine("Account already exists");
            }
            else
            {
                var acc = new BankAccount();
                acc.Id = id;
                accounts.Add(id, acc);
            }
        }

        private static void Deposit(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(cmdArgs[1]);
            if (accounts.ContainsKey(id))
            {
                accounts[id].Deposit(decimal.Parse(cmdArgs[2]));
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Withdraw(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(cmdArgs[1]);
            if (accounts.ContainsKey(id))
            {
                if (decimal.Parse(cmdArgs[2]) > accounts[id].Balance)
                {
                    Console.WriteLine("Insufficient balance");
                }
                else
                {
                    accounts[id].Withdraw(decimal.Parse(cmdArgs[2]));
                }
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Print(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
        {
            var printAcc = int.Parse(cmdArgs[1]);
            if (accounts.ContainsKey(printAcc))
            {
                Console.WriteLine($"Account ID{printAcc}, balance {accounts[printAcc].Balance:F2}");
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }
    }
}