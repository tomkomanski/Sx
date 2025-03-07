using System;
using System.Text.Json.Serialization;

namespace Sx.Models
{
    public class ExchangeRateTableAB
    {
        [JsonPropertyName("table"), JsonRequired]
        public String Table { get; set; }
        [JsonPropertyName("no"), JsonRequired]
        public String No { get; set; }
        [JsonPropertyName("effectiveDate"), JsonRequired]
        public DateTime EffectiveDate { get; set; }
        [JsonPropertyName("rates"), JsonRequired]
        public ExchangeRateAB[] Rates { get; set; }
    }

    public class ExchangeRateAB
    {
        [JsonPropertyName("currency"), JsonRequired]
        public String Currency { get; set; }
        [JsonPropertyName("code"), JsonRequired]
        public String Code { get; set; }
        [JsonPropertyName("mid"), JsonRequired]
        public Decimal Mid { get; set; }
    }

    public class ExchangeRateTableC
    {
        [JsonPropertyName("table"), JsonRequired]
        public String Table { get; set; }
        [JsonPropertyName("no"), JsonRequired]
        public String No { get; set; }
        [JsonPropertyName("tradingDate"), JsonRequired]
        public DateTime TradingDate { get; set; }
        [JsonPropertyName("effectiveDate"), JsonRequired]
        public DateTime EffectiveDate { get; set; }
        [JsonPropertyName("rates"), JsonRequired]
        public ExchangeRateC[] Rates { get; set; }
    }

    public class ExchangeRateC
    {
        [JsonPropertyName("currency"), JsonRequired]
        public String Currency { get; set; }
        [JsonPropertyName("code"), JsonRequired]
        public String Code { get; set; }
        [JsonPropertyName("bid"), JsonRequired]
        public Decimal Bid { get; set; }
        [JsonPropertyName("ask"), JsonRequired]
        public Decimal Ask { get; set; }
    }
}