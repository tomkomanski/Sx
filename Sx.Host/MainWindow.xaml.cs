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
        InitializeCustom();
    }

    private void InitializeCustom()
    {
        Table_kind.ItemsSource = Enum.GetValues(typeof(NbpTableKind));
        Table_kind.SelectedItem = NbpTableKind.A;
    }

    private async void ButtonGetCurrentData_Click(object sender, RoutedEventArgs e)
    {
        ButtonGetCurrentData.IsEnabled = false;
        CurrencyDataGrid.ItemsSource = null;

        NbpTableKind nbpTableKind = (NbpTableKind)Table_kind.SelectedItem;

        MessageRequestCurrentExchangeRates messageRequestCurrentExchangeRates = new()
        {
            NbpTableType = nbpTableKind
        };

        MessageResponseApplicationSx messageResponseApplicationSx = await this.applicationSx.GetCurrentExchangeRatesTable(messageRequestCurrentExchangeRates);
        if (messageResponseApplicationSx.IsSuccessed)
        {
            CurrencyDataGrid.ItemsSource = messageResponseApplicationSx.CurrencyData;
        }
        else
        {
            MessageBox.Show(messageResponseApplicationSx.Errors, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        ButtonGetCurrentData.IsEnabled = true;
    }
}