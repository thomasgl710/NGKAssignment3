using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGKAssignment3.Models
{
    public class WeatherStation
    {
        public WeatherStation(string name, int lat, int lon)
        {
            Name = name;
            Lat = lat;
            Lon = lon;
        }
        public string Name{ get; set;}
        public int Lat { get; set; }
        public int Lon { get; set; }
        public DateTime Time { get; set; }
        public float Temperatur { get; set; }
        public int Humidity { get; set; }
        public float AirPressure { get; set; }

    }
}
