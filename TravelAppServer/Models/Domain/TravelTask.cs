using Newtonsoft.Json;
using System;

namespace TravelApp.Models
{
    public class TravelTask
    {
        private string _name;
        private string _description;

        public int TravelTaskId
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

        public bool IsChecked { get; set; }
        public int Priority { get; set; }
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

        [JsonConstructor]
        public TravelTask(string name, int priority, string description)
        {
            Name = name;
            IsChecked = false;
            Priority = priority;
            Description = description;
        }

        public TravelTask(string name): this(name, 0, null){}
    }
}
