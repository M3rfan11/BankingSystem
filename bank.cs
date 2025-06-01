using System;
using System.Collections.Generic;
using System.Linq;

namespace bankingSystems{
    class Bank
    {
        List<BankAccount> bankAccounts = new List<BankAccount>();
        private int bankID = 1;

        public void menu()
        {
            while (true)
            {
                System.Console.WriteLine("\n Bank Menu:");
                System.Console.WriteLine("1. Create Account");
                System.Console.WriteLine("2. Deposit");
                System.Console.WriteLine("3. Withdraw");
                System.Console.WriteLine("4. Check Balance");
                System.Console.WriteLine("5. View All Accounts");
                System.Console.WriteLine("0. Exit");
                System.Console.Write("Choose an option: ");
                string choice = System.Console.ReadLine();


                switch (choice)
                {
                    case "1": createAccount(); break;
                    case "2": Deposit(); break;
                    case "3": Withdraw(); break;
                    case "4": checkBalance(); break;
                    case "5": viewAll(); break;
                    case "0": return;
                    default: System.Console.WriteLine("You're not good enough with numbers!. Invalid input"); break;
                }
            }
        }



        private void createAccount()
        {
            System.Console.Write("Enter the account holder name: ");
            string accName = Console.ReadLine();
            System.Console.Write("Choose the account type(1:Saving - 2:Current)");
            string type = Console.ReadLine();

            BankAccount account = type == "2"
                  ? new CurrentAccount(bankID++, accName)
                  : new SavingsAccount(bankID++, accName);

            bankAccounts.Add(account);
            System.Console.WriteLine($"Bank account made sucessfully with account number: {account.AccountNumber}");
        }
        private BankAccount FindAccount()
        {
            Console.Write("Enter account number: ");
            if (int.TryParse(Console.ReadLine(), out int accNum))
            {
                return bankAccounts.Find(a => a.AccountNumber == accNum);
            }
            Console.WriteLine(" Invalid number.");
            return null;
        }

        private void Deposit()
        {
            var acc = FindAccount();
            if (acc == null)
            {
                return;
            }
            else
            {
                System.Console.Write("Enter amount you want to deposit: ");
                if (double.TryParse(Console.ReadLine(), out double amt)) acc.deposit(amt);
                else
                {
                    System.Console.WriteLine("Invalid amount.");
                }


            }

        }
        private void Withdraw()
        {
            var acc = FindAccount();
            if (acc == null)
            {
                return;
            }
            else
            {
                System.Console.Write("Enter amount you want to Withdraw: ");
                if (double.TryParse(Console.ReadLine(), out double amt)) acc.withdraw(amt);
                else
                {
                    System.Console.WriteLine("Invalid amount.");
                }


            }

        }
        private void checkBalance()
        {
            var acc = FindAccount();
            if (acc != null)
            {
                System.Console.WriteLine($"Balance = {acc.Balance:F2}");
             }
        }
        private void viewAll()
        {
            if (bankAccounts.Count == 0)
            {
                System.Console.WriteLine("No accounts found!");
                return;
            }
            else
            {
                foreach (var acc in bankAccounts)
                {
                    acc.Display();
                }
            }
        }
    }
}