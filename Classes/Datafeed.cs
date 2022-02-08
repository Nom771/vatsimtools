using System;
using System.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using Windows.Data.Json;
using Windows.UI.Xaml.Shapes;

namespace VatTools
{
    public class Datafeed
    {
        public static void DataRetrieval(string FrequencyBoxText)
        {
            /*
             * MASSIVE credit is due to Marvin K (https://github.com/marvk/vatprism) for assistance with FIR calculation methods
             */
            WebClient client = new WebClient();
            DataStorage.PilotList.Clear();
            DataStorage.PilotsOnFrequency.Clear();
            DataStorage.ControllerList.Clear();
            DataStorage.ControllersOnFrequency.Clear();
            DataStorage.TranscieverRootData.Clear();
            DataStorage.FullDatafeed = null;
            string MainDataFeed = "https://data.vatsim.net/v3/vatsim-data.json";
            string TranscieverFeed = "https://data.vatsim.net/v3/transceivers-data.json";
            var val = client.DownloadString(TranscieverFeed);
            var datafeedval = client.DownloadString(MainDataFeed);
            DataStorage.TranscieverRootData = JsonSerializer.Deserialize<List<Root>>(val);
            DataStorage.FullDatafeed = JsonSerializer.Deserialize<FeedRoot>(datafeedval);
            if (DataStorage.TranscieverRootData != null)
            {
                foreach (Root rt in DataStorage.TranscieverRootData)
                {
                    foreach (Transceiver trnscv in rt.Transcievers)
                    {
                        if (trnscv != null && trnscv.frequency != 0 && trnscv.frequency.ToString().Length >= 6)
                        {
                            if (trnscv.frequency.ToString().Substring(0, 6) == FrequencyBoxText || trnscv.frequency.ToString().Substring(0, 6) == (Convert.ToDouble(FrequencyBoxText) * 1000).ToString())
                            {
                                if (rt.Callsign.Contains("_"))
                                {
                                    DataStorage.ControllersOnFrequency.Add(rt);
                                    continue;
                                }
                                DataStorage.PilotsOnFrequency.Add(rt);
                            }
                        }
                    }
                }
                if (DataStorage.FullDatafeed != null)
                {
                    foreach (Root root in DataStorage.PilotsOnFrequency)
                    {
                        if (DataStorage.FullDatafeed.Pilots.Find(cs => cs.Callsign == root.Callsign) != null)
                        {
                            var PilotToAdd = DataStorage.FullDatafeed.Pilots.Find(cs => cs.Callsign == root.Callsign);
                            /*if (IsInPolygon(
                                    DataStorage.FIRList.FirstOrDefault(cs => cs.firName == "NAT").firPoints,
                                    new PointF(Convert.ToSingle(PilotToAdd.Latitude),
                                        Convert.ToSingle(PilotToAdd.Longitude))))
                            {
                                if (PilotToAdd.FlightPlan == null || string.IsNullOrWhiteSpace(PilotToAdd.FlightPlan.AircraftFaa))
                                {
                                    DataStorage.PilotList.Add(new PilotInfo(PilotToAdd.Callsign, PilotToAdd.Transponder, "NOFP", PilotToAdd.Altitude, PilotToAdd.Groundspeed, "UNK", "NOFP", "NOFP"));
                                }
                                else
                                {
                                    DataStorage.PilotList.Add(new PilotInfo(PilotToAdd.Callsign, PilotToAdd.Transponder, PilotToAdd.FlightPlan.AssignedTransponder, PilotToAdd.Altitude, PilotToAdd.Groundspeed, PilotToAdd.FlightPlan.AircraftFaa, PilotToAdd.FlightPlan.Departure, PilotToAdd.FlightPlan.Arrival));
                                }
                            }*/
                            if (PilotToAdd.FlightPlan == null || string.IsNullOrWhiteSpace(PilotToAdd.FlightPlan.AircraftFaa))
                            {
                                DataStorage.PilotList.Add(new PilotInfo(PilotToAdd.Callsign, PilotToAdd.Transponder, "NOFP", PilotToAdd.Altitude, PilotToAdd.Groundspeed, "UNK", "NOFP", "NOFP"));
                            }
                            else
                            {
                                DataStorage.PilotList.Add(new PilotInfo(PilotToAdd.Callsign, PilotToAdd.Transponder, PilotToAdd.FlightPlan.AssignedTransponder, PilotToAdd.Altitude, PilotToAdd.Groundspeed, PilotToAdd.FlightPlan.AircraftFaa, PilotToAdd.FlightPlan.Departure, PilotToAdd.FlightPlan.Arrival));
                            }
                        }
                    }
                    foreach (Root root in DataStorage.ControllersOnFrequency)
                    {
                        if (DataStorage.FullDatafeed.Controllers.Find(cs => cs.Callsign == root.Callsign) != null && DataStorage.ControllerList.FirstOrDefault(cs => cs.Callsign == root.Callsign) == null)
                        {
                            var ControllerToAdd = DataStorage.FullDatafeed.Controllers.Find(cs => cs.Callsign == root.Callsign);
                            DataStorage.ControllerList.Add(new ControllerInfo(ControllerToAdd.Name, ControllerToAdd.Callsign));
                        }
                    }
                }
            }
        }
        public static bool IsInPolygon(PointF[] poly, PointF point)
        {
            var coef = poly.Skip(1).Select((p, i) =>
                    (point.Y - poly[i].Y) * (p.X - poly[i].X)
                    - (point.X - poly[i].X) * (p.Y - poly[i].Y))
                .ToList();

            if (coef.Any(p => p == 0))
                return true;

            for (int i = 1; i < coef.Count(); i++)
            {
                if (coef[i] * coef[i - 1] < 0)
                    return false;
            }
            return true;
        }
    }
}
