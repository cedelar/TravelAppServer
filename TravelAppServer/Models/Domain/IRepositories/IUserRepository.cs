using System.Collections.Generic;
using TravelApp.Models;

namespace TravelAppServer.Models.Domain.IRepositories
{
    public interface IUserRepository
    {
        User GetById(int userId);
        User GetByName(string username);
        IEnumerable<User> GetAllUsers();
        User GetByNameShort(string username);
        IEnumerable<User> GetAllUsersShort();
        void Add(User user);
        void Delete(User user);
        public void Update(User user);
        void SaveChanges();
    }
}
