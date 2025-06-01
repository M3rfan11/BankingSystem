namespace bankingSystems
{
    class CurrentAccount : BankAccount
    {
        private double withdrawalOverDraftLimit = 20000;
        public CurrentAccount(int number, string holder) : base(number, holder) { }

        public override void withdraw(double amount)
        {
            if (amount <= Balance + withdrawalOverDraftLimit)
            {
                deduct(amount);
                System.Console.WriteLine($"{amount} deducted successfully.");
            }
            else
            {
                System.Console.WriteLine("This Withdrawal cannot be completed. withdrawal exceeds your limit!");
            }
        }
    }
}