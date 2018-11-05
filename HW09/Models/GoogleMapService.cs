using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;

namespace HW09.Models
{
    public class GoogleMapService : IMapService
    {
        public string GetDirections(string start, string end)
        {
            string url = @"https://maps.googleapis.com/maps/api/directions/json?origin=" + start 
                + "&destination=" + end 
                + "&key="+ GetGoogleAPIKey();

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();

            Stream data = response.GetResponseStream();
            StreamReader reader = new StreamReader(data);

            string responseFromServer = reader.ReadToEnd();
            response.Close();

            RootObject result = JsonConvert.DeserializeObject<RootObject>(responseFromServer);

            string directionsResult = "";
            int stepCounter = 0;
            foreach (Step s in result?.routes[0]?.legs[0].steps)
            {
                stepCounter++;
                directionsResult += $"Step {stepCounter} {RemoveHtml(s.html_instructions)} " +
                    $"\n    Duration: {s.duration.value.ToString()} Distance: {s.distance.value.ToString()} \n";
            }
            return directionsResult;
        }

        public string RemoveHtml(string html)
        {
            return Regex.Replace(html, @"\<.*?\>", "");
            string regex = "(<.*>)";
            return Regex.Replace(html, regex, "");
        }

        private static string GetGoogleAPIKey()
        {
            var configurationBuilder = new ConfigurationBuilder()
                            .AddUserSecrets("MapsAPIKey");
            var config = configurationBuilder.Build();
            var mapsId = config["MapsAPIKey"];
            return mapsId;
        }
    }

    public class GeocodedWaypoint
    {
        public string geocoder_status { get; set; }
        public string place_id { get; set; }
        public List<string> types { get; set; }
    }

    public class Northeast
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Southwest
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Bounds
    {
        public Northeast northeast { get; set; }
        public Southwest southwest { get; set; }
    }

    public class Distance
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Duration
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class EndLocation
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class StartLocation
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Distance2
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Duration2
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class EndLocation2
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Polyline
    {
        public string points { get; set; }
    }

    public class StartLocation2
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Step
    {
        public Distance2 distance { get; set; }
        public Duration2 duration { get; set; }
        public EndLocation2 end_location { get; set; }
        public string html_instructions { get; set; }
        public Polyline polyline { get; set; }
        public StartLocation2 start_location { get; set; }
        public string travel_mode { get; set; }
        public string maneuver { get; set; }
    }

    public class Leg
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        public string end_address { get; set; }
        public EndLocation end_location { get; set; }
        public string start_address { get; set; }
        public StartLocation start_location { get; set; }
        public List<Step> steps { get; set; }
        public List<object> traffic_speed_entry { get; set; }
        public List<object> via_waypoint { get; set; }
    }

    public class OverviewPolyline
    {
        public string points { get; set; }
    }

    public class Route
    {
        public Bounds bounds { get; set; }
        public string copyrights { get; set; }
        public List<Leg> legs { get; set; }
        public OverviewPolyline overview_polyline { get; set; }
        public string summary { get; set; }
        public List<object> warnings { get; set; }
        public List<object> waypoint_order { get; set; }
    }

    public class RootObject
    {
        public List<GeocodedWaypoint> geocoded_waypoints { get; set; }
        public List<Route> routes { get; set; }
        public string status { get; set; }
    }
}
