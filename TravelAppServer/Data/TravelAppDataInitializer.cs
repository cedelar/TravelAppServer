using System;
using System.Collections.Generic;
using TravelApp.Models;

namespace TravelAppServer.Data
{
    public class TravelAppDataInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public TravelAppDataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                User user = new User("ll", "ll");

                List<string> travelnames = new List<string>
            {
                "Venetië - 2021",
                "Perth - 2022",
                "Praag - Ooit"
            };

                List<DateTime> startdates = new List<DateTime>
            {
                new DateTime(2021, 8, 10),
                new DateTime(2022, 7, 21),
                new DateTime()
            };

                List<DateTime> enddates = new List<DateTime>
            {
                new DateTime(2021, 8, 17),
                new DateTime(2022, 8, 7),
                new DateTime()
            };

                List<String> destinations = new List<string>
            {
                "Venetië",
                "Perth",
                "Praag"
            };

                List<List<TravelItem>> itemnames = new List<List<TravelItem>>
            {
               new List<TravelItem>{
                   new TravelItem("Kam", 2, "Badkamer"),
                   new TravelItem("Shampoo", 1, "Badkamer"),
                   new TravelItem("Handdoek", 4, "Badkamer"),
                   new TravelItem("Lader", 2, "Electronica"),
                   new TravelItem("Ipad", 1, "Electronica"),
                   new TravelItem("Zeep", 2, "Badkamer")
               },
               new List<TravelItem>{
                   new TravelItem("Shampoo", 1, "Badkamer"),
                   new TravelItem("Handdoek", 4, "Badkamer"),
                   new TravelItem("Lader", 2, "Electronica"),
               },
               new List<TravelItem>{}
            };

                List<List<TravelTask>> tasknames = new List<List<TravelTask>>
            {
                new List<TravelTask> {
                    new TravelTask("Biertasting reserveren", 2, "Veeeeeeeeeeeery important"),
                    new TravelTask("Tickets kopen", 1, "Might as well"),
                    new TravelTask("Hotel boeken", -1, "The streets are comfy"),
                    new TravelTask("Vliegtickets kopen", -1, "I believe i can fly"),
                    new TravelTask("Infocentrum zoeken", 0, "What to do?"),
                },
                new List<TravelTask> {
                    new TravelTask("Hotel boeken", 1, "The streets are comfy"),
                    new TravelTask("Vliegtickets kopen", -1, "I believe i can fly"),
                },
                new List<TravelTask> {}
            };

                List<List<TravelLocation>> locations = new List<List<TravelLocation>>
            {
                new List<TravelLocation>
                {
                new TravelLocation("Kemzeke", "Kemzeke", 51.207069, 4.078400),
                new TravelLocation("Sint-Pauwels", "Sint-Pauwels", 51.193981, 4.095680),
                new TravelLocation("Sint-Niklaas", "Sint-Niklaas", 51.164551, 4.139220),
                new TravelLocation("Beveren", "Beveren", 51.213482, 4.258050),
                new TravelLocation("Sinaai", "Sinaai", 51.157509, 4.042380),
                },
                new List<TravelLocation>
                {
                new TravelLocation("Gent", "Gent", 51.0538286, 3.7250121),
                new TravelLocation("Antwerpen", "Antwerpen", 51.2211097, 4.3997081)
                }
            };

                for (int i = 0; i < travelnames.Count; i++)
                {
                    TravelPlan plan = new TravelPlan(travelnames[i], startdates[i], enddates[i], destinations[i]);
                    itemnames[i].ForEach(s => plan.AddTravelItem(s));
                    tasknames[i].ForEach(s => plan.AddTravelTask(s));
                    if(i == 0)
                    {
                        plan.AddTravelRoute(new TravelRoute("route1", "desc1", locations[0]));
                        plan.AddTravelRoute(new TravelRoute("route2", "desc2", locations[1]));
                        plan.AddTravelRoute(new TravelRoute("route3", "desc3"));
                    }
                    user.AddTravelPlan(plan);
                }

                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
            }
        }
    }
}
