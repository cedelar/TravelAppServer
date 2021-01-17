using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelApp.Models
{
    public class User
    { 
        private string _userName;
        private string _password;

        public int UserId
        {
            get; set;
        }

        public string UserName {
            get
            {
            return _userName;
            }

            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Username is required");
                _userName = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Password is required");
                _password = value;
            }
        }

        public ICollection<TravelPlan> Travelplans { get; set; }

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
            Travelplans = new List<TravelPlan>();
        }

        public ICollection<TravelPlan> getTravelPlan(string name)
        {
            return this.Travelplans.Where(t => t.Name == name).ToList();
        }

        public void AddTravelPlan(TravelPlan travelPlan)
        {
            Travelplans.Add(travelPlan);
        }

        public void RemoveTravelPlan(string name)
        {
            this.Travelplans.Where(t => t.Name == name).ToList().ForEach(e => this.Travelplans.Remove(e));
        }
    }
}
