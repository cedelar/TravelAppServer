using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using TravelApp.Models;
using TravelAppServer.Models;
using TravelAppServer.Models.Domain.IRepositories;

namespace TravelAppServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/User/getAll
        [HttpGet("getAll")]
        public IEnumerable<User> Get()
        {
            return _userRepository.GetAllUsers();
        }

        // GET api/User/{username}/{password}
        [HttpGet("getByName/{username}/{password}")]
        public User GetByName(string username, string password)
        {
            User userAuth = _userRepository.GetByNameShort(username);
            if(userAuth == null)
            {
                return new User("NOK", "Unknown user");
            }
            if(userAuth.Password == password)
            {
                return _userRepository.GetByName(username);
            }
            return new User("NOK", "Incorrect password");
        }

        // POST api/addUser
        [HttpPost("addUser")]
        public string PostNewUser([FromBody] JsonElement value)
        {
            NewUser response = JsonConvert.DeserializeObject<NewUser>(value.GetRawText());
            if(_userRepository.GetAllUsersShort().Where(u => u.UserName == response.Username).Count() > 0)
            {
                return "Error: Username already in use, try again. ";
            }
            else
            {
                User newUser = new User(response.Username, response.Password);
                _userRepository.Add(newUser);
                _userRepository.SaveChanges();
                return "User " + response.Username + " succesfully added.";
            }
        }

        [HttpPost("addTravelPlan/{username}")]
        public string PostNewTravelPlan(string username, [FromBody] JsonElement value)
        {
            if (_userRepository.GetAllUsersShort().Where(u => u.UserName == username).Count() < 1)
            {
                return "Error: Unknown user";
            }
            try
            {
                TravelPlan newPlan = JsonConvert.DeserializeObject<TravelPlan>(value.GetRawText());
                User user = _userRepository.GetByName(username);
                if(user.getTravelPlan(newPlan.Name).Count() > 0)
                {
                    return "Error: Name " + newPlan.Name + " already in use, try again.";
                }
                user.AddTravelPlan(newPlan);
                _userRepository.Update(user);
                _userRepository.SaveChanges();
                return username + "'s TravelPlan \"" + newPlan.Name + "\" added succesfully.";
            }catch(Exception e)
            {
                return "Error: " + e.Message;
            }
        }

        // DELETE api/User/deleteTravelPlan/{username}/{travelplanname}
        [HttpDelete("deleteTravelPlan/{username}/{travelplanname}")]
        public string DeleteTravelPlan(string username, string travelplanname)
        {
            if (_userRepository.GetAllUsersShort().Where(u => u.UserName == username).Count() < 1)
            {
                return "Error: Unknown user";
            }
            try
            {
                User user = _userRepository.GetByName(username);
                if (user.Travelplans.Where(t => t.Name == travelplanname).Count() < 1)
                {
                    return "Error: Unknown travelplan";
                }
                user.RemoveTravelPlan(travelplanname);
                _userRepository.Update(user);
                _userRepository.SaveChanges();
                return username + "'s TravelPlan \"" + travelplanname + "\" removed succesfully.";
            }
            catch (Exception e)
            {
                return "Error: " + e.Message;
            }

        }

        // POST api/addTravelItem/{username}/{travelplan}
        [HttpPost("addTravelItem/{username}/{travelplan}")]
        public string PostNewTravelItem(string username, string travelplan, [FromBody] JsonElement value)
        {
            if (_userRepository.GetAllUsersShort().Where(u => u.UserName == username).Count() < 1)
            {
                return "Error: Unknown user";
            }
            else
            {
                User user = _userRepository.GetByName(username);
                if(user.Travelplans.Where(t => t.Name == travelplan).Count() < 1)
                {
                    return "Error: Unknown travelplan";
                }
                TravelItem response = JsonConvert.DeserializeObject<TravelItem>(value.GetRawText());
                if (user.Travelplans.Where(t => t.Name == travelplan).First().ItemList.Where(i => i.Name == response.Name && i.Category == response.Category).Count() > 0)
                {
                    return "Error: TravelItem already exists";
                }
                user.Travelplans.Where(t => t.Name == travelplan).First().AddTravelItem(response);
                _userRepository.Update(user);
                _userRepository.SaveChanges();
                return response.Name + " succesfully added to " + username + "'s TravelPlan \"" + travelplan + "\"";
            }
        }

        // POST api/addTravelTask/{username}/{travelplan}
        [HttpPost("addTravelTask/{username}/{travelplan}")]
        public string PostNewTravelTask(string username, string travelplan, [FromBody] JsonElement value)
        {
            if (_userRepository.GetAllUsersShort().Where(u => u.UserName == username).Count() < 1)
            {
                return "Error: Unknown user";
            }
            else
            {
                User user = _userRepository.GetByName(username);
                if (user.Travelplans.Where(t => t.Name == travelplan).Count() < 1)
                {
                    return "Error: Unknown travelplan";
                }
                TravelTask response = JsonConvert.DeserializeObject<TravelTask>(value.GetRawText());
                if (user.Travelplans.Where(t => t.Name == travelplan).First().TaskList.Where(i => i.Name == response.Name && i.Description == response.Description).Count() > 0)
                {
                    return "Error: TravelTask already exists";
                }
                user.Travelplans.Where(t => t.Name == travelplan).First().AddTravelTask(response);
                _userRepository.Update(user);
                _userRepository.SaveChanges();
                return response.Name + " succesfully added to " + username + "'s TravelPlan \"" + travelplan + "\"";
            }
        }

        // POST api/addTravelRoute/{username}/{travelplan}
        [HttpPost("addTravelRoute/{username}/{travelplan}")]
        public string PostNewTravelRoute(string username, string travelplan, [FromBody] JsonElement value)
        {
            if (_userRepository.GetAllUsersShort().Where(u => u.UserName == username).Count() < 1)
            {
                return "Error: Unknown user";
            }
            else
            {
                User user = _userRepository.GetByName(username);
                if (user.Travelplans.Where(t => t.Name == travelplan).Count() < 1)
                {
                    return "Error: Unknown travelplan";
                }
                TravelRoute response = JsonConvert.DeserializeObject<TravelRoute>(value.GetRawText());
                if (user.Travelplans.Where(t => t.Name == travelplan).First().RouteList.Where(i => i.Name == response.Name).Count() > 0)
                {
                    return "Error: TravelRoute already exists";
                }
                user.Travelplans.Where(t => t.Name == travelplan).First().AddTravelRoute(response);
                _userRepository.Update(user);
                _userRepository.SaveChanges();
                return response.Name + " succesfully added to " + username + "'s TravelPlan \"" + travelplan + "\"";
            }
        }

        // POST api/addTravelLocation/{username}/{travelplan}/{travelroute}
        [HttpPost("addTravelLocation/{username}/{travelplan}/{travelroute}")]
        public string PostNewTravelLocation(string username, string travelplan, string travelroute, [FromBody] JsonElement value)
        {
            if (_userRepository.GetAllUsersShort().Where(u => u.UserName == username).Count() < 1)
            {
                return "Error: Unknown user";
            }
            else
            {
                User user = _userRepository.GetByName(username);
                if (user.Travelplans.Where(t => t.Name == travelplan).Count() < 1)
                {
                    return "Error: Unknown travelplan";
                }
                if (user.Travelplans.Where(t => t.Name == travelplan).First().RouteList.Where(i => i.Name == travelroute).Count() < 1)
                {
                    return "Error: Unknown travelroute";
                }
                TravelLocation response = JsonConvert.DeserializeObject<TravelLocation>(value.GetRawText());
                if (user.Travelplans.Where(t => t.Name == travelplan).First().RouteList.Where(i => i.Name == travelroute).First().Locations.Where(l => l.Name == response.Name).Count() > 0)
                {
                    return "Error: TravelRoute already has this location";
                }
                user.Travelplans.Where(t => t.Name == travelplan).First().RouteList.Where(i => i.Name == travelroute).First().AddTravelLocation(response);
                _userRepository.Update(user);
                _userRepository.SaveChanges();
                return response.Name + " succesfully added to " + username + "'s TravelRoute \"" + travelroute + "\"";
            }
        }

        // PUT api/User/editTravelPlan/{username}
        [HttpPut("editTravelPlan/{username}")]
        public string EditTravelPlan(string username, [FromBody] JsonElement value)
        {
            if (_userRepository.GetAllUsersShort().Where(u => u.UserName == username).Count() < 1)
            {
                return "Error: Unknown user";
            }
            else
            {
                User user = _userRepository.GetByName(username);
                TravelPlan editedPlan = JsonConvert.DeserializeObject<TravelPlan>(value.GetRawText());
                if (user.Travelplans.Where(t => t.Name == editedPlan.Name).Count() < 1)
                {
                    return "Error: Unknown travelplan";
                }
                try
                {
                    TravelPlan oldTravelPlan = user.Travelplans.Where(t => t.Name == editedPlan.Name).First();
                    if(oldTravelPlan.StartDate.Date != editedPlan.StartDate.Date)
                    {
                        oldTravelPlan.StartDate = editedPlan.StartDate;
                    }
                    if (oldTravelPlan.EndDate.Date != editedPlan.EndDate.Date)
                    {
                        oldTravelPlan.EndDate = editedPlan.EndDate;
                    }
                    if (oldTravelPlan.Destination != editedPlan.Destination)
                    {
                        oldTravelPlan.Destination = editedPlan.Destination;
                    }
                    _userRepository.Update(user);
                    _userRepository.SaveChanges();
                    return username + "'s TravelPlan " + oldTravelPlan.Name + " updated succesfully.";
                }
                catch (Exception e)
                {
                    return "Error: " + e.Message;
                }
            }
        }
    }
}
