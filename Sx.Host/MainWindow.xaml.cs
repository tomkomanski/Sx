using Sx.ApplicationServices;
using Sx.Messages.ApplicationServices;
using Sx.Models;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sx.Host;

public partial class MainWindow : Window
{
    private readonly IApplicationSx applicationSx;

    public MainWindow(IApplicationSx applicationSx)
    {
        this.applicationSx = applicationSx;
        InitializeComponent();
        //InitializeCustom();
    }

    private void InitializeCustom()
    {
        CurrencyDataGrid.ItemsSource = new List<CurrencyData>();
    }

    private async void ButtonGetCurrentData_Click(object sender, RoutedEventArgs e)
    {
        ButtonGetCurrentData.IsEnabled = false;
        CurrencyDataGrid.ItemsSource = new List<CurrencyData>();

        MessageRequestCurrentExchangeRates messageRequestCurrentExchangeRates = new()
        {
            NbpTableType = NbpTableType.A
        };

        MessageResponseApplicationSx messageResponseApplicationSx = await this.applicationSx.GetCurrentExchangeRatesTable(messageRequestCurrentExchangeRates);
        if (messageResponseApplicationSx.IsSuccessed)
        {
            CurrencyDataGrid.ItemsSource = null;
            CurrencyDataGrid.ItemsSource = messageResponseApplicationSx.CurrencyData;
        }
        else
        {
            // ToDo error handling
        }

        ButtonGetCurrentData.IsEnabled = true;
    }
}