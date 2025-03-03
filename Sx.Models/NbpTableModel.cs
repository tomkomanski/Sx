using System;
using System.Text.Json.Serialization;

namespace Sx.Models
{
    public class ExchangeRateTable
    {
        [JsonPropertyName("table"), JsonRequired]
        public String Table { get; set; }
        [JsonPropertyName("no"), JsonRequired]
        public String No { get; set; }
        [JsonPropertyName("effectiveDate"), JsonRequired]
        public DateTime EffectiveDate { get; set; }
        [JsonPropertyName("rates"), JsonRequired]
        public ExchangeRate[] Rates { get; set; }
    }

    public class ExchangeRate
    {
        [JsonPropertyName("currency"), JsonRequired]
        public String Currency { get; set; }
        [JsonPropertyName("code"), JsonRequired]
        public String Code { get; set; }
        [JsonPropertyName("mid"), JsonRequired]
        public Decimal Mid { get; set; }
    }
}