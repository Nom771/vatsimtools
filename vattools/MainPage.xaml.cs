using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Drawing;
using System.Text.RegularExpressions;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Microsoft.Toolkit.Uwp.UI.Helpers;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace VatTools
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ContentFrame.Navigate(typeof(FrequencyManager));
        }
        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            WebClient wc = new WebClient();
            var Listener = new ThemeListener();
            var MapFeed = "https://github.com/vatsimnetwork/vatspy-data-project/releases/download/v2201.1/FIRBoundaries.dat";
            var mapdata = wc.DownloadString(MapFeed);
            using (StringReader reader = new StringReader(mapdata))
            {
                string line;
                string firName = null;
                List<PointF> pts = new List<PointF>();
                while ((line = reader.ReadLine()) != null)
                {
                    if (Regex.IsMatch(line, @"[a-zA-Z]") && firName == null)
                    {
                        if(line.Split("|")[1] == "1")
                        {
                            firName = line.Split("|")[0] + "-OCA";
                        } else
                        {
                            firName = line.Split("|")[0];
                        }
                    }
                    else if (Regex.IsMatch(line, @"[a-zA-Z]") && firName != null)
                    {
                        DataStorage.FIRList.Add(new FIR(firName, pts.ToArray()));
                        pts.Clear();
                        if (line.Split("|")[1] == "1")
                        {
                            firName = line.Split("|")[0] + "-OCA";
                        }
                        else
                        {
                            firName = line.Split("|")[0];
                        }
                    }
                    else
                    {
                        var splits = line.Split("|");
                        pts.Add(new PointF(float.Parse(splits[0]), float.Parse(splits[1])));
                    }
                }
            }
            //
            Listener.ThemeChanged += Listener_ThemeChanged;
            switch (Listener.CurrentThemeName)
            {
                case "Dark":
                    MainNavigationView.Background = new SolidColorBrush(Colors.Black);
                    return;
                case "Light":
                    MainNavigationView.Background = new SolidColorBrush(Colors.LightGray);
                    return;
            }
        }
        private void Listener_ThemeChanged(ThemeListener sender)
        {
            switch (sender.CurrentThemeName)
            {
                case "Dark":
                    MainNavigationView.Background = new SolidColorBrush(Colors.Black);
                    return;
                case "Light":
                    MainNavigationView.Background = new SolidColorBrush(Colors.LightGray);
                    return;
            }
        }
        private void PageNavigation(NavigationView sender,
            NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
            }
            else
            {
                var item = args.SelectedItem as NavigationViewItem;
                switch (item.Tag.ToString())
                {
                    case "Frequency":
                        ContentFrame.Navigate(typeof(FrequencyManager));
                        break;
                }
            }
        }
    }
}
