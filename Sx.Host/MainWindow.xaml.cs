﻿using Sx.ApplicationServices;
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
    }

    private async void ButtonGetCurrentData_Click(object sender, RoutedEventArgs e)
    {
        ButtonGetCurrentData.IsEnabled = false;

        MessageRequestCurrentExchangeRates messageRequestCurrentExchangeRates = new()
        {
            NbpTableType = NbpTableType.A
        };

        var test = await this.applicationSx.GetCurrentExchangeRatesTable(messageRequestCurrentExchangeRates);

        ButtonGetCurrentData.IsEnabled = true;
    }
}