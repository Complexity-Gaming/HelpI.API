namespace HelpI.API.SeedWork
{
    public class Money
    {
        public Money(string currency, decimal amount)
        {
            Currency = currency;
            Amount = amount;
        }
        public string Currency { get; private set; }
        public decimal Amount { get; private set; }
    }
}
