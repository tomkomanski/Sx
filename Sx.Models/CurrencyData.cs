using System;

namespace Sx.Models
{
    public class CurrencyDataAB
    {
        public String Date { get; set; }
        public String Currency { get; set; }
        public String Code { get; set; }
        public Decimal Mid { get; set; }
    }

    public class CurrencyDataC
    {
        public String Date { get; set; }
        public String Currency { get; set; }
        public String Code { get; set; }
        public Decimal Bid { get; set; }
        public Decimal Ask { get; set; }
    }
}