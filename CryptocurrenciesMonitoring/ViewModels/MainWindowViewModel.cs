using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using CryptocurrenciesMonitoring.Models;
using CryptocurrenciesMonitoring.Services;
using CryptocurrenciesMonitoring.Commands;
using CryptocurrenciesMonitoring.Views;
using System.Windows;
using System.Runtime.CompilerServices;

namespace CryptocurrenciesMonitoring.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {

        private Crypto selectedCrypto;          // для привязки до DataGrid SelectedItem.
        public Crypto SelectedCrypto
        {
            get { return selectedCrypto; }
            set { selectedCrypto = value; OnPropertyChanged("SelectedCrypto"); }
        }
        DataService dataService;
        public readonly CryptoList cryptoList;

        public CurrencyConvert currencyConvert;
        public Currencies currencies;
        public CurrencyInfo currencyInfo;

        /// <summary>
        /// Для оповіщення елементів про зміни.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }       

        public MainWindowViewModel()
        {
            ControlStartWindows();
            dataService = new DataService();
            cryptoList = dataService.CryptoListFromApi();
            InitializeCurrencies();

            //CloseApplicationCommand = new DelegateCommand(OnCloseApplicationCommand, CanCloseApplicationCommand);
            InitializeCurrencyInfo();
        }

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }
        private bool CanCloseApplicationCommand(object ob) => true;
        private void OnCloseApplicationCommand(object ob)
        {
            Application.Current.Shutdown();         // Потім привязуєм команду в MainWindow.xaml - Command={Binding CloseApplicationCommand}. 
        }
        #endregion

        public void ControlStartWindows()
        {
            currencyConvert = new CurrencyConvert();
            currencies = new Currencies();
            currencyInfo = new CurrencyInfo();
        }
        private void InitializeCurrencies()
        {
            for (int i = 0; i < cryptoList.Data.Count; i++)
            {
                currencies.dataGridCurrencies.Items.Add(cryptoList.Data[i]);
            }
            //currencies.dataGridCurrencies.ItemsSource = cryptoList.Data;
        }

        private void InitializeCurrencyInfo()
        {
            if(currencies.dataGridCurrencies.SelectedItem != null)
            {
                currencyInfo.dataGridCurrencyInfo.Items.Add(selectedCrypto);

            }
        }

    }
}
