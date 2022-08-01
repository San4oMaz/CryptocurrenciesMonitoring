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

namespace CryptocurrenciesMonitoring
{
    /// <summary>
    /// Логика взаимодействия для Currencies.xaml
    /// </summary>
    public partial class Currencies : Page
    {
        CurrencyInfo currencyInfo;
        public Currencies()
        {
            InitializeComponent();
            currencyInfo = new CurrencyInfo();
        }

        private void Data_Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridCurrencies.SelectedItem != null)
            {
                currencyInfo.InfoTextBlock.Text = dataGridCurrencies.SelectedValue.ToString();
            }
        }
    }
}
