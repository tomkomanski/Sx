using Sx.ApplicationServices;
using Sx.Messages.ApplicationServices;
using Sx.Models;
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

        this.GetCurrentExchangesRates(NbpTableType.A);
    }

    public async Task<MessageResponseApplicationSx> GetCurrentExchangesRates(NbpTableType nbpTableType)
    {
        MessageRequestCurrentExchangeRates messageRequestCurrentExchangeRates = new()
        {
            NbpTableType = nbpTableType
        };

        var test = await this.applicationSx.GetCurrentExchangeRatesTable(messageRequestCurrentExchangeRates);

        return test;
    }
}