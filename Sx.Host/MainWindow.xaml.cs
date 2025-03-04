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
using Sx.ApplicationServices;
using Sx.Messages.ApplicationServices;
using Sx.Models;

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
        this.TableKindCurrent.ItemsSource = Enum.GetValues(typeof(NbpTableKind));
        this.TableKindCurrent.SelectedItem = NbpTableKind.A;

        this.TableKindArchived.ItemsSource = Enum.GetValues(typeof(NbpTableKind));
        this.TableKindArchived.SelectedItem = NbpTableKind.A;
    }

    private async void ButtonGetCurrentData_Click(object sender, RoutedEventArgs e)
    {
        this.ButtonGetCurrentData.IsEnabled = false;
        this.CurrencyDataGrid.ItemsSource = null;

        NbpTableKind nbpTableKind = (NbpTableKind)TableKindCurrent.SelectedItem;

        MessageRequestCurrentExchangeRates messageRequestCurrentExchangeRates = new()
        {
            NbpTableType = nbpTableKind
        };

        MessageResponseApplicationSx messageResponseApplicationSx = await this.applicationSx.GetCurrentExchangeRatesTable(messageRequestCurrentExchangeRates);
        if (messageResponseApplicationSx.IsSuccessed)
        {
            this.CurrencyDataGrid.ItemsSource = messageResponseApplicationSx.CurrencyData;
        }
        else
        {
            MessageBox.Show(messageResponseApplicationSx.Errors, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        this.ButtonGetCurrentData.IsEnabled = true;
    }

    private async void ButtonGetArchivedData_Click(object sender, RoutedEventArgs e)
    {
        this.ButtonGetCurrentData.IsEnabled = false;
        this.CurrencyDataGrid.ItemsSource = null;

        NbpTableKind nbpTableKind = (NbpTableKind)TableKindCurrent.SelectedItem;

        MessageRequestCurrentExchangeRates messageRequestCurrentExchangeRates = new()
        {
            NbpTableType = nbpTableKind
        };

        MessageResponseApplicationSx messageResponseApplicationSx = await this.applicationSx.GetCurrentExchangeRatesTable(messageRequestCurrentExchangeRates);
        if (messageResponseApplicationSx.IsSuccessed)
        {
            this.CurrencyDataGrid.ItemsSource = messageResponseApplicationSx.CurrencyData;
        }
        else
        {
            MessageBox.Show(messageResponseApplicationSx.Errors, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        this.ButtonGetCurrentData.IsEnabled = true;
    }

    private void TextOnlyFourDigitAndControl(object sender, TextCompositionEventArgs e)
    {
        if (this.TextBoxYear.SelectionLength > 0)
        {
            this.TextBoxYear.SelectedText = String.Empty;
        }

        foreach (char c in e.Text)
        {
            if (char.IsDigit(c) || char.IsControl(c))
            {
                TextBox textBox = sender as TextBox;
                if (textBox.Text.Length >= 4)
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }
            else
            {
                e.Handled = true;
            }
        }
    }

    private void TextYearValidating(object sender, TextChangedEventArgs e)
    {
        Int32 year;
        if (String.IsNullOrEmpty(this.TextBoxYear.Text))
        {
            this.TextBoxYear.Background = new SolidColorBrush(Colors.White);
        }
        else if (!Int32.TryParse(this.TextBoxYear.Text, out year))
        {
            this.TextBoxYear.Background = new SolidColorBrush(Colors.Pink);
        }
        else
        {
            this.TextBoxYear.Background = new SolidColorBrush(Colors.White);
        }
    }

    private void TextLostFocus(object sender, RoutedEventArgs e)
    {
        Int32 year;
        if (String.IsNullOrEmpty(this.TextBoxYear.Text))
        {
            this.TextBoxYear.Background = new SolidColorBrush(Colors.White);
        }
        else if (!Int32.TryParse(this.TextBoxYear.Text, out year))
        {
            this.TextBoxYear.Background = new SolidColorBrush(Colors.Pink);
        }
        else
        {
            if (year < 2000 || year > DateTime.Now.Year)
            {
                this.TextBoxYear.Background = new SolidColorBrush(Colors.Pink);
            }
            else
            {
                this.TextBoxYear.Background = new SolidColorBrush(Colors.White);
            }
        }
    }

    private void ComboBoxMonthFilling(object sender, EventArgs e)
    {
        Dictionary<Int32, String> monthsPattern = new Dictionary<Int32, String>()
        {
            { 0, "" },
            { 1, "Styczeń" },
            { 2, "Luty" },
            { 3, "Marzec" },
            { 4, "Kwiecień" },
            { 5, "Maj" },
            { 6, "Czerwiec" },
            { 7, "Lipiec" },
            { 8, "Sierpień" },
            { 9, "Wrzesień" },
            { 10, "Październik" },
            { 11, "Listopad" },
            { 12, "Grudzień" },
        };

        Dictionary<Int32, String> months = new Dictionary<Int32, String>();

        Int32 year;
        if (!String.IsNullOrEmpty(this.TextBoxYear.Text) && Int32.TryParse(this.TextBoxYear.Text, out year))
        {
            if (year == DateTime.Now.Year)
            {
                for (Int32 i = 1; i <= DateTime.Now.Month; i++)
                {
                    months.Add(i, monthsPattern[i]);
                }

                this.ComboBoxMonths.ItemsSource = months.Values;
            }
            else if (year < DateTime.Now.Year)
            {
                for (Int32 i = 1; i < monthsPattern.Count; i++)
                {
                    months.Add(i, monthsPattern[i]);
                }

                this.ComboBoxMonths.ItemsSource = months.Values;
            }
            else
            {
                this.ComboBoxMonths.ItemsSource = null;
            }
        }
        else
        {
            this.ComboBoxMonths.ItemsSource = null;
        }
    }
}