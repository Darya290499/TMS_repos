namespace HomeWork9.Task1
{
    public class Debt
    {
        public decimal Balance { get; set; }
        public decimal InterestRate { get; set; }

        public Debt() { }

        public Debt(decimal balance, decimal interestRate)
        {
            Balance = balance;
            InterestRate = interestRate;
        }

        public void PrintBalance() => Console.WriteLine($"Баланс: {Math.Round(Balance, 2)}");
        public void PrintInterestRate() => Console.WriteLine($"Ставка: {InterestRate}");
        public void WaitOneYear() => Balance *= InterestRate;
    }
}
