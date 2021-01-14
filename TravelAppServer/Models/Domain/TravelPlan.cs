using System;
using System.Collections.Generic;

namespace TravelApp.Models
{
    public class TravelPlan
    {
        #region properties
        private string _name;
        private string _destination;

        public int TravelPlanId
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

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Destination
        {
            get
            {
                return _destination;
            }

            set
            {
                _destination = string.IsNullOrWhiteSpace(value) ? "-" : value;
            }
        }

        public ICollection<TravelItem> ItemList { get; private set; }
        public ICollection<TravelTask> TaskList { get; private set; }
        public ICollection<TravelRoute> RouteList { get; private set; }
        #endregion

        public TravelPlan(string name, DateTime startDate, DateTime endDate, string destination)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Destination = destination;
            ItemList = new List<TravelItem>();
            TaskList = new List<TravelTask>();
            RouteList = new List<TravelRoute>();
        }

        public void AddTravelItem(TravelItem travelItem)
        {
            ItemList.Add(travelItem);
        }

        public void AddTravelTask(TravelTask travelTask)
        {
            TaskList.Add(travelTask);
        }

        public void AddTravelRoute(TravelRoute travelRoute)
        {
            RouteList.Add(travelRoute);
        }
    }
}
