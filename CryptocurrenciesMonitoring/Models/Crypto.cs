using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrenciesMonitoring.Models
{
    class Crypto
    {
        public string Id { get; set; }
        public int Rank { get; set; }
        public string SymbolCurrency { get; set; }
        public string NameCurrency { get; set; }
        public decimal Supply { get; set; }
        public decimal PriceUsd { get; set; }
        public float ChangeParcent24Hr { get; set; }
        public decimal MarketCapUsd { get; set; }
        public decimal VolumeUsd24Hr { get; set; }
    }
}
