﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
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
            Datafeed.DataRetrieval(FrequencyBox.Text);
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
    }
}