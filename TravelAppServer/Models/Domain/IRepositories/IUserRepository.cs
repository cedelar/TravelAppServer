using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApp.Models;

namespace TravelAppServer.Models.Domain.IRepositories
{
    public interface IUserRepository
    {
        User GetById(int userId);
        User GetByName(string username);
        IEnumerable<User> GetAllUsers();
        void Add(User user);
        void Delete(User user);
        void SaveChanges();
    }
}
