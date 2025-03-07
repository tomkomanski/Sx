using System;
using Sx.Models;

namespace Sx.Messages.ApplicationServices
{
    public class MessageResponseApplicationSx : MessageResponseErrors
    {
        private readonly List<CurrencyDataAB> currencyDataAB = new();
        private readonly List<CurrencyDataC> currencyDataC = new();
        private readonly NbpTableKind nbpTableKind;

        public IEnumerable<CurrencyDataAB> CurrencyDataAB
        {
            get
            {
                return this.currencyDataAB;
            }
        }

        public IEnumerable<CurrencyDataC> CurrencyDataC
        {
            get
            {
                return this.currencyDataC;
            }
        }

        public NbpTableKind NbpTableKind
        {
            get
            {
                return this.nbpTableKind;
            }
        }

        public MessageResponseApplicationSx(NbpTableKind nbpTableKind)
        {
            this.nbpTableKind = nbpTableKind;
        }

        public void SetCurrencyData(IEnumerable<CurrencyDataAB> currencyDataAB)
        {
            this.currencyDataAB.Clear();
            if (currencyDataAB != null)
            {
                this.currencyDataAB.AddRange(currencyDataAB);
            }
        }

        public void SetCurrencyData(IEnumerable<CurrencyDataC> currencyDataC)
        {
            this.currencyDataC.Clear();
            if (currencyDataC != null)
            {
                this.currencyDataC.AddRange(currencyDataC);
            }
        }
    }
}