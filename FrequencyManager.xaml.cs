using System;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Microsoft.Toolkit.Uwp.UI.Helpers;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace VatTools
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FrequencyManager : Page
    {
        public FrequencyManager()
        {
            this.InitializeComponent();
            FreqInfoGrid.ItemsSource = null;
            ControllerListGrid.ItemsSource = null;
            FIRSelection.ItemsSource = DataStorage.FIRList;
            FIRSelection.DisplayMemberPath = "firName";
            FIRSelection.SelectedValuePath = "firName";
            ThemeListener listener = new ThemeListener();
            listener.ThemeChanged += Listener_ThemeChanged;
            switch (listener.CurrentThemeName)
            {
                case "Dark":
                    DisplayGrid.Background = new SolidColorBrush(Colors.Black);
                    return;
                case "Light":
                    DisplayGrid.Background = new SolidColorBrush(Colors.LightGray);
                    return;
            }
        }
        private void Listener_ThemeChanged(ThemeListener sender)
        {
            switch (sender.CurrentThemeName)
            {
                case "Dark":
                    DisplayGrid.Background = new SolidColorBrush(Colors.Black);
                    return;
                case "Light":
                    DisplayGrid.Background = new SolidColorBrush(Colors.LightGray);
                    return;
            }
        }
        private void FrequencyChange_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FrequencyBox.Text) || FrequencyBox.Text.Length < 6) return;
            FrequencyChange.Content = "Updating...";
            if(FIRSelection.SelectedItem != null)
            {
                Datafeed.DataRetrieval(FrequencyBox.Text, Convert.ToString(FIRSelection.SelectedValue));
            } else
            {
                Datafeed.DataRetrieval(FrequencyBox.Text, null);
            }
            FrequencyChange.Content = "Update Frequency";
            FreqInfoGrid.ItemsSource = DataStorage.PilotList;
            ControllerListGrid.ItemsSource = DataStorage.ControllerList;
        }
        private void ClearData(object sender, RoutedEventArgs e)
        {
            DataStorage.PilotList.Clear();
            DataStorage.PilotsOnFrequency.Clear();
            DataStorage.ControllerList.Clear();
            DataStorage.ControllersOnFrequency.Clear();
            FreqInfoGrid.ItemsSource = DataStorage.PilotList;
            ControllerListGrid.ItemsSource = DataStorage.ControllerList;
        }
        private async void AutoRefresh_OnChecked(object sender, RoutedEventArgs e)
        {
            DataStorage.AutoRefresh = true;
            while (DataStorage.AutoRefresh)
            {
                int delay = 30000;
                if (int.TryParse(RefreshDelay.Text, out delay))
                {
                    if (delay <= 1)
                    {
                        delay = 30000;
                    }
                    else
                    {
                        delay *= 1000;
                    }
                }
                else
                {
                    delay = 30000;
                }
                if (string.IsNullOrWhiteSpace(FrequencyBox.Text) || FrequencyBox.Text.Length < 6) return;
                FrequencyChange.Content = "Updating...";
                if (FIRSelection.SelectedItem != null)
                {
                    Datafeed.DataRetrieval(FrequencyBox.Text, Convert.ToString(FIRSelection.SelectedValue));
                }
                else
                {
                    Datafeed.DataRetrieval(FrequencyBox.Text, null);
                }
                FrequencyChange.Content = "Update Frequency";
                FreqInfoGrid.ItemsSource = DataStorage.PilotList;
                ControllerListGrid.ItemsSource = DataStorage.ControllerList;
                await Task.Delay(delay);
            }
        }
        private void AutoRefresh_OnUnchecked(object sender, RoutedEventArgs e)
        {
            DataStorage.AutoRefresh = false;
        }
    }
}
