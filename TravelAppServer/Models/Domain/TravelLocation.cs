using Newtonsoft.Json;
using System;

namespace TravelApp.Models
{
    public class TravelLocation
    {
        private string _name;
        private string _location;

        public int TravelLocationId
        {
            get; set;
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name is required");
                _name = value;
            }
        }

        public string Location
        {
            get
            {
                return _location;
            }

            set
            {
                _location = string.IsNullOrWhiteSpace(value) ? "Unknown Location" : value;
            }
        }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [JsonConstructor]
        public TravelLocation(string name, string location, double latitude, double longitude)
        {
            Name = name;
            Location = location;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
