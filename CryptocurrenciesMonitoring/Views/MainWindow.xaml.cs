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
using System.Text.Json;
using System.Net.Http;

using CryptocurrenciesMonitoring.Models;
using CryptocurrenciesMonitoring.Services;
using CryptocurrenciesMonitoring.ViewModels;
using System.Windows.Markup;
using System.Globalization;

namespace CryptocurrenciesMonitoring.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel viewModel;
        public CurrencyConvert currencyConvert;
        public Currencies currencies;
        public CurrencyInfo currencyInfo;
        CryptoList content;

        private readonly HttpClient client;
        DataService data;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainWindowViewModel();
            DataContext = viewModel;
            //data = new DataService();
            ControlStartWindows();
            
            //client = new HttpClient();            

            //InitLonguageCombo();
        }

        public void ControlStartWindows()
        {
            currencyConvert = viewModel.currencyConvert;
            currencies = viewModel.currencies;
            currencyInfo = viewModel.currencyInfo;
            ProjectFrame.Content = currencies;

        }

        


        public void InitLonguageCombo()
        {
            string[] languages = new string []{ "eng-Eng", "uk-UA" };            
            var lang = CultureInfo.CurrentUICulture;
            
            currencyConvert.cultureInform.Text = lang.DisplayName.ToString();
            foreach(var item in languages)
            {
                LaguagesCombo.Items.Add(item);
            }

           // MainStackPanel.Language = XmlLanguage.GetLanguage(LaguagesCombo.SelectedItem.ToString());
        }
        public XmlLanguage ExchangeLanguage()
        {

            //XmlLanguage.GetLanguage

            return null;
        }


        private void Dark_Click(object sender, RoutedEventArgs e)
        {
            MainStackPanel.Background = Brushes.Gray;           
            

            currencies.Background = Brushes.DimGray;
            currencyConvert.Background = Brushes.DimGray;
            currencies.dataGridCurrencies.Background = Brushes.DimGray;
            currencies.dataGridCurrencies.Foreground = Brushes.White;
            //currencies.dataGridCurrencies.AlternatingRowBackground = Brushes.Red;
            currencies.dataGridCurrencies.RowBackground = Brushes.DimGray;
            currencies.mainGridCurrencies.Background = Brushes.DimGray;
        }

        private void Light_Click(object sender, RoutedEventArgs e)
        {
            MainStackPanel.Background = Brushes.WhiteSmoke;
            ProjectFrame.Background = Brushes.WhiteSmoke;
            currencies.Background = Brushes.WhiteSmoke;
            currencyConvert.Background = Brushes.WhiteSmoke;
            currencies.dataGridCurrencies.Foreground = Brushes.Black;
            currencies.dataGridCurrencies.Background = Brushes.WhiteSmoke;
            currencies.dataGridCurrencies.RowBackground = Brushes.WhiteSmoke;
            currencies.mainGridCurrencies.Background = Brushes.WhiteSmoke;
        }

        private void SearchCurrency_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(NameCurrencyTextBox.Text) || !string.IsNullOrWhiteSpace(NameCurrencyTextBox.Text))
            {
                foreach(Crypto cr in data.CryptoList.Data)
                {
                    if(cr.id == NameCurrencyTextBox.Text.ToLower() || cr.symbol == NameCurrencyTextBox.Text.ToUpper())
                    {
                        currencyInfo.InfoTextBlock.Text = cr.ToString();
                        ProjectFrame.Content = currencyInfo;
                    }
                }                 
            }            
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
