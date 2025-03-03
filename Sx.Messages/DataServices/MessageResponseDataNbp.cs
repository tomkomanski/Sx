using System;
using Sx.Models;

namespace Sx.Messages.DataServices
{
    public class MessageResponseDataNbp
    {
        private List<ExchangeRateTable> exchangeRateTables = new();

        public IEnumerable<ExchangeRateTable> ExchangeRateTables 
        {
            get
            {
                return this.exchangeRateTables;
            }
        }

        public void SetExchangeRateTables(IEnumerable<ExchangeRateTable> exchangeRateTables)
        {
            this.exchangeRateTables.Clear();
            this.exchangeRateTables.AddRange(exchangeRateTables);
        }
    }
}