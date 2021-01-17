using Newtonsoft.Json;
using System;

namespace TravelApp.Models
{
    public class TravelItem
    {
        private string _name;
        private string _category;

        public int TravelItemId
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
        public int Amount { get; set; }
        public string Category
        {
            get
            {
                return _category;
            }

            set
            {
                _category = string.IsNullOrWhiteSpace(value) ? "No Category" : value;
            }
        }

        [JsonConstructor]
        public TravelItem(string name, int amount, string category)
        {
            Name = name;
            Amount = amount;
            Category = category;
            IsChecked = false;
        }

        public TravelItem(string naam) : this(naam, 0, null) { }
    }
}
