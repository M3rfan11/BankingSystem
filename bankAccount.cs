using System.Net;
using System.Runtime;

namespace bankingSystems
{
    abstract class BankAccount
    {
        private int accountNumber;
        private string accountHolderName;

        private double balance;



        public int AccountNumber => accountNumber;
        public string AccountHolder => accountHolderName;

        public double Balance => balance;

        public BankAccount(int number, string name)
        {
            this.accountNumber = number;
            this.accountHolderName = name;
            balance = 0.0;
        }

        public void deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                System.Console.WriteLine($"{amount} is deposited successfully. ");
            }
            else
            {
                System.Console.WriteLine("Invalid amount!!!.");
            }
        }
        public abstract void withdraw(double amount);

        protected void deduct(double amount)
        {
            balance -= amount;
        }
        public virtual void Display()
        {
            System.Console.WriteLine($"Account #{accountNumber} | {accountHolderName} | Balance: {balance:F2}");
        }

    }

}