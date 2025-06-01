namespace bankingSystems
{
    class SavingsAccount : BankAccount
    {
        public SavingsAccount(int number, string holder) : base(number, holder) { }

        public override void withdraw(double amount)
        {
            if (amount <= Balance)
            {
                deduct(amount);
                System.Console.WriteLine($"{amount} deducted successfully.");
            }
            else
            {
                System.Console.WriteLine("This Withdrawal cannot be completed. Insufficient funds!");
            }
        }
    }
}