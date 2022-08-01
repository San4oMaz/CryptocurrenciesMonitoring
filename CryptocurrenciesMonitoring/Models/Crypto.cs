﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrenciesMonitoring.Models
{
    public class Crypto
    {
        public string id { get; set; }
        public int? rank { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
        public decimal? supply { get; set; }
        public decimal? maxSupply { get; set; }
        public decimal? marketCapUsd { get; set; }
        public decimal? volumeUsd24Hr { get; set; }
        public decimal? priceUsd { get; set; }
        public decimal? changePercent24Hr { get; set; }
        public decimal? vwap24Hr { get; set; }
        public string explorer { get; set; }


        public override string ToString()
        {
           // return $"ID:{asset_id}, Name:{name}";
            return $"ID: {id}, Name: {name}, SymbolCurrency: {symbol}, PriceUsd: {priceUsd}, Change_to_24_Hr: {changePercent24Hr}%, Volume_Usd_24_Hr {volumeUsd24Hr}, Supply: {supply}.";
        }
    }
}
