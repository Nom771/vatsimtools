using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VatTools
{
    public class DataStorage
    {
        public static ObservableCollection<Root> ControllersOnFrequency = new ObservableCollection<Root>();
        public static ObservableCollection<ControllerInfo> ControllerList = new ObservableCollection<ControllerInfo>();
        public static ObservableCollection<Root> PilotsOnFrequency = new ObservableCollection<Root>();
        public static ObservableCollection<PilotInfo> PilotList = new ObservableCollection<PilotInfo>();
        public static List<Root> TranscieverRootData = new List<Root>();
        public static FeedRoot FullDatafeed = new FeedRoot();
        public static bool AutoRefresh = false;
    }
}
