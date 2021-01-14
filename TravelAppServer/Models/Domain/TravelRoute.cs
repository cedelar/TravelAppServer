using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Models
{
    public class TravelRoute
    {
        private string _name;
        private string _description;

        public int TravelRouteId
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
        public ICollection<TravelLocation> Locations { get; private set; }
        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = string.IsNullOrWhiteSpace(value) ? "No description" : value;
            }
        }

        public TravelRoute(string name, string description)
        {
            this.Name = name;
            this.Description = description;
            this.Locations = new List<TravelLocation>();
        }
        public TravelRoute(string name, string description, ICollection<TravelLocation> locations)
        {
            this.Name = name;
            this.Description = description;
            this.Locations = locations;
        }


        public void AddTravelLocation(TravelLocation travelLocation)
        {
            Locations.Add(travelLocation);
        }
    }
}
