using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApp.Models;
using TravelAppServer.Models.Domain.IRepositories;

namespace TravelAppServer.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<User> _users;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _users = dbContext.Users;
        }



        public void Add(User user)
        {
            _users.Add(user);
        }

        public void Delete(User user)
        {
            _users.Remove(user);
        }

        public void Update(User user)
        {
            _users.Update(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users
                .Include(u => u.Travelplans).ThenInclude(t => t.RouteList).ThenInclude(r => r.Locations)
                .Include(u => u.Travelplans).ThenInclude(t => t.ItemList)
                .Include(u => u.Travelplans).ThenInclude(t => t.TaskList)
                .ToList();
        }

        public IEnumerable<User> GetAllUsersShort()
        {
            return _users.ToList();
        }

        public User GetById(int userId)
        {
            return GetAllUsers().SingleOrDefault(u => u.UserId == userId);
        }

        public User GetByName(string username)
        {
            return GetAllUsers().SingleOrDefault(u => u.UserName == username);
        }
        public User GetByNameShort(string username)
        {
            return GetAllUsersShort().SingleOrDefault(u => u.UserName == username);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
