using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using CryptocurrenciesMonitoring.Models;
using System.Net;
using System.IO;

namespace CryptocurrenciesMonitoring.Services
{
    class DataService
    {
        private CryptoList cryptoList;
        public CryptoList CryptoList { get => cryptoList;}

        private readonly HttpClient client;

        //public Currencies currencies;

        string ApiCoinCapDef = "https://api.coincap.io/v2/";
        string assetsCoinCap = "assets";
        string bitcoinId = "/bitcoin";
        string candlesCoinCap = "candles?exchange=poloniex&interval=h8&baseId=ethereum&quoteId=bitcoin";

        string ApiRequestCrypt = "https://www.cryptingup.com/api";
        string allMarketsCrypt = "/markets";
        string cryptAssets = "/assets";
        string bitcId = "/BTC";

        //string allCoins = "coins/list";
        //string tokenPrice = "/simple/token/price/" + "id";
        //string coinsMarkets = "coins/markets";
        //string coinPlatform = "/asset_platforms";
        //string binanceId = "binancecoin";
        //string supported_vs_currencies = "/simple/supported_vs_currencies";
        //string requestCoinGeco = "https://api.coingecko.com/api/v3/" + "/coins/";
        public DataService()
        {
            //currencies = new Currencies();
            client = new HttpClient();
            LoadFromApi();
        }
        
        public string LoadFromApi(string apiComand = null)   
        {
            string apiRequest = ApiCoinCapDef + assetsCoinCap;
            if (!string.IsNullOrEmpty(apiComand))
                apiRequest = ApiCoinCapDef + apiComand;
            HttpWebRequest request = WebRequest.CreateHttp(apiRequest);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string readData;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                readData = reader.ReadToEnd();
            }
            return readData;
        }
        public CryptoList CryptoListFromApi()
        {
            string apiResponse = LoadFromApi();
            cryptoList = JsonConvert.DeserializeObject<CryptoList>(apiResponse);
            return cryptoList;
        }

        public void LoadData()    
        {
            
            //for (int i = 0; i < contentList.Data.Count; i++)
            //{
            //    currencies.dataGridCurrencies.Items.Add(contentList.Data[i]);
            //}
            //currencies.dataGridCurrencies.ItemsSource = content.Data;
        }
    }
}
