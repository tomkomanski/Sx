using System;
using Sx.Models;

namespace Sx.Messages.DataServices
{
    public class MessageResponseDataNbp : MessageResponseErrors
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
            if (exchangeRateTables != null)
            {
                this.exchangeRateTables.AddRange(exchangeRateTables);
            }
        }
    }
}