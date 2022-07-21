using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.IO;
using System.Net;
using RestSharp;
using Newtonsoft.Json;

namespace CryptocurrenciesMonitoring
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Page> pages;
        CurrencyConvert currencyConvert;
        Currencies currencies;
        public MainWindow()
        {
            InitializeComponent();
            this.pages =  new List<Page>();

            currencyConvert = new CurrencyConvert();
            currencies = new Currencies();
            ProjectFrame.Content = currencies;
            InitializeData();

        }
        string ApiRequestCrypto = "https://www.cryptingup.com/api";
        string allMarketsCrypto = "/markets";
        string ApiCoinCapDef = "https://api.coincap.io/v2/";
        string assetsCoinCap = "assets";
        string candlesCoinCap = "candles?exchange=poloniex&interval=h8&baseId=ethereum&quoteId=bitcoin";
        //string allCoins = "coins/list";
        //string tokenPrice = "/simple/token/price/" + "id";
        //string coinsMarkets = "coins/markets";
        //string coinPlatform = "/asset_platforms";
        //string binanceId = "binancecoin";
        //string supported_vs_currencies = "/simple/supported_vs_currencies";
        //string requestCoinGeco = "https://api.coingecko.com/api/v3/" + "/coins/";
        public void InitializeData()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.CreateHttp(ApiCoinCapDef + assetsCoinCap);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            string readData = reader.ReadToEnd();
            string[] parsStr = readData.Split('}');
            foreach(var item in parsStr)
            {
                currencies.CurrenciesListBox.Items.Add(item);
            }
            
            var readStr = JsonConvert.DeserializeObject(readData);
            
            //foreach(var item in readStr)
            //{
            //    currencies.CurrenciesListBox.Items.Add(item);
            //}
            response.Close();
        }

        //public string PrettyJson(string unPrettyJson)
        //{
        //    var options = new JsonSerializerOptions()
        //    {
        //        WriteIndented = true
        //    };
        //    return null;
        //}

        private void Dark_Click(object sender, RoutedEventArgs e)
        {
            MainStackPanel.Background = Brushes.Gray;
            currencies.Background = Brushes.DimGray;
            currencyConvert.Background = Brushes.DimGray;
        }

        private void Light_Click(object sender, RoutedEventArgs e)
        {
            MainStackPanel.Background = Brushes.WhiteSmoke;
            ProjectFrame.Background = Brushes.WhiteSmoke;
        }

        private void Light_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void SearchCurrency_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Main_Currencies_Click(object sender, RoutedEventArgs e)
        {
            ProjectFrame.Content = currencies;
        }

        private void ConvertCurrency_Click(object sender, RoutedEventArgs e)
        {
            ProjectFrame.Content = currencyConvert;
        }
    }
}
