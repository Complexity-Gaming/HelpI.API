using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpI.API.Domain.Models
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
